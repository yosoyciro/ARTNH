﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;

namespace DAL.Formularios
{
    public class CRUDPresentaciones
    {
        #region Singleton
        private static ISession session;
        public static CRUDPresentaciones instancia = new CRUDPresentaciones();

        private CRUDPresentaciones()
        {
            session = SL.GenerarSesion.Instance.Session;
        }
        #endregion

        public async Task<IEnumerable<BE.Formularios.Presentaciones>> Listar(double pCUIT, string pTipo)
        {
            session.Clear();
            IEnumerable<BE.Formularios.Presentaciones> presentaciones = null;

            try
            {
                //Devuelvo las presentacions del CUIT o "Sin presentacion"
                switch (pCUIT)
                {
                    case 99999999999:
                        //return session.Query<BE.Formularios.Presentaciones>().Where(a => (a.Interno == 0 || (a.CUIT == pCUIT && a.Tipo == pTipo))).ToList();
                        presentaciones = await session
                            .Query<BE.Formularios.Presentaciones>()
                            .Where(a => (a.Interno == 0 || (a.Tipo == pTipo)))
                            .ToListAsync();
                        break;

                    default:
                        //return session.Query<BE.Formularios.Presentaciones>().Where(a => (a.Interno == 0 || (a.CUIT == pCUIT && a.Tipo == pTipo))).ToList();
                        presentaciones = await session
                            .Query<BE.Formularios.Presentaciones>()
                            .Where(a => (a.Interno == 0 || (a.CUIT == pCUIT && a.Tipo == pTipo)))
                            .ToListAsync();
                        break;
                }
                

                return presentaciones;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> VerificarPresentacion(double pCUIT, string pNombre, string pTipo)
        {
            session.Clear();
            BE.Formularios.Presentaciones presentacion;
            try
            {
                //Verifico si existe la presentacion
                presentacion = await session.Query<BE.Formularios.Presentaciones>()
                    .FirstOrDefaultAsync(a => a.CUIT == pCUIT && a.Nombre == pNombre && a.Tipo == pTipo);
                if (presentacion == null)
                    return true;
                else
                    return false;

            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally 
            { 
                //presentacion.
            }
        }

        public async Task<bool> VerificarCompletados(double pCUIT, string pTipo)
        {
            session.Clear();

            //Busco los establecimientos
            var establecimientos = await session.Query<BE.Formularios.RefEstablecimiento>()
                .Where(a => a.CUIT == pCUIT && a.BajaMotivo == 0)
                .ToListAsync();

            foreach (var item in establecimientos)
            {
                //busco formularios sin presentacion para cada establecimiento y completado
                switch (pTipo)
                {
                    case "R":
                        var formularioRGRL = await session.Query<BE.Formularios.RespuestasFormulario>()
                                .Where(a => a.InternoEstablecimiento == item.Interno && a.InternoPresentacion == 0 && a.CompletadoFechaHora != null)
                                .FirstOrDefaultAsync();
                        if (formularioRGRL == null)
                        {
                            return false;
                        }
                        break;

                    case "A":
                        var formularioRAR = await session.Query<BE.FormRAR.FormulariosRAR>()
                                .Where(a => a.InternoEstablecimiento == item.Interno && a.InternoPresentacion == 0 && a.FechaPresentacion != null)
                                .FirstOrDefaultAsync();
                        if (formularioRAR == null)
                        {
                            return false;
                        }
                        break;

                    default:
                        break;
                }
            }

            return true;
        }

        #region GenerarPresentacion
        public async Task<BE.Formularios.Presentaciones> Generar(BE.Formularios.Presentaciones pPresentacion)
        {
            ITransaction transaction = session.BeginTransaction();
            try
            {
                switch (pPresentacion.Interno)
                {
                    case 0:
                        //Busco los establecimientos
                        var establecimientos = await session.Query<BE.Formularios.RefEstablecimiento>()
                            .Where(a => a.CUIT == pPresentacion.CUIT && a.BajaMotivo == 0)
                            .ToListAsync();

                        pPresentacion.FechaHoraGeneracion = DateTime.Now;
                        pPresentacion.CantidadEstablecimientos = establecimientos.Count;
                        session.Save(pPresentacion);
                        
                        foreach (var item in establecimientos)
                        {
                            //Recorro todos los formularios del CUIT que no tengan presentacion y asigno el dato
                            switch (pPresentacion.Tipo)
                            {
                                //Formularios RGRL
                                case "R":
                                    var formularioRGRL = await session.Query<BE.Formularios.RespuestasFormulario>()
                                        .Where(a => a.InternoEstablecimiento == item.Interno && a.InternoPresentacion == 0)
                                        .FirstOrDefaultAsync();
                                    if (formularioRGRL != null)
                                    {
                                        formularioRGRL.InternoPresentacion = pPresentacion.Interno;
                                        session.Merge(formularioRGRL);
                                    }
                                    break;

                                //RAR
                                case "A":
                                    var formularioRAR = await session.Query<BE.FormRAR.FormulariosRAR>()
                                        .Where(a => a.InternoEstablecimiento == item.Interno && a.InternoPresentacion == 0)
                                        .FirstOrDefaultAsync();
                                    if (formularioRAR != null)
                                    {
                                        formularioRAR.InternoPresentacion = pPresentacion.Interno;
                                        session.Merge(formularioRAR);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    default:
                        session.Merge(pPresentacion);
                        break;
                }
                                
                
                session.Flush();
                transaction.Commit();
                transaction.Dispose();

                return pPresentacion;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
    }
    #endregion
}
