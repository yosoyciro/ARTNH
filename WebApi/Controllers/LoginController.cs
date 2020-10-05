using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        [Route("Login")]
        [HttpPost]
        public IHttpActionResult Login([FromBody] BE.Usuarios usuario)
        {
            if (usuario.Usuario == null || usuario.Password == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            
            try
            {
                var resultado = DAL.CRUDLogin.instancia.Login(usuario.Usuario, usuario.Password);
                switch (resultado.Status)
                {
                    case -1:
                    case 0:
                        return Content(HttpStatusCode.NotFound, "Error en CUIT/Password");

                    default:
                        return Content(HttpStatusCode.OK, resultado);
                }
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.InnerException.Message);
            }
        }

        [HttpGet]
        [Route("Estado")]
        public IHttpActionResult Estado()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" Usuario: {identity.Name} - Logueado: {identity.IsAuthenticated}");
        }
    }
}
