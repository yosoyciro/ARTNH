using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BE.FormRAR;
using DAL.FormRAR;

namespace WebApi.Controllers.FormRAR
{
    [RoutePrefix("api/FormulariosRAR")]
    public class FormulariosRARController : ApiController
    {
        [HttpPost]
        [Route("Guardar")]
        public IHttpActionResult GrabarFormulariosRAR(FormulariosRAR pFormulariosRAR)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState); //BadRequest(ModelState);
            }
            try
            {                
                FormulariosRAR formulariosRAR = CRUDFormulariosRAR.instancia.Guardar(pFormulariosRAR);
                return Content(HttpStatusCode.OK, formulariosRAR);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.InnerException);
            }

        }

        [HttpPost]
        [Route("Confirmar")]
        public IHttpActionResult ConfirmarFormularioRAR(int pInternoFormulariosRAR)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState); //BadRequest(ModelState);
            }
            try
            {
                bool ret = CRUDFormulariosRAR.instancia.Confirmar(pInternoFormulariosRAR);
                return Content(HttpStatusCode.OK, ret);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.InnerException);
            }

        }

        [HttpGet]
        [Route("Consultar")]
        public IHttpActionResult ConsultarEnProcesoCarga(int pInternoEstablecimiento)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState); //BadRequest(ModelState);
            }
            try
            {
                IList<FormulariosRAR> formulariosRAR = CRUDFormulariosRAR.instancia.ConsultarEnProcesoCarga(pInternoEstablecimiento);
                return Content(HttpStatusCode.OK, formulariosRAR);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.InnerException);
            }

        }

        [HttpPost]
        [Route("Borrar")]
        public IHttpActionResult BorrarFormularioRAR(FormulariosRAR pFormulariosRAR)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState); //BadRequest(ModelState);
            }
            try
            {
                bool ret = CRUDFormulariosRAR.instancia.Borrar(pFormulariosRAR);
                return Content(HttpStatusCode.OK, ret);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.InnerException);
            }

        }
    }
}
