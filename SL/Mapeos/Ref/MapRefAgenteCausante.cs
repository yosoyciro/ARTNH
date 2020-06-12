using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SL
{
    public class MapRefAgenteCausante : ClassMapping<BE.Ref.SRTSiniestralidadAgenteCausante>
    {
        public MapRefAgenteCausante()
        {
            Schema("Referencia.dbo");
            Id(x => x.Interno, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            Property(p => p.Codigo);
            Property(p => p.Descripcion);
        }
    }
}
