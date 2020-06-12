namespace BE.ProveedoresCtaCte
{
    public class CtaCteRetenciones
    {
        public CtaCteRetenciones()
        {
        }
        public virtual int Interno { get; set; }
        public virtual int InternoCtaCteProv { get; set; }
        public virtual int InternoCtaCteTiposRetencion { get; set; }
        public virtual string Concepto { get; set; }
        public virtual float Importe { get; set; }

    }
}
