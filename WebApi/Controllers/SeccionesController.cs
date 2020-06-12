using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Secciones")]
    public class SeccionesController : ApiController
    {
        [HttpGet]
        [Route("ListarSeccionesFormulario")]
        public List<BE.Formularios.Secciones> ListarSeccionesFormulario(int pInternoFormulario)
        {
            return DAL.Formularios.CRUDSecciones.instancia.ListarSeccionesFormulario(pInternoFormulario);
        }

        [HttpGet]
        [Route("SeccionesFormulario")]
        public IList<int> SeccionesFormulario(int pInternoFormulario)
        {
            return DAL.Formularios.CRUDSecciones.instancia.SeccionesFormulario(pInternoFormulario);
        }

        [HttpGet]
        [Route("ListarTodas")]
        public IList<BE.Formularios.Secciones> ListarTodas()
        {
            return DAL.Formularios.CRUDSecciones.instancia.ListarTodas();
        }
    }
}
