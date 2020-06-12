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
        [HttpGet]
        public IHttpActionResult Login(string pUsuario, string pPassword)
        {
            if (pUsuario == null || pPassword == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            
            try
            {
                var resultado = DAL.CRUDLogin.instancia.Login(pUsuario, pPassword);
                switch (resultado.Status)
                {
                    case -1:
                    case 0:
                        return Content(HttpStatusCode.NotFound, "Error en usuario/contraseña");

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
