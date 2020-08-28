using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SL.Mapeos.Ref
{
    public class MapSRTLocalidad : ClassMapping<BE.Ref.SRTLocalidad>
    {
        public MapSRTLocalidad()
        {
            Schema("Referencia.dbo");
            Id(x => x.Interno, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            Property(p => p.Nombre);
            Property(p => p.ProvinciaDGI);
            Property(p => p.ProvinciaId);
            Property(p => p.Codigo);            
            Property(p => p.NombreProvincia);
            Property(p => p.NombreCompleto);
            Property(p => p.CodPostal);
            //Bag(localidad => localidad.AfiliadoDatos, map => map.Key(k => k.Column("Codigo")), rel => rel.OneToMany());
        }
    }
}
