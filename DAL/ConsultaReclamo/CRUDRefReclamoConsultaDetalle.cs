using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace DAL
{
    public class CRUDRefReclamoConsultaDetalle
    {
        //private static ISessionFactory sessionfactory;
        private static ISession session;
        //public static DAL.CRUDRefReclamosConsulta instancia = new DAL.CRUDRefReclamosConsulta();

        //el constructor es privado ya que solo instancio 1 vez la clase
        public CRUDRefReclamoConsultaDetalle()
        {
            //sessionfactory = SLL.GenerarSesion.Instance.Session
            session = SL.GenerarSesion.Instance.Session;
        }

        ~CRUDRefReclamoConsultaDetalle()
        {
            // do work here
        }

        //Funcion agregar
        public bool Agregar(BE.ReclamoConsultaDetalle pRefReclamosConsulta)
        {
            bool ret;
            ITransaction transaction = session.BeginTransaction();
            try
            {
                session.Save(pRefReclamosConsulta);
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
        public IQueryable<BE.ReclamoConsultaDetalle> ListarTodas()
        {
            try
            {
                IQueryable<BE.ReclamoConsultaDetalle> rec = session.Query<BE.ReclamoConsultaDetalle>().AsQueryable();
                return rec;
            }

            catch (Exception e)
            {
                throw e;
            }            
        }

        //Funcion buscar por numero
        public BE.ReclamoConsultaDetalle BuscarPorNumero(int pInterno)
        {
            return session.Get<BE.ReclamoConsultaDetalle>(pInterno);
        }         
    }
}
