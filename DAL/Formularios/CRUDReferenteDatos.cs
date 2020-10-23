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
            session.Clear();
            try
            {
                var referenteDatos = session.Query<BE.Formularios.ReferenteDatos>().Where(a => a.CUIT == pCuit).ToList();
                if (referenteDatos != null)
                {
                    foreach (var item in referenteDatos)
                    {
                        var refEmpleador = session.Query<BE.Ref.RefEmpleador>().FirstOrDefault(r => r.CUIT == item.CUIT);
                        if (refEmpleador != null)
                            item.NotificacionRGRL = refEmpleador.NotificacionRGRL;
                    }
                }

                return referenteDatos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


}
