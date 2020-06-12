using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL.Ref;
using BE.Ref;

namespace WebApi.Controllers.Ref
{
    [RoutePrefix("api/RefAgenteCausante")]
    public class RefAgenteCausanteController : ApiController
    {        
        [HttpGet]
        [Route("Consultar")]
        public IHttpActionResult Consultar()
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState); //BadRequest(ModelState);
            }
            try
            {
                IList<SRTSiniestralidadAgenteCausante> refAgenteCausante = CRUDRefAgenteCausante.instancia.Consultar();
                return Content(HttpStatusCode.OK, refAgenteCausante);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.InnerException);
            }

        }
    }
}
