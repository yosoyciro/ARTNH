﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using BE.Ref;

namespace SL
{
    public class MapAfiliadoDatos : ClassMapping<BE.AfiliadoDatos>
    {
        public MapAfiliadoDatos()
        {
            //Id(x => x.Interno, id =>
            //{
            //    id.Generator(
            //        Generators.Identity
            //        );
            //});
            //Id(x => x.Interno);
            // Rodigo 201910181230 - Evita agregar el id en la consulta sql al insertar
            Id(x => x.Interno, mapper =>
            {
                mapper.UnsavedValue(0);
                mapper.Generator(Generators.Native);
            });
            Property(p => p.Cuil);
            Property(p => p.DocTipo);
            Property(p => p.DocNumero);
            Property(p => p.Nombre);
            Property(p => p.FechaNacimiento);
            Property(p => p.Nacionalidad);
            Property(p => p.Sexo);
            Property(p => p.DomicilioCalle);
            //Property(p => p.CodLocalidadSRT);
            //Property(p => p.CodLocalidadPostal);
            Property(p => p.Telefono);
            Property(p => p.EstadoCivil);
            Property(p => p.eMail);
            ManyToOne(afiliado => afiliado.SRTLocalidad, map =>
                {
                    map.Column("CodLocalidadPostal");
                    map.Class(typeof(SRTLocalidad));
                    map.Fetch(FetchKind.Select);
                    map.UniqueKey("CodPostal");
                    map.Lazy(LazyRelation.NoLazy);
                });
        }
    }
}
