using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using BE.Ref;

namespace DAL.Ref
{
    public class CRUDRefAgenteCausante
    {
        #region Singleton
        private static ISession session;
        public static CRUDRefAgenteCausante instancia = new CRUDRefAgenteCausante();

        private CRUDRefAgenteCausante()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        #region Guardar
        public SRTSiniestralidadAgenteCausante Guardar(SRTSiniestralidadAgenteCausante pRefAgenteCausante)
        {
            ITransaction transaction = session.BeginTransaction();
            try
            {
                session.SaveOrUpdate(pRefAgenteCausante);

                transaction.Commit();
                session.Flush();
                return pRefAgenteCausante;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
        }
        #endregion

        #region Consultar
        public IList<SRTSiniestralidadAgenteCausante> Consultar()
        {
            return session.Query<SRTSiniestralidadAgenteCausante>().ToList();
        }
        #endregion
    }
}
