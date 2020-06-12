using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using NHibernate.SqlCommand;
using BE.FormRAR;

namespace DAL.FormRAR
{
    public class CRUDFormulariosRAR
    {
        #region Singleton
        private static ISession session;
        public static CRUDFormulariosRAR instancia = new CRUDFormulariosRAR();

        private CRUDFormulariosRAR()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        #region Guardar
        public FormulariosRAR Guardar(FormulariosRAR pFormulariosRAR)
        {
            ITransaction transaction = session.BeginTransaction();
            try
            {
                FormulariosRAR nuevoFormulariosRAR = null;
                nuevoFormulariosRAR = session.Get<FormulariosRAR>(pFormulariosRAR.Interno);
                if (nuevoFormulariosRAR != null)
                    session.Merge(nuevoFormulariosRAR);
                else
                {
                    nuevoFormulariosRAR = pFormulariosRAR;
                    session.Save(nuevoFormulariosRAR);
                }
                
                transaction.Commit();
                session.Flush();
                return nuevoFormulariosRAR;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }                        
        }
        #endregion

        #region Borrar
        public bool Borrar(FormulariosRAR pFormulariosRAR)
        {            
            ITransaction transaction = session.BeginTransaction();
            try
            {
                FormulariosRAR nuevoFormulariosRAR = null;
                nuevoFormulariosRAR = session.Get<FormulariosRAR>(pFormulariosRAR.Interno);
                if (nuevoFormulariosRAR != null)
                {
                    session.Delete(nuevoFormulariosRAR);
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
        public IList<FormulariosRAR> ConsultarEnProcesoCarga(int pInternoEstablecimiento)
        {
            return session.Query<FormulariosRAR>()
                .Where(a => a.FechaPresentacion == null && a.InternoEstablecimiento == pInternoEstablecimiento)
                .ToList();
        }
        #endregion

        #region Confirmar
        public bool Confirmar(int pInternoFormulariosRAR)
        {
            bool ret = false;
            ITransaction transaction = session.BeginTransaction();
            try
            {
                FormulariosRAR nuevoFormulariosRAR = null;
                nuevoFormulariosRAR = session.Get<FormulariosRAR>(pInternoFormulariosRAR);
                if (nuevoFormulariosRAR != null)
                {
                    nuevoFormulariosRAR.FechaPresentacion = DateTime.Now;
                    session.Merge(nuevoFormulariosRAR);
                    ret = true;
                }

                transaction.Commit();
                session.Flush();

                return ret;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
        }
        #endregion

    }
}
