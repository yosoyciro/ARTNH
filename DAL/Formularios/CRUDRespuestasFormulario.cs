using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Formularios;
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
                    item.EstadoFecha = ConvertirFecha(DateTime.Today);

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
                    item.EstadoFecha = ConvertirFecha(DateTime.Today);

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
                    item.EstadoFecha = ConvertirFecha(DateTime.Today);

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
                    item.EstadoFecha = ConvertirFecha(DateTime.Today);

                    var respuestaResponsable = session.Get<BE.Formularios.RespuestasResponsable>(item.Interno);
                    if (respuestaResponsable == null)
                        session.Save(item);
                    else
                        session.Merge(item);
                }
                session.Flush();
                transaction.Commit();                
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
        public BE.Formularios.RespuestasFormulario TraerRespuestas(int pInternoRespuestasFormulario)
        {
            try
            {
                //Limpio el cache de la sesion por si se modifico algo por fuera
                session.Clear();

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

        #region TraerRespuestasConsulta
        public BE.Formularios.RespuestasFormulario TraerRespuestasConsulta(int pInternoRespuestasFormulario)
        {
            try
            {
                session.Clear();

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
        /// <summary>
        /// Metodo que confirma el formulario y ademas, compara las respuestas con el formulario original y pone los datos correspondientes en EstadoAccion=" ", EstadoFecha=Hoy
        /// </summary>
        /// <param name="pRespuestasFormulario"></param>
        /// <returns></returns>
        public bool Confirmar(BE.Formularios.RespuestasFormulario pRespuestasFormulario)
        {
            bool ret = false;
            session.Get<BE.Formularios.RespuestasFormulario>(pRespuestasFormulario.Interno);

            ITransaction transaction = session.BeginTransaction();
            try
            {
                pRespuestasFormulario.CompletadoFechaHora = DateTime.Now;
                session.Merge(pRespuestasFormulario);

                //Busco si es una nueva presentación y voy controlando los cambios con el formulario original
                BE.Formularios.RespuestasFormularioRel respuestasFormularioRel = session
                    .Query<BE.Formularios.RespuestasFormularioRel>()
                    .Where(r => r.InternoRespuestaFormularioNuevo == pRespuestasFormulario.Interno)
                    .SingleOrDefault();
                if (respuestasFormularioRel != null)
                {
                    #region RespuestasCuestionario
                    //Hay una presentación anterior, vamos a buscar los datos
                    //RespuestasCuestionario
                    IEnumerable<BE.Formularios.RespuestasCuestionario> respuestasCuestionarioOriginal = session
                        .Query<BE.Formularios.RespuestasCuestionario>()
                        .Where(r => r.InternoRespuestaFormulario == respuestasFormularioRel.InternoRespuestaFormularioOriginal)
                        .ToList();

                    IEnumerable<BE.Formularios.RespuestasCuestionario> respuestasCuestionarioNuevo = session
                        .Query<BE.Formularios.RespuestasCuestionario>()
                        .Where(r => r.InternoRespuestaFormulario == respuestasFormularioRel.InternoRespuestaFormularioNuevo)
                        .ToList();
                    
                    //Recorro los registros del nuevo formulario
                    foreach (var item in respuestasCuestionarioNuevo)
                    {
                        //Busco en la info original
                        BE.Formularios.RespuestasCuestionario respuestaOriginal = respuestasCuestionarioOriginal.
                            FirstOrDefault(r => r.InternoCuestionario == item.InternoCuestionario && r.InternoRespuestaFormulario == respuestasFormularioRel.InternoRespuestaFormularioOriginal);

                        item.EstadoAccion = "";
                        if (respuestaOriginal.Respuesta != item.Respuesta)
                        {
                            item.EstadoAccion = "M";
                            item.EstadoFecha = ConvertirFecha(DateTime.Today);
                            session.Save(item);
                        }                            
                    }
                    #endregion


                    #region RespuestasGremio
                    //RespuestasGremios
                    IEnumerable<BE.Formularios.RespuestasGremio> respuestasGremioOriginal = session
                        .Query<BE.Formularios.RespuestasGremio>()
                        .Where(r => r.InternoRespuestaFormulario == respuestasFormularioRel.InternoRespuestaFormularioOriginal)
                        .ToList();

                    IEnumerable<BE.Formularios.RespuestasGremio> respuestasGremioNuevo = session
                        .Query<BE.Formularios.RespuestasGremio>()
                        .Where(r => r.InternoRespuestaFormulario == respuestasFormularioRel.InternoRespuestaFormularioNuevo)
                        .ToList();

                    //Recorro los registros del nuevo formulario
                    foreach (var item in respuestasGremioNuevo)
                    {
                        //Busco en la info original
                        BE.Formularios.RespuestasGremio respuestaGremioOriginal = respuestasGremioOriginal.
                            FirstOrDefault(r => r.Renglon == item.Renglon && r.InternoRespuestaFormulario == respuestasFormularioRel.InternoRespuestaFormularioOriginal);

                        item.EstadoAccion = "";
                        if (respuestaGremioOriginal.Legajo != item.Legajo || respuestaGremioOriginal.Nombre != item.Nombre)
                        {
                            item.EstadoAccion = "M";
                            item.EstadoSituacion = " ";
                            item.EstadoFecha = ConvertirFecha(DateTime.Today);

                            //Alta
                            if (respuestaGremioOriginal.Legajo == 0 && item.Legajo != 0)
                                item.EstadoAccion = "A";

                            //Baja
                            if (respuestaGremioOriginal.Legajo != 0 && item.Legajo == 0)
                                item.EstadoAccion = "B";

                            session.Save(item);
                        }
                    }
                    #endregion

                    #region RespuestasContratista
                    //RespuestasContratistas
                    IEnumerable<BE.Formularios.RespuestasContratista> respuestasContratistaOriginal = session
                        .Query<BE.Formularios.RespuestasContratista>()
                        .Where(r => r.InternoRespuestaFormulario == respuestasFormularioRel.InternoRespuestaFormularioOriginal)
                        .ToList();

                    IEnumerable<BE.Formularios.RespuestasContratista> respuestasContratistaNuevo = session
                        .Query<BE.Formularios.RespuestasContratista>()
                        .Where(r => r.InternoRespuestaFormulario == respuestasFormularioRel.InternoRespuestaFormularioNuevo)
                        .ToList();

                    //Recorro los registros del nuevo formulario
                    foreach (var item in respuestasContratistaNuevo)
                    {
                        //Busco en la info original
                        BE.Formularios.RespuestasContratista respuestaContratistaOriginal = respuestasContratistaOriginal.
                            FirstOrDefault(r => r.Renglon == item.Renglon && r.InternoRespuestaFormulario == respuestasFormularioRel.InternoRespuestaFormularioOriginal);

                        item.EstadoAccion = "";
                        if (respuestaContratistaOriginal.CUIT != item.CUIT || respuestaContratistaOriginal.Contratista != item.Contratista)
                        {
                            item.EstadoAccion = "M";
                            item.EstadoSituacion = " ";
                            item.EstadoFecha = ConvertirFecha(DateTime.Today);

                            //Alta
                            if (respuestaContratistaOriginal.CUIT == 0 && item.CUIT != 0)
                                item.EstadoAccion = "A";

                            //Baja
                            if (respuestaContratistaOriginal.CUIT != 0 && item.CUIT == 0)
                                item.EstadoAccion = "B";

                            session.Save(item);
                        }
                    }
                    #endregion

                    #region RespuestasResponsable
                    //RespuestasResonsable
                    IEnumerable<BE.Formularios.RespuestasResponsable> respuestasResponsableOriginal = session
                        .Query<BE.Formularios.RespuestasResponsable>()
                        .Where(r => r.InternoRespuestaFormulario == respuestasFormularioRel.InternoRespuestaFormularioOriginal)
                        .ToList();

                    IEnumerable<BE.Formularios.RespuestasResponsable> respuestasResponsableNuevo = session
                        .Query<BE.Formularios.RespuestasResponsable>()
                        .Where(r => r.InternoRespuestaFormulario == respuestasFormularioRel.InternoRespuestaFormularioNuevo)
                        .ToList();

                    //Recorro los registros del nuevo formulario
                    foreach (var respuestaResponsableNueva in respuestasResponsableNuevo)
                    {
                        //Busco en la info original
                        BE.Formularios.RespuestasResponsable respuestaResponsableOriginal = respuestasResponsableOriginal.
                            FirstOrDefault(r => r.Renglon == respuestaResponsableNueva.Renglon && r.InternoRespuestaFormulario == respuestasFormularioRel.InternoRespuestaFormularioOriginal);

                        respuestaResponsableNueva.EstadoAccion = " ";
                        if (respuestaResponsableOriginal.CUIT != respuestaResponsableNueva.CUIT || respuestaResponsableOriginal.Cargo != respuestaResponsableNueva.Cargo)
                        {
                            respuestaResponsableNueva.EstadoAccion = "M";
                            respuestaResponsableNueva.EstadoSituacion = " ";
                            respuestaResponsableNueva.EstadoFecha = ConvertirFecha(DateTime.Today);

                            //Alta
                            if (respuestaResponsableOriginal.CUIT == 0 && respuestaResponsableNueva.CUIT != 0)
                                respuestaResponsableNueva.EstadoAccion = "A";

                            //Baja
                            if (respuestaResponsableOriginal.CUIT != 0 && respuestaResponsableNueva.CUIT == 0)
                                respuestaResponsableNueva.EstadoAccion = "B";

                            session.Save(respuestaResponsableNueva);
                        }
                    }

                    #endregion
                }

                session.Flush();
                transaction.Commit();                

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

        //[Pure]
        /*private static IEnumerable<T> Replace<T>(this IEnumerable<T> source, T oldValue, T newValue, IEqualityComparer<T> comparer = null)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            comparer = comparer ?? EqualityComparer<T>.Default;

            foreach (var item in source)
            {
                yield return
                    comparer.Equals(item, oldValue)
                        ? newValue
                        : item;
            }
        }*/
        #endregion

        #region MetodoReplicar
        /// <summary>
        /// Metodo replicar para generar una nueva instancia de un formulario, el cual copia las respuestas del 
        /// ultimo formulario confirmado
        /// </summary>
        /// <param name="pRespuestasFormulario"></param>
        /// <returns></returns>
        public BE.Formularios.RespuestasFormulario Replicar(int pInternoRespuestaFormulario, int pInternoEstablecimientoDestino)
        {
            ITransaction transaction = session.BeginTransaction();
            try
            {
                //BUsco RespuestasFormulario
                var respuestasFormulario = session.Get<BE.Formularios.RespuestasFormulario>(pInternoRespuestaFormulario);
                respuestasFormulario.RespuestasContratista = session.Query<BE.Formularios.RespuestasContratista>().Where(r => r.InternoRespuestaFormulario == pInternoRespuestaFormulario).ToList();
                respuestasFormulario.RespuestasCuestionario = session.Query<BE.Formularios.RespuestasCuestionario>().Where(r => r.InternoRespuestaFormulario == pInternoRespuestaFormulario).ToList();
                respuestasFormulario.RespuestasGremio = session.Query<BE.Formularios.RespuestasGremio>().Where(r => r.InternoRespuestaFormulario == pInternoRespuestaFormulario).ToList();
                respuestasFormulario.RespuestasResponsable = session.Query<BE.Formularios.RespuestasResponsable>().Where(r => r.InternoRespuestaFormulario == pInternoRespuestaFormulario).ToList();

                var nuevaRespuestaFormulario = new BE.Formularios.RespuestasFormulario
                {
                    InternoFormulario = respuestasFormulario.InternoFormulario,
                    InternoEstablecimiento = pInternoEstablecimientoDestino,
                    CreacionFechaHora = DateTime.Today,
                    CompletadoFechaHora = null,
                    NotificacionFecha = respuestasFormulario.NotificacionFecha,
                    InternoPresentacion = 0,
                    //Cuestionario, gremios, contratistas, responsables
                };                    
                               

                session.Save(nuevaRespuestaFormulario);

                //RespuestasCuestionario
                foreach (var item in respuestasFormulario.RespuestasCuestionario)
                {
                    var respuestasCuestionario = new BE.Formularios.RespuestasCuestionario
                    {
                        InternoCuestionario = item.InternoCuestionario,
                        InternoRespuestaFormulario = nuevaRespuestaFormulario.Interno,
                        Respuesta = item.Respuesta,
                        FechaRegularizacion = item.FechaRegularizacion,
                        Observaciones = item.Observaciones,
                        EstadoAccion = item.EstadoAccion,
                        EstadoFecha = item.EstadoFecha,
                        EstadoSituacion = item.EstadoSituacion,
                        BajaMotivo = item.BajaMotivo,
                    };
                    
                    session.Save(respuestasCuestionario);
                }

                //RespuestasGremio
                foreach (var item in respuestasFormulario.RespuestasGremio)
                {
                    var respuestasGremio = new BE.Formularios.RespuestasGremio
                    {
                        InternoRespuestaFormulario = nuevaRespuestaFormulario.Interno,
                        Legajo = item.Legajo,
                        Nombre = item.Nombre,
                        EstadoAccion = item.EstadoAccion,
                        EstadoFecha = item.EstadoFecha,
                        EstadoSituacion = item.EstadoSituacion,
                        BajaMotivo = item.BajaMotivo,
                        Renglon = item.Renglon,
                    };
                    session.Save(respuestasGremio);
                }

                //RespuestasContratista
                foreach (var item in respuestasFormulario.RespuestasContratista)
                {
                    var respuestasContratista = new RespuestasContratista
                    {
                        InternoRespuestaFormulario = nuevaRespuestaFormulario.Interno,
                        CUIT = item.CUIT,
                        Contratista = item.Contratista,
                        EstadoAccion = item.EstadoAccion,
                        EstadoFecha = item.EstadoFecha,
                        EstadoSituacion = item.EstadoSituacion,
                        BajaMotivo = item.BajaMotivo,
                        Renglon = item.Renglon,
                    };
                    session.Save(respuestasContratista);
                }

                //RespuestasResponsables
                foreach (var item in respuestasFormulario.RespuestasResponsable)
                {
                    var respuestasResponsable = new RespuestasResponsable
                    {
                        InternoRespuestaFormulario = nuevaRespuestaFormulario.Interno,
                        CUIT = item.CUIT,
                        Responsable = item.Responsable,
                        Cargo = item.Cargo,
                        Representacion = item.Representacion,
                        EsContratado = item.EsContratado,
                        TituloHabilitante = item.TituloHabilitante,
                        Matricula = item.Matricula,
                        EntidadOtorganteTitulo = item.EntidadOtorganteTitulo,
                        EstadoAccion = item.EstadoAccion,
                        EstadoFecha = item.EstadoFecha,
                        EstadoSituacion = item.EstadoSituacion,
                        BajaMotivo = item.BajaMotivo,
                        Renglon = item.Renglon,
                    };
                    session.Save(respuestasResponsable);
                }


                /*//RespuestasFormularioRel - Grabo la relación entre el formulario original y la nueva instancia
                var respuestasFormularioRel = new BE.Formularios.RespuestasFormularioRel
                {
                    InternoRespuestaFormularioNuevo = nuevaRespuestaFormulario.Interno,
                    InternoRespuestaFormularioOriginal = pRespuestasFormulario.Interno
                };
                session.Save(respuestasFormularioRel);*/

                session.Flush();
                transaction.Commit();

                return nuevaRespuestaFormulario;
            }
                
            catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                       
        }
        #endregion

        #region CargarFormulario
        public BE.Formularios.RespuestasFormulario CargarFormulario(int pInternoEstablecimiento, int pInternoFormulario)
        {
            IEnumerable<RespuestasFormulario> respuestaFormulario = session.Query<RespuestasFormulario>().OrderByDescending(rf => rf.CompletadoFechaHora).Where(rf => rf.InternoEstablecimiento == pInternoEstablecimiento && rf.InternoFormulario == pInternoFormulario).ToList();
            return respuestaFormulario.First();
        }
        #endregion
    }
}
