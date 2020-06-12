using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BE.ProveedoresCtaCte;

namespace WebApi.Controllers
{
    [RoutePrefix("api/ProveedorCuentaCorriente")]
    public class ProveedorCuentaCorrienteController : ApiController
    {
        [HttpGet]
        [Route("ListarPorProveedor")]
        public IList<ProveedorCuentaCorriente> ListarPorProveedor(double pCUIT)
        {
            try
            {
                return DAL.ProveedoresCuentaCorriente.CRUDProveedorCuentaCorriente.instancia.ListarPorProveedor(pCUIT);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IHttpActionResult Guardar(ProveedorCuentaCorriente pProveedorCuentaCorriente)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState); //BadRequest(ModelState);
            }
            try
            {
                DAL.ProveedoresCuentaCorriente.CRUDProveedorCuentaCorriente.instancia.Guardar(pProveedorCuentaCorriente);
                return Content(HttpStatusCode.OK, "Registro guardado con éxito!");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.Message);
            }
        }
    }
}
