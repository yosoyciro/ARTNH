using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace DAL
{
    public class CRUDDenuncia
    {
        //private static ISessionFactory sessionfactory;
        private static ISession session;
        //public static DAL.CRUDDenuncia instancia = new DAL.CRUDDenuncia();

        //el constructor es privado ya que solo instancio 1 vez la clase
        public CRUDDenuncia()
        {
            //sessionfactory = SLL.GenerarSesion.Instance.Session
            session = SL.GenerarSesion.Instance.Session;
        }

        ~CRUDDenuncia()
        {
            // do work here
        }

        //Funcion agregar
        public bool Agregar(BE.Denuncia pDenuncia)
        {
            bool ret;
            ITransaction transaction = session.BeginTransaction();
            try
            {
                session.Save(pDenuncia);
                transaction.Commit();
                ret = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }

            return ret;
        }

        //Funcion borrar


        //Funcion listar todos
        public IQueryable<BE.Denuncia> ListarTodas()
        {
            try
            {
                IQueryable<BE.Denuncia> denuncias = session.Query<BE.Denuncia>().AsQueryable();
                return denuncias;
            }

            catch (Exception e)
            {
                throw e;
            }            
        }

        //Funcion buscar por numero
        public BE.Denuncia BuscarPorNumero(int pInterno)
        {
            //BE.GpLlamadasCat gpllamadascat = new BE.GpLlamadasCat();
            return session.Get<BE.Denuncia>(pInterno);
        }         
    }
}
