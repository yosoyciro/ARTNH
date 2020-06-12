using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BE.ProveedoresCtaCte;

namespace WebApi.Controllers
{
    [RoutePrefix("api/CtaCte_TiposPago")]
    public class CtaCteTiposPagoController : ApiController
    {
        [HttpGet]
        [Route("Listar_TiposPag")]
        public IList<CtaCteTiposPago> Listar()
        {            
            try
            {
                return DAL.ProveedoresCuentaCorriente.CRUDCtaCteTiposPago.instancia.Listar();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }            
        }
    }
}
