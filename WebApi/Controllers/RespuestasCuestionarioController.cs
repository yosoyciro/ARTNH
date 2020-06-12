using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/RespuestasCuestionario")]
    public class RespuestasCuestionarioController : ApiController
    {
        [HttpPost]
        [Route("GrabarRespuestasCuestionario")]
        public IHttpActionResult GrabarRespuestasFormulario(List<BE.Formularios.RespuestasCuestionario> pRespuestasCuestionario)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState); //BadRequest(ModelState);
            }
            try
            {
                //DAL.Formularios.CRUDRespuestasCuestionarios.instancia.GrabarRespuestasCuestionario(pRespuestasCuestionario);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.Message);
            }
            return Ok();
        }

        [HttpGet]
        [Route("RecuperarRespuestas")]
        public IList<BE.Formularios.RespuestasCuestionario> RecuperarRespuestas(int pInternoFormulario, int pInternoEstablecimiento)
        {
            return DAL.Formularios.CRUDRespuestasCuestionarios.instancia.RecuperarRespuestas(pInternoFormulario, pInternoEstablecimiento);
        }
    }
}
