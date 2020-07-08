﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Formularios
{
    public class RefEstablecimiento
    {
        public RefEstablecimiento()
        {
        }

        public virtual int Interno { get; set; }
        public virtual double CUIT { get; set; }
        public virtual int NroSucursal { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string DomicilioCalle { get; set; }        
        public virtual string DomicilioNro { get; set; }
        public virtual int Superficie { get; set; }
        public virtual int CantTrabajadores { get; set; }
        public virtual string EstadoAccion { get; set; }
        public virtual int EstadoFecha { get; set; }
        public virtual string EstadoSituacion { get; set; }
        public virtual int BajaMotivo { get; set; }
    }
}