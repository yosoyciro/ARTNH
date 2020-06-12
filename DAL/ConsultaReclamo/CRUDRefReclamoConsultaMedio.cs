using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace DAL
{
    public class CRUDRefReclamoConsultaMedio
    {
        //private static ISessionFactory sessionfactory;
        private static ISession session;
        //public static DAL.CRUDRefReclamosConsulta instancia = new DAL.CRUDRefReclamosConsulta();

        //el constructor es privado ya que solo instancio 1 vez la clase
        public CRUDRefReclamoConsultaMedio()
        {
            //sessionfactory = SLL.GenerarSesion.Instance.Session
            session = SL.GenerarSesion.Instance.Session;
        }

        ~CRUDRefReclamoConsultaMedio()
        {
            // do work here
        }

        //Funcion agregar
        public bool Agregar(BE.ReclamoConsultaMedio pDetalle)
        {
            bool ret;
            ITransaction transaction = session.BeginTransaction();
            try
            {
                session.Save(pDetalle);
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
        public IQueryable<BE.ReclamoConsultaMedio> ListarTodas()
        {
            try
            {
                IQueryable<BE.ReclamoConsultaMedio> rec = session.Query<BE.ReclamoConsultaMedio>().AsQueryable();
                return rec;
            }

            catch (Exception e)
            {
                throw e;
            }            
        }

        //Funcion buscar por numero
        public BE.ReclamoConsultaMedio BuscarPorNumero(int pInterno)
        {
            return session.Get<BE.ReclamoConsultaMedio>(pInterno);
        }         
    }
}
