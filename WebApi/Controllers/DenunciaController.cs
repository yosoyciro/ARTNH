using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NHibernate;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Denuncia")]
    public class DenunciaController : ApiController
    {
        [HttpGet]
        [Route("DenunciaVerTodas")]
        public IQueryable<BE.Denuncia> ListarTodas()
        {
            DAL.CRUDDenuncia oCRUDDenuncia = new DAL.CRUDDenuncia();
            //return DAL.CRUDDenuncia.instancia.ListarTodas();
            return oCRUDDenuncia.ListarTodas();          
            
        }

        [HttpGet]
        [Route("DenunciaBuscarPorNumero")]
        public BE.Denuncia BuscarPorNumero(int pInterno)
        {
            //return DAL.CRUDDenuncia.instancia.BuscarPorNumero(pInterno);
            DAL.CRUDDenuncia oCRUDDenuncia = new DAL.CRUDDenuncia();
            return oCRUDDenuncia.BuscarPorNumero(pInterno);
            
        }

        [HttpPost]
        [Route("DenunciaAgregar")]
        //Agregar
        public IHttpActionResult Agregar(BE.Denuncia denuncia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DAL.CRUDDenuncia oCRUDDenuncia = new DAL.CRUDDenuncia();
            try
            {
                oCRUDDenuncia.Agregar(denuncia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(denuncia);
        }
    }
}


