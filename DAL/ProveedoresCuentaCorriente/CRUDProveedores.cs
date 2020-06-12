using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using BE.ProveedoresCtaCte;

namespace DAL.ProveedoresCuentaCorriente
{
    /// <summary>
    /// Esta clase solo debe leer la entidad ProveedorCuentaCorriente ya que la misma se mapea contra una Vista de SQL
    /// </summary>
    public class CRUDProveedores
    {
        #region Singleton
        private static ISession session;
        public static CRUDProveedores instancia = new CRUDProveedores();

        private CRUDProveedores()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        public IList<Proveedores> Listar()
        {
            return session.Query<Proveedores>().ToList();
        }

        public List<BE.ProveedoresCtaCte.Proveedores> BuscarPorCUIT(double pCUIT)
        {
            UInt64 cuit = Convert.ToUInt64(pCUIT);
            try
            {
                List<BE.ProveedoresCtaCte.Proveedores> prov = session.Query<BE.ProveedoresCtaCte.Proveedores>().Where(a => a.CUIT == cuit).ToList();
                return prov;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
