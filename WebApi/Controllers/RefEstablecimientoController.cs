using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/RefEstablecimiento")]
    public class RefEstablecimientoController : ApiController
    {
        [HttpGet]
        [Route("ListarPorCuit")]
        public List<BE.Formularios.RefEstablecimiento> ListarPorCuit(double pCuit)
        {
            return DAL.Formularios.CRUDRefEstablecimiento.instancia.ListarPorCuit(pCuit);
        }

        [HttpGet]
        [Route("ListarPorInterno")]
        public BE.Formularios.RefEstablecimiento ListarPorInterno(int pInternoEstablecimiento)
        {
            return DAL.Formularios.CRUDRefEstablecimiento.instancia.ListarPorInterno(pInternoEstablecimiento);
        }

        [HttpPut]
        [Route("Actualizar")]
        public IHttpActionResult Actualizar(int pInternoEstablecimiento, [FromBody] BE.Formularios.RefEstablecimientoActualizar pRefEstablecimientoActualizar)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState); //BadRequest(ModelState);
            }

            try
            {
                DAL.Formularios.CRUDRefEstablecimiento.instancia.Actualizar(pInternoEstablecimiento, pRefEstablecimientoActualizar);

                return Content(HttpStatusCode.OK, "Datos actualizados!");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.Message);
            }
            
        }
    }
}
