using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;

namespace DAL.Formularios
{
    public class CRUDSecciones
    {
        #region Singleton
        private static ISession session;
        public static CRUDSecciones instancia = new CRUDSecciones();

        private CRUDSecciones()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        public List<BE.Formularios.Secciones> ListarSeccionesFormulario(int pInternoFormulario)
        {
            try
            {
                return session.Query<BE.Formularios.Secciones>().Where(a => a.InternoFormulario == pInternoFormulario && a.Baja == 0).ToList();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<int> SeccionesFormulario(int pInternoFormulario)
        {
            var internos = session.QueryOver<BE.Formularios.Secciones>()                    
                    .WhereRestrictionOn(c => c.InternoFormulario).IsBetween(pInternoFormulario).And(pInternoFormulario)
                    .Select(c => c.Interno)
                    .Where(a => a.Baja == 0)
                    .List<int>();

            return internos;
        }

        public IList<BE.Formularios.Secciones> ListarTodas()
        {
            return session.Query<BE.Formularios.Secciones>().Where(a => a.Baja == 0).ToList();
        }
    }
}
