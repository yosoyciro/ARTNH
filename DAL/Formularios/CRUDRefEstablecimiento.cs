using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;

namespace DAL.Formularios
{
    public class CRUDRefEstablecimiento
    {

        #region Singleton
        private static ISession session;
        public static CRUDRefEstablecimiento instancia = new CRUDRefEstablecimiento();

        private CRUDRefEstablecimiento()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        public List<BE.Formularios.RefEstablecimiento> ListarPorCuit(double pCuit)
        {
            try
            {
                return session.Query<BE.Formularios.RefEstablecimiento>().Where(a => a.CUIT == pCuit).ToList();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Formularios.RefEstablecimiento ListarPorInterno(int pInternoEstablecimiento)
        {
            try
            {
                return session.Get<BE.Formularios.RefEstablecimiento>(pInternoEstablecimiento);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
