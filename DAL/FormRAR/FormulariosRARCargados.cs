using System;
using System.Linq;
using System.Collections.Generic;
using NHibernate;

namespace DAL.FormRAR
{
    public class FormulariosRARCargados
    {
        private static ISession session;
        public static FormulariosRARCargados instancia = new FormulariosRARCargados();

        private FormulariosRARCargados()
        {
            session = SL.GenerarSesion.Instance.Session;
        }

        public IList<BE.FormRAR.FormulariosRARCargados> ConsultarFormulariosRARCargados(double pCUIT, int pInternoPresentacion)
        {
            try
            {
                return session.CreateSQLQuery("exec ConsultaFormulariosRAR @pCUIT = N'" + pCUIT + "', @pInternoPresentacion = N'" + pInternoPresentacion + "'")
                    .AddScalar("Interno", NHibernateUtil.Int32)
                    .AddScalar("CUIT", NHibernateUtil.Double)
                    .AddScalar("RazonSocial", NHibernateUtil.String)
                    .AddScalar("Direccion", NHibernateUtil.String)
                    .AddScalar("Estado", NHibernateUtil.String)
                    .AddScalar("FechaCreacion", NHibernateUtil.DateTime)
                    .AddScalar("FechaPresentacion", NHibernateUtil.DateTime)
                    .AddScalar("InternoEstablecimiento", NHibernateUtil.Int32)
                    .AddScalar("CantTrabajadoresExpuestos", NHibernateUtil.Int32)
                    .AddScalar("CantTrabajadoresNoExpuestos", NHibernateUtil.Int32)
                    .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(BE.FormRAR.FormulariosRARCargados)))
                    .List<BE.FormRAR.FormulariosRARCargados>()
                    .ToList();
            }

            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
