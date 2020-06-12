using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/RefReclamoConsultaResponder")]
    public class RefReclamoConsultaResponderController : ApiController
    {

        [HttpGet]
        [Route("GetRefReclamoConsulta")]
        public IQueryable<BE.ReclamoConsultaResponder> ListarTodas()
        {
            DAL.CRUDRefReclamoConsultaResponder rec = new DAL.CRUDRefReclamoConsultaResponder();
            return rec.ListarTodas();

        }

        /*
        [HttpGet]
        [Route("DenunciaBuscarPorNumero")]
        public BE.Denuncia BuscarPorNumero(int pInterno)
        {
            //return DAL.CRUDDenuncia.instancia.BuscarPorNumero(pInterno);
            DAL.CRUDDenuncia oCRUDDenuncia = new DAL.CRUDDenuncia();
            return oCRUDDenuncia.BuscarPorNumero(pInterno);

        }*/

        [HttpPost]
        [Route("RefReclamoConsultaResponderAgregar")]
        //Agregar
        public IHttpActionResult Agregar(BE.ReclamoConsultaResponder rec)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DAL.CRUDRefReclamoConsultaResponder oCRUDRec = new DAL.CRUDRefReclamoConsultaResponder();
            try
            {
                oCRUDRec.Agregar(rec);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(rec);
        }
    }
}
