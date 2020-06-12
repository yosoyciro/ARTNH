using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/AfiliadoCtaCte")]
    public class AfiliadoCtaCteController : ApiController
    {
        [HttpGet]
        [Route("CtaCte")]
        public List<BE.AfiliadoCuentaCorriente> BuscarPorInterno(double pCUIL)
        {
            return DAL.CRUDAfiliadoCtaCte.instancia.BuscarPorAfiliado(pCUIL);
        }
    }
}
