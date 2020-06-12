namespace BE.ProveedoresCtaCte
{
    public class CtaCtePagos
    {
        public CtaCtePagos()
        {
        }
        public virtual int Interno { get; set; }
        public virtual int InternoCtaCteProv { get; set; }
        public virtual int InternoCtaCteTiposPago { get; set; }
        public virtual string Concepto { get; set; }
        public virtual float Importe { get; set; }

    }
}
