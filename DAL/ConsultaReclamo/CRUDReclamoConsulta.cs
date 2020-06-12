using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using NHibernate.SqlCommand;

namespace DAL
{
    public class CRUDReclamoConsulta
    {
        #region Singleton
        private static ISession session;
        public static CRUDReclamoConsulta instancia = new CRUDReclamoConsulta();

        public CRUDReclamoConsulta()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        #region MetodoAgregar
        public int Agregar(BE.ReclamoConsulta pRefReclamoConsulta)
        {
            ITransaction transaction = session.BeginTransaction();
            try
            {
                //busca contacto
                int internoContacto = 0;
                BE.ReclamoConsultaContacto contacto = session.Query<BE.ReclamoConsultaContacto>().Where(a => a.DocNro == pRefReclamoConsulta.RefReclamoConsultaContacto.DocNro && a.DocTipo == pRefReclamoConsulta.RefReclamoConsultaContacto.DocTipo).SingleOrDefault();
                if (contacto == null)
                {
                    session.Save(pRefReclamoConsulta.RefReclamoConsultaContacto);
                    internoContacto = pRefReclamoConsulta.RefReclamoConsultaContacto.Interno;
                }
                else
                {
                    internoContacto = contacto.Interno;
                }
                var reclamo = session.Get<BE.ReclamoConsulta>(pRefReclamoConsulta.Interno);

                if (reclamo == null)
                {
                    pRefReclamoConsulta.Contacto = internoContacto;
                    session.Save(pRefReclamoConsulta);
                }

                else
                {
                    pRefReclamoConsulta.Contacto = internoContacto;
                    session.Merge(pRefReclamoConsulta);
                }

                int interno = pRefReclamoConsulta.Interno;

                //por cada medio (email/telefonos)
                foreach (var medio in pRefReclamoConsulta.RefReclamoConsultaContacto.RefReclamoConsultaMedio)
                {
                    medio.Contacto = internoContacto;

                    BE.ReclamoConsultaMedio medios = session.Query<BE.ReclamoConsultaMedio>().Where(a => a.Direccion == medio.Direccion && a.Contacto == medio.Contacto).SingleOrDefault();
                    //var ReclamoConsultaMedio = session.Get<BE.RefReclamoConsultaMedio>(medio.Interno);
                    if (medios == null)
                    {
                        session.Save(medio);


                        BE.ReclamoConsultaResponder Responder = new BE.ReclamoConsultaResponder();

                        Responder.ReclamoConsulta = interno;
                        Responder.Medio = medio.Interno;

                        session.Save(Responder);
                    }
                    else
                    {
                        BE.ReclamoConsultaResponder Responder = new BE.ReclamoConsultaResponder();

                        Responder.ReclamoConsulta = interno;
                        Responder.Medio = medios.Interno;

                        session.Save(Responder);
                    }
                }



                //Detalle
                var detalle = session.Get<BE.ReclamoConsultaDetalle>(interno);
                if (detalle == null)
                {
                    pRefReclamoConsulta.RefReclamoConsultaDetalle.ReclamoConsulta = interno;
                    session.Save(pRefReclamoConsulta.RefReclamoConsultaDetalle);
                }
                else
                    session.Merge(pRefReclamoConsulta.RefReclamoConsultaDetalle);

                transaction.Commit();
                session.Flush();
                return interno;
            }

            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
    }
    #endregion
}
