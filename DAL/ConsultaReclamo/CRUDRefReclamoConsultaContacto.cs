using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace DAL
{
    public class CRUDRefReclamoConsultaContacto
    {
        //private static ISessionFactory sessionfactory;
        private static ISession session;
        //public static DAL.CRUDRefReclamosConsulta instancia = new DAL.CRUDRefReclamosConsulta();

        //el constructor es privado ya que solo instancio 1 vez la clase
        public CRUDRefReclamoConsultaContacto()
        {
            //sessionfactory = SLL.GenerarSesion.Instance.Session
            session = SL.GenerarSesion.Instance.Session;
        }

        ~CRUDRefReclamoConsultaContacto()
        {
            // do work here
        }

        //Funcion agregar
        public bool Agregar(BE.ReclamoConsultaContacto pDetalle)
        {
            bool ret;
            ITransaction transaction = session.BeginTransaction();
            try
            {
                session.Save(pDetalle);

                /*int interno = pDetalle.Interno;

                //por cada medio (email/telefonos)
                foreach (var medio in pDetalle.RefReclamoConsultaMedio)
                {
                    medio.Contacto = interno;

                    BE.RefReclamoConsultaMedio medios = session.Query<BE.RefReclamoConsultaMedio>().Where(a => a.Direccion == medio.Direccion && a.Contacto == medio.Contacto).SingleOrDefault();
                    //var ReclamoConsultaMedio = session.Get<BE.RefReclamoConsultaMedio>(medio.Interno);
                    if (medios == null)
                        session.Save(medio);
                    else
                        session.Merge(medio);
                }*/

                transaction.Commit();
                ret = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }

            return ret;
        }

        //Funcion borrar


        //Funcion listar todos
        public IQueryable<BE.ReclamoConsultaContacto> ListarTodas()
        {
            try
            {
                IQueryable<BE.ReclamoConsultaContacto> rec = session.Query<BE.ReclamoConsultaContacto>().AsQueryable();
                return rec;
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        //Funcion buscar por numero
        public BE.ReclamoConsultaContacto BuscarPorNumero(int pInterno)
        {
            return session.Get<BE.ReclamoConsultaContacto>(pInterno);
        }
    }
}
