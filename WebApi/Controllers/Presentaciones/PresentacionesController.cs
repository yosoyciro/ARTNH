using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers.Presentaciones
{
    [RoutePrefix("api/Presentaciones")]
    public class PresentacionesController : ApiController
    {
        [HttpGet]
        [Route("Listar")]
        public IList<BE.Formularios.Presentaciones> Listar(double pCUIT)
        {
            return DAL.Formularios.CRUDPresentaciones.instancia.Listar(pCUIT);
        }

        [HttpGet]
        [Route("VerificarPresentacion")]
        public BE.Formularios.Presentaciones VerificarPresentacion(double pCUIT, string pTipo)
        {
            return DAL.Formularios.CRUDPresentaciones.instancia.VerificarPresentacion(pCUIT, pTipo);
        }

        [HttpGet]
        [Route("VerificarCompletados")]
        public bool VerificarCompletados(double pCUIT, string pTipo)
        {
            return DAL.Formularios.CRUDPresentaciones.instancia.VerificarCompletados(pCUIT, pTipo);
        }

        [HttpPost]
        [Route("Generar")]
        public BE.Formularios.Presentaciones BuscarPorInternoOriginal(BE.Formularios.Presentaciones pPresentacion)
        {
            return DAL.Formularios.CRUDPresentaciones.instancia.Generar(pPresentacion);
        }
    }
}
