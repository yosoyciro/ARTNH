using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers.FormRAR
{
    [RoutePrefix("api/FormulariosRARCargados")]
    public class FormulariosRARCargadosController : ApiController
    {
        [HttpGet]
        [Route("ConsultarCargados")]
        public IHttpActionResult ConsultarRARCargados(double pCUIT)
        {
            try
            {
                IList<BE.FormRAR.FormulariosRARCargados> formulariosRARCargados = DAL.FormRAR.FormulariosRARCargados.instancia.ConsultarFormulariosRARCargados(pCUIT);
                return Content(HttpStatusCode.OK, formulariosRARCargados);
            }

            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message + '-' + e.InnerException.Message);
            }

        }
    }
}
