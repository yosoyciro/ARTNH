using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;

namespace DAL.Formularios
{
    public class CRUDRespuestasFormularioRel
    {

        #region Singleton
        private static ISession session;
        public static CRUDRespuestasFormularioRel instancia = new CRUDRespuestasFormularioRel();

        private CRUDRespuestasFormularioRel()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        public BE.Formularios.RespuestasFormularioRel BuscarPorInternoNuevo(int pInternoRespuestaFormularioNuevo)
        {
            try
            {
                return session.Query<BE.Formularios.RespuestasFormularioRel>().Where(a => a.InternoRespuestaFormularioNuevo == pInternoRespuestaFormularioNuevo).SingleOrDefault();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Formularios.RespuestasFormularioRel BuscarPorInternoOriginal(int pInternoRespuestaFormularioOriginal)
        {
            try
            {
                return session.Query<BE.Formularios.RespuestasFormularioRel>().Where(a => a.InternoRespuestaFormularioOriginal == pInternoRespuestaFormularioOriginal).SingleOrDefault();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
