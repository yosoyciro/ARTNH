using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.FormRAR;
using NHibernate;

namespace DAL.FormRAR
{
    public class CRUDFormulariosRARDetalleAgentes
    {
        #region Singleton
        private static ISession session;
        public static CRUDFormulariosRARDetalleAgentes instancia = new CRUDFormulariosRARDetalleAgentes();

        private CRUDFormulariosRARDetalleAgentes()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        #region Guardar
        public FormulariosRARDetalleAgentes Guardar(FormulariosRARDetalleAgentes pFormulariosRARDetalleAgentes)
        {
            ITransaction transaction = session.BeginTransaction();
            try
            {
                session.SaveOrUpdate(pFormulariosRARDetalleAgentes);
                transaction.Commit();
                session.Flush();
                return pFormulariosRARDetalleAgentes;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
        }
        #endregion

        #region Borrar
        public bool Borrar(FormulariosRARDetalleAgentes pFormulariosRARDetalleAgentes)
        {
            ITransaction transaction = session.BeginTransaction();
            try
            {
                session.Delete(pFormulariosRARDetalleAgentes);
                transaction.Commit();

                bool ret = true;
                return ret;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
        }
        #endregion

        #region Consultar
        public IList<FormulariosRARDetalleAgentes> ConsultarDetalle(int pInternoFormulariosRARDetalle)
        {
            return session.Query<FormulariosRARDetalleAgentes>().Where(a => a.InternoFormulariosRARDetalle == pInternoFormulariosRARDetalle).ToList();
        }
        #endregion
    }
}
