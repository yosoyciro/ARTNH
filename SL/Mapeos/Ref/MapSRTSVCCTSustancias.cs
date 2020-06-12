using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SL.Mapeos.Ref
{
    public class MapSRTSVCCTSustancias : ClassMapping<BE.Ref.SRTSVCCTSustancias>
    {
        public MapSRTSVCCTSustancias()
        {
            Schema("Referencia.dbo");
            Id(x => x.Interno, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            Property(p => p.CODIGO);
            Property(p => p.DESCRIPCION);
            Property(p => p.CODIGOESOP);
        }
    }
}
