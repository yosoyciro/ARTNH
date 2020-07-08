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
            session.Clear();
            try
            {
                List<BE.Formularios.RespuestasFormulario> respuestasFormularios = session.Query<BE.Formularios.RespuestasFormulario>()
                    .Where(a => a.InternoEstablecimiento == pInternoEstablecimiento)
                    .OrderByDescending(p => p.CreacionFechaHora)
                    .ToList();

                List<BE.Formularios.Formularios> formulariosSeleccion = new List<BE.Formularios.Formularios>();
                List<BE.Formularios.Formularios> formulariosDisponibles = session.Query<BE.Formularios.Formularios>().ToList();
                foreach (var item in formulariosDisponibles)
                {
                    BE.Formularios.RespuestasFormulario respuestasFormularios1 = respuestasFormularios.Find(form => form.InternoFormulario == item.Interno);
                    if (respuestasFormularios1 != null)
                        switch (respuestasFormularios1.CompletadoFechaHora)
                        {
                            case null:
                                item.Estado = "(En proceso de carga)";
                                break;

                            default:
                                item.Estado = "(Nueva instancia)";
                                break;
                        }
                    else
                        item.Estado = "(No generado)";
                    
                    formulariosSeleccion.Add(item);
                    
                };
                //formulariosSeleccion.Sort(p => p.Descripcion);
                return formulariosSeleccion.ToList();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
