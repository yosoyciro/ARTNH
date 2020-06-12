using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BE.ProveedoresCtaCte;

namespace WebApi.Controllers
{
    [RoutePrefix("api/CtaCte_Pagos")]
    public class CtaCtePagosController : ApiController
    {
        [HttpGet]
        [Route("Listar_CtaCtePagos")]
        public IList<CtaCtePagos> ListarPorCtaCteProvInterno(double pInternoCtaCte)
        {
            try
            {
                return DAL.ProveedoresCuentaCorriente.CRUDCtaCtePagos.instancia.ListarPorCtaCteProvInterno(pInternoCtaCte);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IHttpActionResult Guardar(CtaCtePagos pCtaCtePagos)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState); //BadRequest(ModelState);
            }
            try
            {
                DAL.ProveedoresCuentaCorriente.CRUDCtaCtePagos.instancia.Guardar(pCtaCtePagos);
                return Content(HttpStatusCode.OK, "Registro guardado con éxito!");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.Message);
            }
        }

    }
}
