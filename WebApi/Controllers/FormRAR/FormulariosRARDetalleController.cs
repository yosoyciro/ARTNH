using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BE.FormRAR;
using DAL.FormRAR;

namespace WebApi.Controllers.FormRAR
{
    [RoutePrefix("api/FormulariosRARDetalle")]
    public class FormulariosRARDetalleController : ApiController
    {
        [HttpPost]
        [Route("Guardar")]
        public IHttpActionResult GrabarFormularioRARDetalle(FormulariosRARDetalle pFormulariosRARDetalle)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState); //BadRequest(ModelState);
            }
            try
            {
                FormulariosRARDetalle formulariosRARDetalle = CRUDFormulariosRARDetalle.instancia.Guardar(pFormulariosRARDetalle);
                return Content(HttpStatusCode.OK, formulariosRARDetalle);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.InnerException);
            }

        }

        [HttpPost]
        [Route("Borrar")]
        public IHttpActionResult BorrarFormularioRARDetalle(int pInternoFormularioRARDetalle)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState); //BadRequest(ModelState);
            }
            try
            {
                bool ret = CRUDFormulariosRARDetalle.instancia.Borrar(pInternoFormularioRARDetalle);
                return Content(HttpStatusCode.OK, "Registro borrado");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.InnerException);
            }

        }

        [HttpGet]
        [Route("Consultar")]
        public async Task<IHttpActionResult> ConsultarFormularioRARDetalle(int pInternoFormularioRAR)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState); //BadRequest(ModelState);
            }
            try
            {
                IList<FormulariosRARDetalle> formulariosRARDetalle = await CRUDFormulariosRARDetalle.instancia.Consultar(pInternoFormularioRAR);
                return Content(HttpStatusCode.OK, formulariosRARDetalle);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.InnerException.InnerException);
            }

        }
    }
}
