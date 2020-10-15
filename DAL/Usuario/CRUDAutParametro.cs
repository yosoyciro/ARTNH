using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;

namespace DAL.Usuario
{
    public class CRUDAutParametro
    {
        #region Singleton
        private static ISession session;
        public static CRUDAutParametro instancia = new CRUDAutParametro();

        private CRUDAutParametro()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        #region Funciones ABM
        public BE.Usuario.AutParametro Buscar(int pParametro)
        {
            try
            {
                return session.Query<BE.Usuario.AutParametro>().FirstOrDefault(a => a.Parametro == pParametro);                
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Borrar(int pInterno)
        {
            ITransaction transaction = session.BeginTransaction();
            try
            {
                BE.Usuario.AutParametro autParametro = session.Get<BE.Usuario.AutParametro>(pInterno);

                if (autParametro != null)
                {
                    session.Delete(autParametro);
                    session.Flush();
                    transaction.Commit();
                    return true;
                }
                else
                    return false;                
            }

            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
        #endregion
    }
}
