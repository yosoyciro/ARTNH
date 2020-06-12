using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.FormRAR;
using NHibernate;

namespace DAL.FormRAR
{
    public class CRUDFormulariosRARDetalle
    {
        #region Singleton
        private static ISession session;
        public static CRUDFormulariosRARDetalle instancia = new CRUDFormulariosRARDetalle();

        private CRUDFormulariosRARDetalle()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        #region Guardar
        public FormulariosRARDetalle Guardar(FormulariosRARDetalle pFormulariosRARDetalle)
        {
            ITransaction transaction = session.BeginTransaction();
            try
            {
                FormulariosRARDetalle nuevoFormulariosRARDetalle = null;
                nuevoFormulariosRARDetalle = session.Get<FormulariosRARDetalle>(pFormulariosRARDetalle.Interno);
                if (nuevoFormulariosRARDetalle != null)
                {
                    nuevoFormulariosRARDetalle = pFormulariosRARDetalle;
                    session.Merge(nuevoFormulariosRARDetalle);
                }                    
                else
                {
                    session.Save(pFormulariosRARDetalle);
                }
                transaction.Commit();
                session.Flush();
                return pFormulariosRARDetalle;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
        }
        #endregion

        #region Borrar
        public bool Borrar(int pInternoFormulariosRARDetalle)
        {
            ITransaction transaction = session.BeginTransaction();
            try
            {
                FormulariosRARDetalle nuevoFormulariosRARDetalle = null;
                nuevoFormulariosRARDetalle = session.Get<FormulariosRARDetalle>(pInternoFormulariosRARDetalle);
                if (nuevoFormulariosRARDetalle != null)
                {
                    session.Delete(nuevoFormulariosRARDetalle);
                    transaction.Commit();
                }

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
        public IList<FormulariosRARDetalle> Consultar(int pInternoFormulariosRAR)
        {
            return session.Query<FormulariosRARDetalle>().Where(a => a.InternoFormulariosRAR == pInternoFormulariosRAR).OrderBy(b => b.Nombre).ToList();
        }
        #endregion
    }
}
