using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using BE.ProveedoresCtaCte;

namespace SL
{
    public class MapProveedores : ClassMapping<Proveedores>
    {
        public MapProveedores()
        {
            Table("vProveedor");
            
            Id(x => x.Interno);
            Property(x => x.CUIT);
            Property(x => x.CBU);
            Property(x => x.RubroPrincipal);
            Property(x => x.RazonSocial);
            Property(x => x.Domicilio);
            Property(x => x.CodLocalidad);
            Property(x => x.Telefonos);
            Property(x => x.email);
            Property(x => x.Expr2);
            Property(x => x.ActividadPrincipal);
            Property(x => x.EstadoClave);
            Property(x => x.FechaNacimiento);
            Property(x => x.IdActividadPrincipal);
            Property(x => x.IdPersona);
            Property(x => x.NroDocumento);
            Property(x => x.TipoClave);
            Property(x => x.TipoDocumento);
            Property(x => x.TipoPersona);
        }
    }
}
