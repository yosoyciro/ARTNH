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
    [RoutePrefix("api/FormulariosCargados")]
    public class FormulariosCargadosController : ApiController
    {
        [HttpGet]
        [Route("Consultar")]
        public IHttpActionResult Listar()
        {
            try
            {
                IList<BE.Formularios.FormulariosCargados> formulariosCargados = DAL.Formularios.FormulariosCargados.instancia.ConsultaFormulariosCargados();
                return Content(HttpStatusCode.OK, formulariosCargados);
            }

            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.InnerException.Message);
            }

        }
    }
}
