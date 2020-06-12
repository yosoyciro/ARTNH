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
    public class CRUDCtaCteRetenciones
    {
        #region Singleton
        private static ISession session;
        public static CRUDCtaCteRetenciones instancia = new CRUDCtaCteRetenciones();

        private CRUDCtaCteRetenciones()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        public IList<CtaCteRetenciones> ListarPorCtaCteProvInterno(double pInternoCtaCte)
        {
            return session.Query<CtaCteRetenciones>().Where(a => a.InternoCtaCteProv == pInternoCtaCte).ToList();
        }

        public bool Guardar(CtaCteRetenciones pCtaCtePagos)
        {
            bool ret = true;
            ITransaction transaction = session.BeginTransaction();

            try
            {
                CtaCteRetenciones ctactepagos = session.Get<CtaCteRetenciones>(pCtaCtePagos.Interno);
                if (ctactepagos != null)
                    session.Merge(pCtaCtePagos);
                else
                    session.Save(pCtaCtePagos);

                transaction.Commit();

                return ret;
            }

            catch(Exception ex)
            {
                ret = false;
                throw ex;
            }
        }

    }
}
