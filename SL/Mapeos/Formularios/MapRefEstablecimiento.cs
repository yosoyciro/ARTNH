﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SL
{
    public class MapRefEstablecimiento : ClassMapping<BE.Formularios.RefEstablecimiento>
    {
        public MapRefEstablecimiento()
        {
            Schema("Referencia.dbo");
            Id(x => x.Interno, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            Property(p => p.CUIT);
            Property(p => p.NroSucursal);
            Property(p => p.Nombre);
            Property(p => p.DomicilioCalle);
            Property(p => p.DomicilioNro);
            Property(p => p.Superficie);
            Property(p => p.CantTrabajadores);
            Property(p => p.EstadoAccion);
            Property(p => p.EstadoFecha);
            Property(p => p.EstadoSituacion);
            Property(p => p.CodLocalidadSRT);
            Property(p => p.Codigo);
            Property(p => p.Numero);
            Property(p => p.BajaMotivo);
            Property(p => p.CodEstabEmpresa);
            //Property(p => p.Localidad);
            //Property(p => p.Provincia);
        }
    }
}
