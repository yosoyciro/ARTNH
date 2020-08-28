using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NHibernate;
using BE;
using DAL;

namespace WebApi.Controllers
{
    //[Authorize]
    [RoutePrefix("api/AfiliadoDatos")]
    public class AfiliadoDatosController : ApiController
    {
        [HttpGet]
        [Route("ListarAfiliados")]
        // GET: api/GpLlamadasCat
        public List<BE.AfiliadoDatos> ListarAfiliados()
        {
            return DAL.CRUDAfiliadoDatos.instancia.ListarAfiliados();
        }

        [HttpGet]
        [Route("ListarXAfiliados")]
        // GET: api/GpLlamadasCat
        public IQueryable<BE.AfiliadoDatos> ListarXAfiliados(int pCantidad)
        {
            return DAL.CRUDAfiliadoDatos.instancia.ListarXAfiliados(pCantidad);
        }

        [HttpGet]
        [Route("BuscarPorCUIL")]
        public IHttpActionResult BuscarPorCuil(double pCUIL)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState); //BadRequest(ModelState);
            }
            try
            {
                BE.Consultas.AfiliadoDatosConsulta afiliadoDatosConsulta = CRUDAfiliadoDatos.instancia.BuscarPorCUIL(pCUIL);
                return Content(HttpStatusCode.OK, afiliadoDatosConsulta);                                
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.InnerException);
            }
        }

        [HttpGet]
        [Route("BuscarPorCUILCompleto")]
        public IHttpActionResult BuscarPorCuilCompleto(double pCUIL)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState); //BadRequest(ModelState);
            }
            try
            {
                BE.AfiliadoDatos afiliadoDatos = CRUDAfiliadoDatos.instancia.BuscarPorCUILCompleto(pCUIL);
                return Content(HttpStatusCode.OK, afiliadoDatos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.InnerException);
            }
        }

        [HttpGet]
        [Route("BuscarPorNombre")]
        public List<BE.AfiliadoDatos> BuscarPorNombre(string pNombre, int pCantidad)
        {
            return DAL.CRUDAfiliadoDatos.instancia.BuscarPorNombre(pNombre, pCantidad);
        }
        [HttpGet]
        [Route("BuscarPorInterno")]
        public BE.AfiliadoDatos BuscarPorInterno(int pInterno)
        {
            return DAL.CRUDAfiliadoDatos.instancia.BuscarPorInterno(pInterno);
        }

        [HttpPost]
        [Route("Agregar")]
        //Agregar
        public IHttpActionResult Agregar(BE.AfiliadoDatos afiliadodatos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                DAL.CRUDAfiliadoDatos.instancia.Agregar(afiliadodatos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.Message);
            }
            return Ok(afiliadodatos);
        }

        [HttpDelete]
        [Route("Borrar")]
        public bool Borrar(int pInterno)
        {
            bool r = false;
            try
            {
                r = DAL.CRUDAfiliadoDatos.instancia.Borrar(pInterno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }

        [HttpPut]
        [Route("Actualizar")]
        //Agregar
        public IHttpActionResult Actualizar(BE.AfiliadoDatos afiliadodatos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                DAL.CRUDAfiliadoDatos.instancia.Actualizar(afiliadodatos);
                return Ok(afiliadodatos);
            }
            catch (Exception)
            {
                return InternalServerError();
            }            
        }
    }
}
