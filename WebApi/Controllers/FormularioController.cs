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
    [RoutePrefix("api/Formulario")]
    public class FormularioController : ApiController
    {
        [HttpGet]
        [Route("Listar")]
        public IHttpActionResult Listar()
        {
            try
            {
                List<Formularios> formularios = CRUDFormulario.instancia.Listar();
                return Content(HttpStatusCode.OK, formularios);
            }

            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.InnerException.Message);
            }
            
        }

        [HttpGet]
        [Route("ListarDisponibles")]
        public IHttpActionResult ListarDisponibles(int pInternoEstablecimiento)
        {
            try
            {
                List<Formularios> formularios = CRUDFormulario.instancia.ListarDisponibles(pInternoEstablecimiento);
                return Content(HttpStatusCode.OK, formularios);
            }

            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.InnerException.Message);
            }

        }
    }
}
