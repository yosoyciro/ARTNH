using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/RefReclamoConsultaContacto")]
    public class RefReclamoConsultaContactoController : ApiController
    {

        [HttpGet]
        [Route("GetRefReclamoConsultaContacto")]
        public IQueryable<BE.ReclamoConsultaContacto> ListarTodas()
        {
            DAL.CRUDRefReclamoConsultaContacto rec = new DAL.CRUDRefReclamoConsultaContacto();
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
        [Route("RefReclamoConsultaContactoAgregar")]
        //Agregar
        public IHttpActionResult Agregar(BE.ReclamoConsultaContacto rec)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DAL.CRUDRefReclamoConsultaContacto oCRUDRec = new DAL.CRUDRefReclamoConsultaContacto();
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
