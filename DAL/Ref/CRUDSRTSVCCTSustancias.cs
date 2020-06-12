using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using BE.Ref;

namespace DAL.Ref
{
    public class CRUDSRTSVCCTSustancias
    {
        #region Singleton
        private static ISession session;
        public static CRUDSRTSVCCTSustancias instancia = new CRUDSRTSVCCTSustancias();

        private CRUDSRTSVCCTSustancias()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        #region Consultar
        public IList<SRTSVCCTSustancias> Consultar()
        {
            return session.Query<SRTSVCCTSustancias>().ToList();
        }
        #endregion
    }
}
