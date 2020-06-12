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
    public class CRUDCtaCteTiposRetencion
    {
        #region Singleton
        private static ISession session;
        public static CRUDCtaCteTiposRetencion instancia = new CRUDCtaCteTiposRetencion();

        private CRUDCtaCteTiposRetencion()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        public IList<CtaCteTiposRetencion> Listar()
        {
            return session.Query<CtaCteTiposRetencion>().ToList();
        }
    }
}
