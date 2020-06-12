using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SL
{
    public class MapReferenteDatos : ClassMapping<BE.Formularios.ReferenteDatos>
    {
        public MapReferenteDatos()
        {
            Schema("Referencia.dbo");
            Id(x => x.Interno, mapper =>
            {
                mapper.UnsavedValue(0);
                mapper.Generator(Generators.Native);
            });
            
            Property(p => p.CUIT);
            Property(p => p.TipoDocumento);
            Property(p => p.NroDocumento);
            Property(p => p.RazonSocial);
            Property(p => p.EstadoClave);
            Property(p => p.FechaNacimiento);
            Property(p => p.DomicilioCalle);
            Property(p => p.DomicilioNro);
            Property(p => p.DomicilioPiso);
            Property(p => p.DomicilioDpto);
            Property(p => p.DomicilioEntreCalle1);
            Property(p => p.DomicilioEntreCalle2);
            Property(p => p.CodLocalidadSRT);
            Property(p => p.Telefonos);            
            Property(p => p.email);            
            Property(p => p.ActividadPrincipal);
            Property(p => p.IdActividadPrincipal);
            Property(p => p.IdPersona);
            Property(p => p.TipoPersona);
            Property(p => p.TipoClave);                        
        }
    }
}
