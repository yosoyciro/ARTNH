using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BE.ProveedoresCtaCte;

namespace WebApi.Controllers
{
    [RoutePrefix("api/CtaCte_Retenciones")]
    public class CtaCteRetencionesController : ApiController
    {
        [HttpGet]
        [Route("Listar_CtaCteRetenciones")]
        public IList<CtaCteRetenciones> ListarPorCtaCteProvInterno(double pInternoCtaCte)
        {
            try
            {
                return DAL.ProveedoresCuentaCorriente.CRUDCtaCteRetenciones.instancia.ListarPorCtaCteProvInterno(pInternoCtaCte);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IHttpActionResult Guardar(CtaCteRetenciones pCtaCteRet)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState); //BadRequest(ModelState);
            }
            try
            {
                DAL.ProveedoresCuentaCorriente.CRUDCtaCteRetenciones.instancia.Guardar(pCtaCteRet);
                return Content(HttpStatusCode.OK, "Registro guardado con éxito!");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.Message);
            }
        }

    }
}
