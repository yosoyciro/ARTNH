using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BE.ProveedoresCtaCte;

namespace WebApi.Controllers
{
    [RoutePrefix("api/CtaCte_TiposRetencion")]
    public class CtaCteTiposRetencionController : ApiController
    {
        [HttpGet]
        [Route("Listar_TiposRet")]
        public IList<CtaCteTiposRetencion> Listar()
        {            
            try
            {
                return DAL.ProveedoresCuentaCorriente.CRUDCtaCteTiposRetencion.instancia.Listar();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }            
        }
    }
}
