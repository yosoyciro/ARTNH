using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace DAL
{
    public class CRUDRefReclamoConsultaResponder
    {
        //private static ISessionFactory sessionfactory;
        private static ISession session;
        //public static DAL.CRUDRefReclamosConsulta instancia = new DAL.CRUDRefReclamosConsulta();

        //el constructor es privado ya que solo instancio 1 vez la clase
        public CRUDRefReclamoConsultaResponder()
        {
            //sessionfactory = SLL.GenerarSesion.Instance.Session
            session = SL.GenerarSesion.Instance.Session;
        }

        ~CRUDRefReclamoConsultaResponder()
        {
            // do work here
        }

        //Funcion agregar 
        public bool Agregar(BE.ReclamoConsultaResponder pDetalle)
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
        public IQueryable<BE.ReclamoConsultaResponder> ListarTodas()
        {
            try
            {
                IQueryable<BE.ReclamoConsultaResponder> rec = session.Query<BE.ReclamoConsultaResponder>().AsQueryable();
                return rec;
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        //Funcion buscar por numero
        public BE.ReclamoConsultaResponder BuscarPorNumero(int pInterno)
        {
            return session.Get<BE.ReclamoConsultaResponder>(pInterno);
        }
    }
}
