using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/RefReclamoConsulta")]
    public class RefReclamoConsultaController : ApiController
    {

        [HttpPost]
        [Route("RefReclamoConsultaAgregar")]
        //Agregar
        public IHttpActionResult Agregar(BE.ReclamoConsulta rec)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DAL.CRUDReclamoConsulta oCRUDRec = new DAL.CRUDReclamoConsulta();
            try
            {
                oCRUDRec.Agregar(rec);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(rec);
        }
    }
}
