using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/RefReclamoConsultaDetalle")]
    public class RefReclamoConsultaDetalleController : ApiController
    {

        [HttpGet]
        [Route("GetRefReclamoConsultaDetalle")]
        public IQueryable<BE.ReclamoConsultaDetalle> ListarTodas()
        {
            DAL.CRUDRefReclamoConsultaDetalle rec = new DAL.CRUDRefReclamoConsultaDetalle();
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
        [Route("RefReclamoConsultaDetalleAgregar")]
        //Agregar
        public IHttpActionResult Agregar(BE.ReclamoConsultaDetalle rec)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DAL.CRUDRefReclamoConsultaDetalle oCRUDRec = new DAL.CRUDRefReclamoConsultaDetalle();
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
