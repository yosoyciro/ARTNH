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
    public class CRUDCtaCteTiposPago
    {
        #region Singleton
        private static ISession session;
        public static CRUDCtaCteTiposPago instancia = new CRUDCtaCteTiposPago();

        private CRUDCtaCteTiposPago()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        public IList<CtaCteTiposPago> Listar()
        {
            return session.Query<CtaCteTiposPago>().ToList();
        }
    }
}
