namespace BE.ProveedoresCtaCte
{
    public class Proveedores
    {
        public Proveedores()
        {
        }

        public virtual int Interno { get; set; }
        public virtual double CUIT { get; set; }
        public virtual double CBU { get; set; }
        public virtual string RubroPrincipal { get; set; }
        public virtual string RazonSocial { get; set; }
        public virtual string Domicilio { get; set; }
        public virtual int CodLocalidad { get; set; }
        public virtual string Telefonos { get; set; }
        public virtual string email { get; set; }
        public virtual int Expr2 { get; set; }
        public virtual string ActividadPrincipal { get; set; }
        public virtual string EstadoClave { get; set; }
        public virtual int FechaNacimiento { get; set; }
        public virtual int IdActividadPrincipal { get; set; }
        public virtual int IdPersona { get; set; }
        public virtual int NroDocumento { get; set; }
        public virtual string TipoClave { get; set; }
        public virtual string TipoDocumento { get; set; }
        public virtual string TipoPersona { get; set; }

    }
}
