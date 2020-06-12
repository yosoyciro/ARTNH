using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;

namespace DAL.Formularios
{
    public class CRUDCuestionarios
    {
        #region Singleton
        private static ISession session;
        public static CRUDCuestionarios instancia = new CRUDCuestionarios();

        private CRUDCuestionarios()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        public List<BE.Formularios.Cuestionarios> ListarPorFormulario(int pInternoFormulario)           
        {
            IList<int> secionesFormulario = DAL.Formularios.CRUDSecciones.instancia.SeccionesFormulario(pInternoFormulario);
            try
            {
                return session.Query<BE.Formularios.Cuestionarios>().Where(a => secionesFormulario.Contains(a.InternoSeccion)).ToList();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<BE.Formularios.Cuestionarios> ListarTodas()
        {
            return session.Query<BE.Formularios.Cuestionarios>().ToList();
        }
    }
}
