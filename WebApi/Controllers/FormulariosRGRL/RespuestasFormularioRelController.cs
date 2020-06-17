using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers.FormulariosRGRL
{
    [RoutePrefix("api/RespuestasFormularioRel")]
    public class RespuestasFormularioRelController : ApiController
    {
        [HttpGet]
        [Route("BuscarPorInternoNuevo")]
        public BE.Formularios.RespuestasFormularioRel BuscarPorInterno(int pInternoRespuestaFormularioNuevo)
        {
            return DAL.Formularios.CRUDRespuestasFormularioRel.instancia.BuscarPorInternoNuevo(pInternoRespuestaFormularioNuevo);
        }

        [HttpGet]
        [Route("BuscarPorInternoOriginal")]
        public BE.Formularios.RespuestasFormularioRel BuscarPorInternoOriginal(int pInternoRespuestaFormularioOriginal)
        {
            return DAL.Formularios.CRUDRespuestasFormularioRel.instancia.BuscarPorInternoOriginal(pInternoRespuestaFormularioOriginal);
        }
    }
}
