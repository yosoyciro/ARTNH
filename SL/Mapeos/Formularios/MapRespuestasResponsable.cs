using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SL
{
    public class MapRespuestasResponsable : ClassMapping<BE.Formularios.RespuestasResponsable>
    {
        public MapRespuestasResponsable()
        {
            Id(x => x.Interno, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            Property(p => p.InternoRespuestaFormulario);
            Property(p => p.CUIT);
            Property(p => p.Responsable);
            Property(p => p.Cargo);
            Property(p => p.Representacion);
            Property(p => p.EsContratado);
            Property(p => p.TituloHabilitante);
            Property(p => p.Matricula);
            Property(p => p.EntidadOtorganteTitulo);
            Property(p => p.EstadoAccion);
            Property(p => p.EstadoFecha);
            Property(p => p.EstadoSituacion);
            Property(p => p.BajaMotivo);
            Property(p => p.Renglon);
        }
    }
}
