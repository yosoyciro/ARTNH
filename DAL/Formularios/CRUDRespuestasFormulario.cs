using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using NHibernate.SqlCommand;

namespace DAL.Formularios
{
    public class CRUDRespuestasFormulario
    {
        #region Singleton
        private static ISession session;
        public static CRUDRespuestasFormulario instancia = new CRUDRespuestasFormulario();

        private CRUDRespuestasFormulario()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        #region MetodoAgregar
        public int Agregar (BE.Formularios.RespuestasFormulario pRespuestasFormulario)
        {
            ITransaction transaction = session.BeginTransaction();
            try
            {
                if (pRespuestasFormulario.CreacionFechaHora == null)
                    pRespuestasFormulario.CreacionFechaHora = DateTime.Today;

                var respuestaFormulario = session.Get<BE.Formularios.RespuestasFormulario>(pRespuestasFormulario.Interno);
                if (respuestaFormulario == null)
                    session.Save(pRespuestasFormulario);
                else
                    session.Merge(pRespuestasFormulario);

                int interno = pRespuestasFormulario.Interno;

                //Respuestas
                foreach (var item in pRespuestasFormulario.RespuestasCuestionario)
                {                    
                    item.InternoRespuestaFormulario = interno;
                    //Convertir la fecha normal en fecha clarion
                    DateTime fecha = Convert.ToDateTime(item.FechaRegularizacionNormal);
                    item.FechaRegularizacion = ConvertirFecha(fecha);

                    var respuestaCuestionario = session.Get<BE.Formularios.RespuestasCuestionario>(item.Interno);
                    if (respuestaCuestionario == null)
                        session.Save(item);
                    else
                        session.Merge(item);
                }

                //Gremios 
                foreach (var item in pRespuestasFormulario.RespuestasGremio)
                {
                    item.InternoRespuestaFormulario = interno;

                    var respuestaGremio = session.Get<BE.Formularios.RespuestasGremio>(item.Interno);
                    if (respuestaGremio == null)
                        session.Save(item);
                    else
                        session.Merge(item);
                }

                //Contratistas
                foreach (var item in pRespuestasFormulario.RespuestasContratista)
                {
                    item.InternoRespuestaFormulario = interno;

                    var respuestaContratista = session.Get<BE.Formularios.RespuestasContratista>(item.Interno);
                    if (respuestaContratista == null)
                        session.Save(item);
                    else
                        session.Merge(item);
                }

                //Responsables
                foreach (var item in pRespuestasFormulario.RespuestasResponsable)
                {
                    item.InternoRespuestaFormulario = interno;

                    var respuestaResponsable = session.Get<BE.Formularios.RespuestasResponsable>(item.Interno);
                    if (respuestaResponsable == null)
                        session.Save(item);
                    else
                        session.Merge(item);
                }

                transaction.Commit();
                session.Flush();
                return interno;
            }

            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }            
        }
        #endregion

        #region TraerRespuestas
        public BE.Formularios.RespuestasFormulario TraerRespuestas(int pInternoFormulario, int pInternoEstablecimiento)
        {
            try
            {
                //Limpio el cache de la sesion por si se modifico algo por fuera
                session.Clear();

                //RespuestasFormulario
                BE.Formularios.RespuestasFormulario respuestasFormulario = session.Query<BE.Formularios.RespuestasFormulario>().Where(a => a.InternoFormulario == pInternoFormulario && a.InternoEstablecimiento == pInternoEstablecimiento).OrderByDescending(a => a.Interno).SingleOrDefault();


                //RespuestasCuestionario
                List<BE.Formularios.RespuestasCuestionario> respuestasCuestionario = session.Query<BE.Formularios.RespuestasCuestionario>().Where(a => a.InternoRespuestaFormulario == respuestasFormulario.Interno).ToList();

                respuestasFormulario.RespuestasCuestionario = respuestasCuestionario;
                

                //RespuestasGremio
                List<BE.Formularios.RespuestasGremio> respuestasGremio = session.Query<BE.Formularios.RespuestasGremio>().Where(a => a.InternoRespuestaFormulario == respuestasFormulario.Interno).ToList();
                respuestasFormulario.RespuestasGremio = respuestasGremio;
                

                //RespuestasContratista
                List<BE.Formularios.RespuestasContratista> respuestasContratista = session.Query<BE.Formularios.RespuestasContratista>().Where(a => a.InternoRespuestaFormulario == respuestasFormulario.Interno).ToList();
                respuestasFormulario.RespuestasContratista = respuestasContratista;

                //RespuestasResponsables
                List<BE.Formularios.RespuestasResponsable> respuestasResponsable = session.Query<BE.Formularios.RespuestasResponsable>().Where(a => a.InternoRespuestaFormulario == respuestasFormulario.Interno).ToList();
                respuestasFormulario.RespuestasResponsable = respuestasResponsable;

                //Return
                return respuestasFormulario;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region TraerRespuestasConsulta
        public BE.Formularios.RespuestasFormulario TraerRespuestasConsulta(int pInternoRespuestasFormulario)
        {
            try
            {
                //RespuestasFormulario
                BE.Formularios.RespuestasFormulario respuestasFormulario = session.Get<BE.Formularios.RespuestasFormulario>(pInternoRespuestasFormulario);


                //RespuestasCuestionario
                List<BE.Formularios.RespuestasCuestionario> respuestasCuestionario = session.Query<BE.Formularios.RespuestasCuestionario>().Where(a => a.InternoRespuestaFormulario == respuestasFormulario.Interno).ToList();

                respuestasFormulario.RespuestasCuestionario = respuestasCuestionario;


                //RespuestasGremio
                List<BE.Formularios.RespuestasGremio> respuestasGremio = session.Query<BE.Formularios.RespuestasGremio>().Where(a => a.InternoRespuestaFormulario == respuestasFormulario.Interno).ToList();
                respuestasFormulario.RespuestasGremio = respuestasGremio;


                //RespuestasContratista
                List<BE.Formularios.RespuestasContratista> respuestasContratista = session.Query<BE.Formularios.RespuestasContratista>().Where(a => a.InternoRespuestaFormulario == respuestasFormulario.Interno).ToList();
                respuestasFormulario.RespuestasContratista = respuestasContratista;

                //RespuestasResponsables
                List<BE.Formularios.RespuestasResponsable> respuestasResponsable = session.Query<BE.Formularios.RespuestasResponsable>().Where(a => a.InternoRespuestaFormulario == respuestasFormulario.Interno).ToList();
                respuestasFormulario.RespuestasResponsable = respuestasResponsable;

                //Return
                return respuestasFormulario;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region ConfirmarFormulario
        public bool Confirmar(BE.Formularios.RespuestasFormulario pRespuestasFormulario)
        {
            bool ret = false;
            session.Get<BE.Formularios.RespuestasFormulario>(pRespuestasFormulario.Interno);

            ITransaction transaction = session.BeginTransaction();
            try
            {
                pRespuestasFormulario.CompletadoFechaHora = DateTime.Now;
                session.Merge(pRespuestasFormulario);

                transaction.Commit();
                session.Flush();

                return ret;
            }

            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region ConsultaFormularios
        public IList<object[]> ConsultaFormularios()
        {
            try
            {
                //RespuestasFormulario
                var consultaFormularios = session.CreateSQLQuery(
                    " SELECT {RF.*}, {RE.*}, {RD.*} " +
                    " FROM RespuestasFormulario RF, Referencia.dbo.RefEstablecimiento RE, Referencia.dbo.ReferenteDatos RD " +
                    " WHERE RF.Internoestablecimiento = RE.Interno " +
                    " AND RD.CUIT = RE.CUIT")
                .AddEntity("RF", typeof(BE.Formularios.RespuestasFormulario))
                .AddEntity("RE", typeof(BE.Formularios.RefEstablecimiento))
                .AddEntity("RD", typeof(BE.Formularios.ReferenteDatos))
                .List<object[]>();
                //Return
                //return consultaFormularios;
                return consultaFormularios;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Funciones
        private int ConvertirFecha(DateTime pFechaNormal)
        {
            DateTime FechaBase = new DateTime(1801, 01, 01);
            int FechaClarion = ((TimeSpan)(pFechaNormal - FechaBase.AddDays(-4))).Days;
            return FechaClarion;
        }
        #endregion

        #region MetodoReplicar
        /// <summary>
        /// Metodo replicar para generar una nueva instancia de un formulario, el cual copia las respuestas del 
        /// ultimo formulario confirmado
        /// </summary>
        /// <param name="pRespuestasFormulario"></param>
        /// <returns></returns>
        public BE.Formularios.RespuestasFormulario Replicar(int pInternoFormulario, int pInternoEstablecimiento)
        {
            //RespuestasFormulario
            BE.Formularios.RespuestasFormulario respuestaFormulario = session.Query<BE.Formularios.RespuestasFormulario>().Where(a => a.InternoFormulario == pInternoFormulario && a.InternoEstablecimiento == pInternoEstablecimiento).SingleOrDefault();

            if (respuestaFormulario != null)
            {
                ITransaction transaction = session.BeginTransaction();
                try
                {

                    var nuevaRespuestaFormulario = new BE.Formularios.RespuestasFormulario();
                    nuevaRespuestaFormulario.InternoFormulario = pInternoFormulario;
                    nuevaRespuestaFormulario.InternoEstablecimiento = pInternoEstablecimiento;
                    nuevaRespuestaFormulario.CreacionFechaHora = DateTime.Today;
                    nuevaRespuestaFormulario.CompletadoFechaHora = Convert.ToDateTime("1800-01-01");
                    session.Save(nuevaRespuestaFormulario);

                    int interno = nuevaRespuestaFormulario.Interno;

                    //RespuestasCuestionario
                    List<BE.Formularios.RespuestasCuestionario> respuestasCuestionario = session.Query<BE.Formularios.RespuestasCuestionario>().Where(a => a.InternoRespuestaFormulario == respuestaFormulario.Interno).ToList();
                    foreach (var item in respuestasCuestionario)
                    {
                        item.InternoRespuestaFormulario = interno;
                        session.Save(item);
                    }

                    //RespuestasGremio
                    List<BE.Formularios.RespuestasGremio> respuestasGremio = session.Query<BE.Formularios.RespuestasGremio>().Where(a => a.InternoRespuestaFormulario == respuestaFormulario.Interno).ToList();
                    foreach (var item in respuestasGremio)
                    {
                        item.InternoRespuestaFormulario = interno;

                        var respuestaGremio = session.Get<BE.Formularios.RespuestasGremio>(item.Interno);
                        if (respuestaGremio == null)
                            session.Save(item);
                        else
                            session.Merge(item);
                    }


                    //RespuestasContratista
                    List<BE.Formularios.RespuestasContratista> respuestasContratista = session.Query<BE.Formularios.RespuestasContratista>().Where(a => a.InternoRespuestaFormulario == respuestaFormulario.Interno).ToList();
                    foreach (var item in respuestasContratista)
                    {
                        item.InternoRespuestaFormulario = interno;

                        var respuestaContratista = session.Get<BE.Formularios.RespuestasContratista>(item.Interno);
                        if (respuestaContratista == null)
                            session.Save(item);
                        else
                            session.Merge(item);
                    }

                    //RespuestasResponsables
                    List<BE.Formularios.RespuestasResponsable> respuestasResponsable = session.Query<BE.Formularios.RespuestasResponsable>().Where(a => a.InternoRespuestaFormulario == respuestaFormulario.Interno).ToList();
                    foreach (var item in respuestasResponsable)
                    {
                        item.InternoRespuestaFormulario = interno;

                        var respuestaResponsable = session.Get<BE.Formularios.RespuestasResponsable>(item.Interno);
                        if (respuestaResponsable == null)
                            session.Save(item);
                        else
                            session.Merge(item);
                    }

                    transaction.Commit();
                    session.Flush();
                }
                
                catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
            }
            return respuestaFormulario;
        }
        #endregion
    }
}
