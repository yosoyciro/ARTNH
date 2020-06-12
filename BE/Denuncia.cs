using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Denuncia
    {
        public Denuncia()
        {
        }

        public virtual int Interno { get; set; }
        public virtual double EmpCuit { get; set; }
        public virtual double EmpPoliza { get; set; }
        public virtual string EmpRazonSocial { get; set; }
        public virtual int EmpCIIU { get; set; }
        public virtual string EmpDomicilio { get; set; }
        public virtual int EmpCodLocalidad { get; set; }
        public virtual string EmpTelefonos { get; set; }
        public virtual string EmpeMail { get; set; }
        public virtual double EmpOcCUIT { get; set; }
        public virtual string EmpOcRazonSocial { get; set; }
        public virtual string EmpOcEstablecimiento { get; set; }
        public virtual int EmpOcCIIU { get; set; }
        public virtual string EmpOcDomicilio { get; set; }
        public virtual string EmpOcSubContrato { get; set; }
        public virtual double AfiCUIL { get; set; }
        public virtual string AfiDocTipo { get; set; }
        public virtual double AfiDocNumero { get; set; }
        public virtual string AfiNombre { get; set; }
        public virtual int AfiFechaNacimiento { get; set; }
        public virtual string AfiSexo { get; set; }
        public virtual string AfiEstadoCivil { get; set; }
        public virtual int AfiNacionalidad { get; set; }
        public virtual string AfiDomicilio { get; set; }
        public virtual int AfiCodLocalidad { get; set; }
        public virtual string AfieMail { get; set; }
        public virtual int AfiIngresoEmpresa { get; set; }
        public virtual int AfiIngresoEstablecimiento { get; set; }
        public virtual double AfiRemuneracion { get; set; }
        public virtual string AfiManoHabil { get; set; }
        public virtual string AfiTurnoHabitual { get; set; }
        public virtual string AfiJornadaHabitual { get; set; }
        public virtual string AfiSituacionContractual { get; set; }
        public virtual int AfiUltimoExamenPeriodico { get; set; }
        public virtual int AfiObraSocial { get; set; }
        public virtual string AfiPuestoTrabajoAct { get; set; }
        public virtual string AfiPuestoTrabajoActAntiguedad { get; set; }
        public virtual string AfiPuestoTrabajoAnt { get; set; }
        public virtual string AfiPuestoTrabajoAntAntiguedad { get; set; }
        public virtual double AfiCBU { get; set; }
        public virtual string SiniestroOcasion { get; set; }
        public virtual string SiniestroDescripcion { get; set; }
        public virtual int SiniestroFecha { get; set; }
        public virtual int SiniestroHora { get; set; }
        public virtual string SiniestroHorarioJornada { get; set; }
        public virtual string SiniestroTareaHabitual { get; set; }
        public virtual int SiniestroFechaInasistencia { get; set; }
        public virtual int SiniestroAgenteMaterial { get; set; }
        public virtual int SiniestroDiagnostico1 { get; set; }
        public virtual int SiniestroDiagnostico2 { get; set; }
        public virtual int SiniestroDiagnostico3 { get; set; }
        public virtual int SiniestroNaturalezaLesion1 { get; set; }
        public virtual int SiniestroNaturalezaLesion2 { get; set; }
        public virtual int SiniestroNaturalezaLesion3 { get; set; }
        public virtual int SiniestroFormaAccidente { get; set; }
        public virtual int SiniestroZonaCuerpo1 { get; set; }
        public virtual int SiniestroZonaCuerpo2 { get; set; }
        public virtual int SiniestroZonaCuerpo3 { get; set; }
        public virtual double PrestadorCUIT { get; set; }
        public virtual string PrestadorRazonSocial { get; set; }
        public virtual string PrestadorDomicilio { get; set; }
        public virtual int PrestadorCodLocalidad { get; set; }
        public virtual string PrestadorTelefonos { get; set; }
        public virtual string PrestadoreMail { get; set; }
        public virtual int PresentacionFecha { get; set; }
        public virtual int PresentacionHora { get; set; }
        public virtual double PresentacionDenuncianteCUIL { get; set; }
        public virtual string PresentacionDenuncianteNombre { get; set; }
        public virtual Byte[] PresentacionDenuncianteFirma { get; set; }
        public virtual Byte[] PresentacionFormulario { get; set; }
    }
}
