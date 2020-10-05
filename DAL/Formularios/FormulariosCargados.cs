using System;
using System.Linq;
using System.Collections.Generic;
using NHibernate;

namespace DAL.Formularios
{
    public class FormulariosCargados
    {
        private static ISession session;
        public static FormulariosCargados instancia = new FormulariosCargados();

        private FormulariosCargados()
        {
            session = SL.GenerarSesion.Instance.Session;
        }

        public IList<BE.Formularios.FormulariosCargados> ConsultaFormulariosCargados(double pCUIT)
        {
            try
            {
                return session.CreateSQLQuery("exec ConsultaFormulariosCargados @pCUIT = N'" + pCUIT + "'")                    
                    .AddScalar("Interno", NHibernateUtil.Int32)
                    .AddScalar("CUIT", NHibernateUtil.Double)
                    .AddScalar("RazonSocial", NHibernateUtil.String)
                    .AddScalar("Direccion", NHibernateUtil.String)
                    .AddScalar("Descripcion", NHibernateUtil.String)
                    .AddScalar("Estado", NHibernateUtil.String)
                    .AddScalar("CreacionFechaHora", NHibernateUtil.DateTime)
                    .AddScalar("CompletadoFechaHora", NHibernateUtil.DateTime)
                    .AddScalar("InternoFormulario", NHibernateUtil.Int32)
                    .AddScalar("InternoEstablecimiento", NHibernateUtil.Int32)
                    .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(BE.Formularios.FormulariosCargados)))
                    .List<BE.Formularios.FormulariosCargados>()
                    .ToList();
            }

            catch (Exception e)
            {
                throw e;
            }
            
        }
    }
}
