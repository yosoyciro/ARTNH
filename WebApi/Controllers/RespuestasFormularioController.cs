using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BE.Formularios;
using DAL.Formularios;

namespace WebApi.Controllers
{
    [RoutePrefix("api/RespuestasFormulario")]
    public class RespuestasFormularioController : ApiController
    {
        //Metodo unico de grabacion de la cabecera de la respuesta, cuestionarios, responsables, etc
        [HttpPost]
        [Route("GrabarRespuestasFormularios")]
        public IHttpActionResult GrabarRespuestasFormulario(RespuestasFormulario pRespuestasFormulario)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState); //BadRequest(ModelState);
            }
            try
            {
                //RespuestasFormulario
                int internoRespuestasFormulario = CRUDRespuestasFormulario.instancia.Agregar(pRespuestasFormulario);
                return Content(HttpStatusCode.OK, internoRespuestasFormulario);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.InnerException);
            }
            
        }

        [HttpPost]
        [Route("ConfirmarFormulario")]
        public IHttpActionResult ConfirmarFormulario(RespuestasFormulario pRespuestasFormulario)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState); //BadRequest(ModelState);
            }
            try
            {
                //RespuestasFormulario
                bool ret = CRUDRespuestasFormulario.instancia.Confirmar(pRespuestasFormulario);
                return Content(HttpStatusCode.OK, pRespuestasFormulario);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.InnerException);
            }
        }

        [HttpGet]
        [Route("TraerRespuestas")]
        public IHttpActionResult TraerRespuestas(int pInternoRespuestasFormulario)
        {
            try
            {
                //RespuestasFormulario
                BE.Formularios.RespuestasFormulario respuestasFormulario = CRUDRespuestasFormulario.instancia.TraerRespuestas(pInternoRespuestasFormulario);
                if (respuestasFormulario != null)
                    return Content(HttpStatusCode.OK, respuestasFormulario);

                else
                    return Content(HttpStatusCode.NotFound, respuestasFormulario);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.Message);
            }
        }

        [HttpGet]
        [Route("TraerRespuestasConsulta")]
        public IHttpActionResult TraerRespuestasConsulta(int pInternoRespuestaFormulario)
        {
            try
            {
                //RespuestasFormulario
                BE.Formularios.RespuestasFormulario respuestasFormulario = CRUDRespuestasFormulario.instancia.TraerRespuestasConsulta(pInternoRespuestaFormulario);
                if (respuestasFormulario != null)
                    return Content(HttpStatusCode.OK, respuestasFormulario);

                else
                    return Content(HttpStatusCode.NotFound, respuestasFormulario);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.Message);
            }
        }

        [HttpGet]
        [Route("ConsultaFormulariosCargados")]
        public IHttpActionResult ConsultaFormularios()
        {
            try
            {
                var respuestasFormulario = CRUDRespuestasFormulario.instancia.ConsultaFormularios();
                if (respuestasFormulario != null)
                    return Content(HttpStatusCode.OK, respuestasFormulario);

                else
                    return Content(HttpStatusCode.NotFound, respuestasFormulario);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.Message);
            }
        }

        [HttpPost]
        [Route("ReplicarFormulario")]
        public IHttpActionResult ReplicarFormulario(int pInternoRespuestaFormulario, int pInternoEstablecimientoDestino)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState); //BadRequest(ModelState);
            }
            try
            {
                //RespuestasFormulario
                RespuestasFormulario respuestasFormulario = CRUDRespuestasFormulario.instancia.Replicar(pInternoRespuestaFormulario, pInternoEstablecimientoDestino);
                return Content(HttpStatusCode.OK, respuestasFormulario);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.Message);
            }
        }

        [HttpGet]
        [Route("CargarFormulario")]
        public IHttpActionResult CargarFormulario(int pInternoEstablecimiento, int pInternoFormulario)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState); //BadRequest(ModelState);
            }
            try
            {
                //RespuestasFormulario
                RespuestasFormulario respuestasFormulario = CRUDRespuestasFormulario.instancia.CargarFormulario(pInternoEstablecimiento, pInternoFormulario);
                return Content(HttpStatusCode.OK, respuestasFormulario);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.Message);
            }
        }

        [HttpGet]
        [Route("VerificarDuplicado")]
        public IHttpActionResult VerificarDuplicado(int pInternoEstablecimiento, int pInternoFormulario)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState); //BadRequest(ModelState);
            }
            try
            {
                //RespuestasFormulario
                RespuestasFormulario respuestasFormulario = CRUDRespuestasFormulario.instancia.VerificarDuplicado(pInternoEstablecimiento, pInternoFormulario);
                return Content(HttpStatusCode.OK, respuestasFormulario);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.Message);
            }
        }
    }
}
