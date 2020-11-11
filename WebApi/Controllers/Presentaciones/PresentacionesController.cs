using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace WebApi.Controllers.Presentaciones
{
    [RoutePrefix("api/Presentaciones")]
    public class PresentacionesController : ApiController
    {
        [HttpGet]
        [Route("Listar")]
        public async Task<IEnumerable<BE.Formularios.Presentaciones>> Listar(double pCUIT, string pTipo)
        {
            return await DAL.Formularios.CRUDPresentaciones.instancia.Listar(pCUIT, pTipo);
        }

        [HttpGet]
        [Route("VerificarPresentacion")]
        public Task<bool> VerificarPresentacion(double pCUIT, string pNombre, string pTipo)
        {
            return DAL.Formularios.CRUDPresentaciones.instancia.VerificarPresentacion(pCUIT, pNombre, pTipo);
        }

        [HttpGet]
        [Route("VerificarCompletados")]
        public Task<bool> VerificarCompletados(double pCUIT, string pTipo)
        {
            return DAL.Formularios.CRUDPresentaciones.instancia.VerificarCompletados(pCUIT, pTipo);
        }

        [HttpPost]
        [Route("Generar")]
        public async Task<BE.Formularios.Presentaciones> Generar(BE.Formularios.Presentaciones pPresentacion)
        {
            return await DAL.Formularios.CRUDPresentaciones.instancia.Generar(pPresentacion);
        }
    }
}
