using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Cuestionarios")]
    public class CuestionariosController : ApiController
    {
        [HttpGet]
        [Route("ListarPorFormulario")]
        public List<BE.Formularios.Cuestionarios> ListarPorFormulario(int pInternoFormulario)
        {
            return DAL.Formularios.CRUDCuestionarios.instancia.ListarPorFormulario(pInternoFormulario);
        }

        [HttpGet]
        [Route("ListarTodas")]
        public IList<BE.Formularios.Cuestionarios> ListarTodas()
        {
            return DAL.Formularios.CRUDCuestionarios.instancia.ListarTodas();
        }
    }
}
