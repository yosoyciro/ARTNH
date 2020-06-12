using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/ReferenteDatos")]
    public class ReferenteDatosController : ApiController
    {
        [HttpGet]
        [Route("ListarPorCuit")]
        public IHttpActionResult ListarPorCuit(double pCuit)
        {
            try
            {
                List<BE.Formularios.ReferenteDatos> referenteDatos = DAL.Formularios.CRUDReferenteDatos.instancia.ListarPorCuit(pCuit);
                if (referenteDatos == null)
                    return Content(HttpStatusCode.NotFound, referenteDatos);
                else
                    return Content(HttpStatusCode.OK, referenteDatos);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.InnerException.Message);
            }
            
        }
    }
}
