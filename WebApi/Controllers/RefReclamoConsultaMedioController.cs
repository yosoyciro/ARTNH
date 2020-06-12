using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/RefReclamoConsultaMedio")]
    public class RefReclamoConsultaMedioController : ApiController
    {

        [HttpGet]
        [Route("GetRefReclamoConsultaMedio")]
        public IQueryable<BE.ReclamoConsultaMedio> ListarTodas()
        {
            DAL.CRUDRefReclamoConsultaMedio rec = new DAL.CRUDRefReclamoConsultaMedio();
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
        [Route("RefReclamoConsultaMedioAgregar")]
        //Agregar
        public IHttpActionResult Agregar(BE.ReclamoConsultaMedio rec)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DAL.CRUDRefReclamoConsultaMedio oCRUDRec = new DAL.CRUDRefReclamoConsultaMedio();
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
