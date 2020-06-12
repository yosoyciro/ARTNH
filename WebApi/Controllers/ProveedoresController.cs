using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BE.ProveedoresCtaCte;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Proveedores")]
    public class ProveedoresController : ApiController
    {
        [HttpGet]
        [Route("Listar")]
        public IList<Proveedores> Listar()
        {            
            try
            {
                return DAL.ProveedoresCuentaCorriente.CRUDProveedores.instancia.Listar();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }            
        }

        [HttpGet]
        [Route("BuscarPorCUIT")]
        public List<BE.ProveedoresCtaCte.Proveedores> BuscarPorCuit(double pCUIT)
        {
            return DAL.ProveedoresCuentaCorriente.CRUDProveedores.instancia.BuscarPorCUIT(pCUIT);
        }
    }
}
