using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SL
{
    public class MapDenuncia : ClassMapping<BE.Denuncia>
    {
        public MapDenuncia()
        {
            Id(x => x.Interno, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            Property(p => p.EmpCuit);
            Property(p => p.EmpPoliza);
            Property(p => p.EmpRazonSocial);
            Property(p => p.EmpCIIU);
            Property(p => p.EmpDomicilio);
            Property(p => p.EmpCodLocalidad);
            Property(p => p.EmpTelefonos);
            Property(p => p.EmpeMail);
            Property(p => p.EmpOcCUIT);
            Property(p => p.EmpOcRazonSocial);
            Property(p => p.EmpOcEstablecimiento);
            Property(p => p.EmpOcCIIU);
            Property(p => p.EmpOcDomicilio);
            Property(p => p.EmpOcSubContrato);
            Property(p => p.AfiCUIL);
            Property(p => p.AfiDocTipo);
            Property(p => p.AfiDocNumero);
            Property(p => p.AfiNombre);
            Property(p => p.AfiFechaNacimiento);
            Property(p => p.AfiSexo);
            Property(p => p.AfiEstadoCivil);
            Property(p => p.AfiNacionalidad);
            Property(p => p.AfiDomicilio);
            Property(p => p.AfiCodLocalidad);
            Property(p => p.AfieMail);
            Property(p => p.AfiIngresoEmpresa);
            Property(p => p.AfiIngresoEstablecimiento);
            Property(p => p.AfiRemuneracion);
            Property(p => p.AfiManoHabil);
            Property(p => p.AfiJornadaHabitual);
            Property(p => p.AfiSituacionContractual);
            Property(p => p.AfiUltimoExamenPeriodico);
            Property(p => p.AfiObraSocial);
            Property(p => p.AfiPuestoTrabajoAct);
            Property(p => p.AfiPuestoTrabajoActAntiguedad);
            Property(p => p.AfiPuestoTrabajoAnt);
            Property(p => p.AfiPuestoTrabajoAntAntiguedad);
            Property(p => p.AfiCBU);
            Property(p => p.SiniestroOcasion);
            Property(p => p.SiniestroDescripcion);
            Property(p => p.SiniestroFecha);
            Property(p => p.SiniestroHora);
            Property(p => p.SiniestroHorarioJornada);
            Property(p => p.SiniestroTareaHabitual);
            Property(p => p.SiniestroFechaInasistencia);
            Property(p => p.SiniestroAgenteMaterial);
            Property(p => p.SiniestroDiagnostico1);
            Property(p => p.SiniestroDiagnostico2);
            Property(p => p.SiniestroDiagnostico3);
            Property(p => p.SiniestroNaturalezaLesion1);
            Property(p => p.SiniestroNaturalezaLesion2);
            Property(p => p.SiniestroNaturalezaLesion3);
            Property(p => p.SiniestroFormaAccidente);
            Property(p => p.SiniestroZonaCuerpo1);
            Property(p => p.SiniestroZonaCuerpo2);
            Property(p => p.SiniestroZonaCuerpo3);
            Property(p => p.PrestadorCUIT);
            Property(p => p.PrestadorRazonSocial);
            Property(p => p.PrestadorDomicilio);
            Property(p => p.PrestadorCodLocalidad);
            Property(p => p.PrestadorTelefonos);
            Property(p => p.PrestadoreMail);
            Property(p => p.PresentacionFecha);
            Property(p => p.PresentacionHora);
            Property(p => p.PresentacionDenuncianteCUIL);
            Property(p => p.PresentacionDenuncianteNombre);
            Property(p => p.PresentacionDenuncianteFirma);
            Property(p => p.PresentacionFormulario);
        }
    }
}
