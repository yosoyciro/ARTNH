using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;

namespace DAL
{
    public class CRUDAfiliadoDatos
    {
        #region Singleton
        private static ISession session;
        public static DAL.CRUDAfiliadoDatos instancia = new DAL.CRUDAfiliadoDatos();

        private CRUDAfiliadoDatos()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        #region Funciones buscar
        /// <summary>
        /// Funcion para buscar un afiliado por CUIL
        /// </summary>
        /// <param name="pCUIL"></param>
        /// <returns></returns>
        public BE.Consultas.AfiliadoDatosConsulta BuscarPorCUIL(double pCUIL)
        {
            //UInt64 cuil = Convert.ToUInt64(pCUIL);
            BE.AfiliadoDatos afiliadoDatos = new BE.AfiliadoDatos();
            try
            {
                afiliadoDatos = session.Query<BE.AfiliadoDatos>().Where(a => a.Cuil == pCUIL).SingleOrDefault();
                BE.Consultas.AfiliadoDatosConsulta afiliadoDatosConsulta = new BE.Consultas.AfiliadoDatosConsulta();
                switch (afiliadoDatos)
                {
                    case null:
                        afiliadoDatosConsulta.Nombre = "";
                        afiliadoDatosConsulta.Resultado = "La CUIL ingresada NO corresponde a una persona relacionada con esta ART";
                        break;

                    default:
                        afiliadoDatosConsulta.Nombre = afiliadoDatos.Nombre;
                        afiliadoDatosConsulta.Resultado = "La CUIL ingresada corresponde a una persona relacionada con esta ART";
                        break;
                }
                return afiliadoDatosConsulta;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                
            }
        }

        /// <summary>
        /// Funcion que devuelve todos los datos del afiliado, pasando como parametro el CUIL
        /// </summary>
        /// <param name="pCUIL"></param>
        /// <returns></returns>
        public BE.AfiliadoDatos BuscarPorCUILCompleto(double pCUIL)
        {
            //UInt64 cuil = Convert.ToUInt64(pCUIL);
            BE.AfiliadoDatos afiliadoDatos = new BE.AfiliadoDatos();
            try
            {
                afiliadoDatos = session.Query<BE.AfiliadoDatos>().Where(a => a.Cuil == pCUIL).SingleOrDefault();
                if (afiliadoDatos != null)
                {
                    if (afiliadoDatos.CodLocalidadSRT != "" || afiliadoDatos.CodLocalidadSRT != null)
                        //Localidad
                        afiliadoDatos.SRTLocalidad = session.Query<BE.Ref.SRTLocalidad>().Where(l => l.Codigo == afiliadoDatos.CodLocalidadSRT).SingleOrDefault();

                    //Empresa y NroContrato
                    var afiliadoCtaCte = session.Query<BE.AfiliadoCuentaCorriente>()
                        .Where(a => a.CuitAportante == pCUIL)
                        .OrderByDescending(a => a.Periodo)
                        .FirstOrDefault();
                    var referenteDatos = session.Query<BE.Formularios.ReferenteDatos>().FirstOrDefault(a => a.CUIT == afiliadoCtaCte.CuitContribuyente);
                    if (afiliadoCtaCte != null && referenteDatos != null)
                        afiliadoDatos.Empresa = referenteDatos.RazonSocial;
                    else
                        afiliadoDatos.Empresa = "Sin Empresa";

                    var polizaCabecera = session.Query<BE.PolizaCabecera>().OrderByDescending(a => a.Interno).FirstOrDefault(b => b.EmpleadorCUIT == referenteDatos.CUIT);
                    if (polizaCabecera != null)
                        afiliadoDatos.NroContrato = polizaCabecera.Interno;                    
                }

                

                return afiliadoDatos;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {

            }
        }

        public BE.AfiliadoDatos BuscarPorInterno(int pInterno)
        {
            try
            {
                return session.Get<BE.AfiliadoDatos>(pInterno);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<BE.AfiliadoDatos> BuscarPorInterno(int pInterno)
        //{

        //}

        /// <summary>
        /// Funcion que devuelve afiliados por nombre. Si el param nombre es vacio, devuelve los 10
        /// </summary>
        /// <param name="pNombre"></param>
        /// <param name="pCantidad"></param>
        /// <returns></returns>
        public List<BE.AfiliadoDatos> BuscarPorNombre(string pNombre, int pCantidad)
        {
            List<BE.AfiliadoDatos> afiliadodatos;
            try
            {
                if (pNombre != null)
                {
                    afiliadodatos = session.Query<BE.AfiliadoDatos>().Where(a => a.Nombre.Contains(pNombre)).ToList();
                    if (afiliadodatos.Count > 0)
                        return afiliadodatos;
                    else
                    {
                        afiliadodatos = ListarXAfiliados(pCantidad).ToList();
                        return afiliadodatos;
                    }
                }   
                else
                {
                    afiliadodatos = ListarXAfiliados(pCantidad).ToList();
                    return afiliadodatos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Funciones ABM
        public bool Borrar(int pInterno)
        {
            bool ret;
            //var afiliado = session.Query<BE.AfiliadoDatos>().FirstOrDefault(ad => ad.Interno == pInterno);
            var afiliado = session.Get<BE.AfiliadoDatos>(pInterno);
            if (afiliado == null) return false;
            ITransaction transacction = session.BeginTransaction();
            try
            {
                session.Delete(afiliado);
                transacction.Commit();
                ret = true;
            }
            catch (Exception ex)
            {
                transacction.Rollback();
                throw ex;
            }
            return ret;
        }

        /// <summary>
        /// Funcion para agregar un afiliado
        /// </summary>
        /// <param name="pAfiliadoDatos"></param>
        /// <returns></returns>
        public bool Agregar(BE.AfiliadoDatos pAfiliadoDatos)
        {
            bool ret = false;
            ITransaction transaction = session.BeginTransaction();
            try
            {
                session.Save(pAfiliadoDatos);
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

        public bool Actualizar(BE.AfiliadoDatos pAfiliadoDatos)
        {            
            bool ret = false;
            var afiliado = session.Get<BE.AfiliadoDatos>(pAfiliadoDatos.Interno);
            if (afiliado == null) return ret;

            ITransaction transacction = session.BeginTransaction();
            try
            {
                //session.Evict(pAfiliadoDatos);
                session.Merge(pAfiliadoDatos);
                transacction.Commit();
                ret = true;
            }
            catch (Exception ex)
            {
                transacction.Rollback();
                throw ex;
            }
            return ret;
        }
        #endregion

        #region Funciones listar
        //Funcion listar todos
        public List<BE.AfiliadoDatos> ListarAfiliados()
        {
            List<BE.AfiliadoDatos> afiliados = session.Query<BE.AfiliadoDatos>().ToList();
            return afiliados;
        }


        //Funcion listar x afiliados
        public IQueryable<BE.AfiliadoDatos> ListarXAfiliados(int pCantidad)
        {
            IQueryable<BE.AfiliadoDatos> afiliados = session.Query<BE.AfiliadoDatos>().OrderBy(a => a.Nombre).Take(pCantidad);
            return afiliados;
        }
        #endregion
    }
}
