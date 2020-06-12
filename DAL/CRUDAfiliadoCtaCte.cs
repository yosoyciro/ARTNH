using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;

namespace DAL
{
    public class CRUDAfiliadoCtaCte
    {
        #region Singleton
        private static ISession session;
        public static DAL.CRUDAfiliadoCtaCte instancia = new DAL.CRUDAfiliadoCtaCte();

        private CRUDAfiliadoCtaCte()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        #region Funciones Buscar
        public List<BE.AfiliadoCuentaCorriente> BuscarPorAfiliado(double pCUIL)
        {
            UInt64 cuil = Convert.ToUInt64(pCUIL);
            try
            {
                List<BE.AfiliadoCuentaCorriente> afiliadoctacte = session.Query<BE.AfiliadoCuentaCorriente>().Where(a => a.CuitAportante == cuil).ToList();
                return afiliadoctacte;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
