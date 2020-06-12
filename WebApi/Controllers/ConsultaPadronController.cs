using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Padron")]
    public class ConsultaPadronController : ApiController
    {
        [HttpGet]
        [Route("ConsultaPadron")]
        public IHttpActionResult ConsultaPadron(Int64 pCUIT)
        {
            BE.Persona persona = new BE.Persona();
            try
            {
                //BLL.ConsultarPadron.DameInstancia().ConsultaPadron(pCUIT, persona);
                //BLL.ConsultarPadron.instancia.ConsultaPadron(pCUIT, persona);
                PadronAFIP.ConsultarPadron oConsultarPadron = new PadronAFIP.ConsultarPadron();
                oConsultarPadron.ConsultaPadron(pCUIT, persona);
                return Ok(persona);
            }

            catch (Exception ex)
            {
                throw ex;
            }

            
        }
    }
}
