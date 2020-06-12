using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;

namespace DAL.Formularios
{
    public class CRUDRespuestasCuestionarios
    {
        #region Singleton
        private static ISession session;
        public static CRUDRespuestasCuestionarios instancia = new CRUDRespuestasCuestionarios();
        private CRUDRespuestasCuestionarios()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        private int ConvertirFecha(DateTime pFechaNormal)
        {
            DateTime FechaBase = new DateTime(1801, 01, 01);
            int FechaClarion = ((TimeSpan)(pFechaNormal - FechaBase.AddDays(-4))).Days;
            return FechaClarion;
        }
        public bool GrabarRespuestasCuestionario(int pRespuestasFormulario, List<BE.Formularios.RespuestasCuestionario> pRespuestasCuestionario)
        {
            bool ret;

            ITransaction transaction = session.BeginTransaction();
            try
            {
                foreach (var item in pRespuestasCuestionario)
                {
                    item.InternoRespuestaFormulario = pRespuestasFormulario;
                    //Convertir la fecha normal en fecha clarion
                    DateTime fecha = Convert.ToDateTime(item.FechaRegularizacionNormal);
                    
                    item.FechaRegularizacion = ConvertirFecha(fecha);
                    session.SaveOrUpdate(item);
                }
                
                transaction.Commit();
                ret = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }            

            return ret;
        }

        public IList<BE.Formularios.RespuestasCuestionario> RecuperarRespuestas(int pInternoFormulario, int pInternoEstablecimiento)
        {
            int interno = 0;

            IList<BE.Formularios.RespuestasFormulario> respuestasFormulario = session.Query<BE.Formularios.RespuestasFormulario>().Where(a => a.InternoFormulario == pInternoFormulario && a.InternoEstablecimiento == pInternoEstablecimiento).ToList();

            //debería haber solo 1 registro
            foreach (var item in respuestasFormulario)
            {
                interno = item.Interno;               
            }

            //Si el nro de interno es mayor a 0, acceso a las respuestas
            IList<BE.Formularios.RespuestasCuestionario> respuestasCuestionario = session.Query<BE.Formularios.RespuestasCuestionario>().Where(a => a.InternoRespuestaFormulario == interno).ToList();

            return respuestasCuestionario;
        }
    }
}
