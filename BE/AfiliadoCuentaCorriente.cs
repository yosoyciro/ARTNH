using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class AfiliadoCuentaCorriente
    {
        public AfiliadoCuentaCorriente()
        {
        }

        public virtual int Interno { get; set; }
        public virtual double CuitAportante { get; set; }
        public virtual double CuitContribuyente { get; set; }
        public virtual int Periodo { get; set; }
        public virtual int ObligacionNumero { get; set; }
        public virtual int ObligacionSecuencia { get; set; }
        public virtual int Banco { get; set; }
        public virtual int Rectificativa { get; set; }
        public virtual int ModalidadContratacion { get; set; }
        public virtual int ZonaGeografica { get; set; }
        public virtual int ActividadDesempeñada { get; set; }
        public virtual double PorcentajeReduccion { get; set; }
        public virtual double RemuneracionTotal { get; set; }
        public virtual double RemuneracionR { get; set; }
        public virtual double PorcentajeTareasRiesgo { get; set; }
        public virtual double AporteObligatorioSegSoc { get; set; }
        public virtual double AporteVoluntarioSegSoc { get; set; }
        public virtual int ART { get; set; }
        public virtual int CuilCondicion { get; set; }
        public virtual double RemImporte { get; set; }
        public virtual int SiniestroCodigo { get; set; }
        public virtual int CUILSituacion { get; set; }
        public virtual int Situacion1 { get; set; }
        public virtual int Situacion1DiaDesde { get; set; }
        public virtual int Situacion2 { get; set; }
        public virtual int Situacion2DiaDesde { get; set; }
        public virtual int Situacion3 { get; set; }
        public virtual int Situacion3DiaDesde { get; set; }
        public virtual double Sueldo { get; set; }
        public virtual double SAC { get; set; }
        public virtual double HsExtras { get; set; }
        public virtual double ZonaDesfavorable { get; set; }
        public virtual double VacacionesAdelanto { get; set; }
        public virtual int DiasTrabajados { get; set; }
        public virtual double Adicionales { get; set; }
        public virtual double Premios { get; set; }
        public virtual double NoRemunerativo { get; set; }
        public virtual int Version { get; set; }
        public virtual int Release { get; set; }
    }
}
