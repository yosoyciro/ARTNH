using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;

namespace DAL.Formularios
{
    public class CRUDReferenteDatos
    {

        #region Singleton
        private static ISession session;
        public static CRUDReferenteDatos instancia = new CRUDReferenteDatos();

        private CRUDReferenteDatos()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        public List<BE.Formularios.ReferenteDatos> ListarPorCuit(double pCuit)
        {
            try
            {
                return session.Query<BE.Formularios.ReferenteDatos>().Where(a => a.CUIT == pCuit).ToList();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


}
