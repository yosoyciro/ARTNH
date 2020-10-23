using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;

namespace DAL.Formularios
{
    public class CRUDPresentaciones
    {
        #region Singleton
        private static ISession session;
        public static CRUDPresentaciones instancia = new CRUDPresentaciones();

        private CRUDPresentaciones()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        public List<BE.Formularios.Presentaciones> Listar(double pCUIT)
        {
            session.Clear();
            try
            {
                //Devuelvo las presentacions del CUIT o "Sin presentacion"
                return session.Query<BE.Formularios.Presentaciones>().Where(a => a.CUIT == pCUIT || a.Interno == 0).ToList();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Formularios.Presentaciones VerificarPresentacion(double pCUIT, string pNombre)
        {
            session.Clear();
            try
            {
                //Devuelvo las presentacions del CUIT o "Sin presentacion"
                return session.Query<BE.Formularios.Presentaciones>().FirstOrDefault(a => a.CUIT == pCUIT || a.Nombre == pNombre);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool VerificarCompletados(double pCUIT, string pTipo)
        {
            session.Clear();

            //Busco los establecimientos
            var establecimientos = session.Query<BE.Formularios.RefEstablecimiento>()
                .Where(a => a.CUIT == pCUIT)
                .ToList();

            foreach (var item in establecimientos)
            {
                //busco formularios sin presentacion para cada establecimiento
                switch (pTipo)
                {
                    case "R":
                        var formularioRGRL = session.Query<BE.Formularios.RespuestasFormulario>()
                                .Where(a => a.InternoEstablecimiento == item.Interno && a.InternoPresentacion == 0)
                                .FirstOrDefault();
                        if (formularioRGRL != null)
                        {
                            return false;
                        }
                        break;

                    case "A":
                        var formularioRAR = session.Query<BE.FormRAR.FormulariosRAR>()
                                .Where(a => a.InternoEstablecimiento == item.Interno && a.InternoPresentacion == 0)
                                .FirstOrDefault();
                        if (formularioRAR != null)
                        {
                            return false;
                        }
                        break;

                    default:
                        break;
                }
            }

            return true;
        }

        public BE.Formularios.Presentaciones Generar(BE.Formularios.Presentaciones pPresentacion)
        {
            ITransaction transaction = session.BeginTransaction();
            try
            {
                switch (pPresentacion.Interno)
                {
                    case 0:
                        session.Save(pPresentacion);

                        //Busco los establecimientos
                        var establecimientos = session.Query<BE.Formularios.RefEstablecimiento>()
                            .Where(a => a.CUIT == pPresentacion.CUIT)
                            .ToList();


                        foreach (var item in establecimientos)
                        {
                            //Recorro todos los formularios del CUIT que no tengan presentacion y asigno el dato
                            switch (pPresentacion.Tipo)
                            {
                                //Formularios RGRL
                                case "R":
                                    var formularioRGRL = session.Query<BE.Formularios.RespuestasFormulario>()
                                        .Where(a => a.InternoEstablecimiento == item.Interno && a.InternoPresentacion == 0)
                                        .FirstOrDefault();
                                    if (formularioRGRL != null)
                                    {
                                        formularioRGRL.InternoPresentacion = pPresentacion.Interno;
                                        session.Merge(formularioRGRL);
                                    }
                                    break;

                                //RAR
                                case "A":
                                    var formularioRAR = session.Query<BE.FormRAR.FormulariosRAR>()
                                        .Where(a => a.InternoEstablecimiento == item.Interno && a.InternoPresentacion == 0)
                                        .FirstOrDefault();
                                    if (formularioRAR != null)
                                    {
                                        formularioRAR.InternoPresentacion = pPresentacion.Interno;
                                        session.Merge(formularioRAR);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    default:
                        session.Merge(pPresentacion);
                        break;
                }
                                
                
                session.Flush();
                transaction.Commit();

                return pPresentacion;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
    }
}
