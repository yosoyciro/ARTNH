using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers.Usuario
{
    [RoutePrefix("api/AutParametro")]
    public class UsuarioController : ApiController
    {
        [HttpGet]
        [Route("Buscar")]
        public BE.Usuario.AutParametro Buscar(int pParametro)
        {
            return DAL.Usuario.CRUDAutParametro.instancia.Buscar(pParametro);
        }

        [HttpDelete]
        [Route("Borrar")]
        public bool Borrar(int pInterno)
        {
            return DAL.Usuario.CRUDAutParametro.instancia.Borrar(pInterno);
        }
    }
}
