using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL.FormRAR;
using BE.FormRAR;

namespace WebApi.Controllers.FormRAR
{
    [RoutePrefix("api/FormulariosRARDetalleAgentes")]
    public class FormulariosRARDetalleAgentesController : ApiController
    {
        [HttpPost]
        [Route("Guardar")]
        public IHttpActionResult GrabarFormulariosRARDetalleAgentes(FormulariosRARDetalleAgentes pFormulariosRARDetalleAgentes)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState); //BadRequest(ModelState);
            }
            try
            {
                FormulariosRARDetalleAgentes formulariosRARDetalleAgentes = CRUDFormulariosRARDetalleAgentes.instancia.Guardar(pFormulariosRARDetalleAgentes);
                return Content(HttpStatusCode.OK, formulariosRARDetalleAgentes);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.InnerException);
            }
        }

        [HttpGet]
        [Route("Consultar")]
        public IHttpActionResult ConsultarDetalle(int pInternoFormulariosRARDetalle)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState); //BadRequest(ModelState);
            }
            try
            {
                IList<FormulariosRARDetalleAgentes> formulariosRARDetalleAgentes = CRUDFormulariosRARDetalleAgentes.instancia.ConsultarDetalle(pInternoFormulariosRARDetalle);
                return Content(HttpStatusCode.OK, formulariosRARDetalleAgentes);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.InnerException);
            }

        }
    }
}
