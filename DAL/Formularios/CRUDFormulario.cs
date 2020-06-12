using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace DAL.Formularios
{
    public class CRUDFormulario
    {
        #region Singleton
        private static ISession session;
        public static CRUDFormulario instancia = new CRUDFormulario();

        private CRUDFormulario()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        public List<BE.Formularios.Formularios> Listar()
        {
            try
            {
                return session.Query<BE.Formularios.Formularios>().ToList();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Formularios.Formularios> ListarDisponibles(int pInternoEstablecimiento)
        {
            try
            {
                List<BE.Formularios.RespuestasFormulario> respuestasFormularios = session.Query<BE.Formularios.RespuestasFormulario>()
                    .Where(a => a.InternoEstablecimiento == pInternoEstablecimiento)
                    .ToList();

                List<BE.Formularios.Formularios> formulariosDisponibles = session.Query<BE.Formularios.Formularios>().ToList();
                var formularios1 = formulariosDisponibles;

                foreach (var item in formularios1)
                {
                    string descripcionOriginal = item.Descripcion;

                    BE.Formularios.RespuestasFormulario respuestasFormularios1 = null;

                    respuestasFormularios1 = respuestasFormularios.Find(form => form.InternoFormulario == item.Interno);
                    if (respuestasFormularios1 != null)
                        switch (respuestasFormularios1.CompletadoFechaHora.Year)
                        {
                            case 1800:
                                item.Estado = "(En proceso de carga)";
                                break;

                            default:
                                item.Estado = "(Nueva instancia)";
                                break;
                        }
                    else
                        item.Estado = "(No generado)";
                    
                };

                return formularios1.ToList();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
