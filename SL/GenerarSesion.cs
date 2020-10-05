using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Configuration;
using SL.Mapeos.Ref;

namespace SL
{
    public class GenerarSesion
    {

        #region ATRIBUTOS
        private ISessionFactory _sessionFactory;
        private ISession _session;
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Propiedad sesión de NHibernate
        /// </summary>
        public ISession Session
        {
            get
            {
                if (null == this._session || !this._session.IsOpen)
                    this._session = this.OpenSession();

                return _session;

            }
            set { this._session = value; }
        }
        #endregion

        #region CONSTRUCTOR SINGLETON
        //public static GenerarSesion instance { get; private set; }
        private static volatile GenerarSesion instance;
        private static object syncRoot = new Object();
        GenerarSesion()
        {
        }

        public static GenerarSesion Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new GenerarSesion();
                    }
                }

                return instance;
            }
        }
        #endregion

        #region METODOS CONFIGURACIÓN
        /// <summary>
        /// Método que abre la sesión
        /// </summary>
        /// <returns>La sesión activa</returns>
        private ISession OpenSession()
        {
            //Open and return the nhibernate session
            return this.SessionFactory().OpenSession();
        }

        /// <summary>
        /// Método que nos sirve para testear si tenemos conexión con la base de datos
        /// </summary>
        /// <returns>True si hay conexión y false en caso contrario</returns>
        public bool TestConnection()
        {
            ISessionFactory _iSession = this.SessionFactory();

            if (null == _iSession)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Método que crea la session factory
        /// </summary>
        public ISessionFactory SessionFactory()
        {
            try
            {
                //Siempre que no la hayamos creado antes
                if (_sessionFactory == null)
                {
                    var cfg = new NHibernate.Cfg.Configuration();
                    var appconfig = ConfigurationManager.AppSettings;
                    switch(appconfig["Ambiente"])
                    {
                        case "Local":
                            cfg.Configure("/Desarrollo/VisualStudio/ART/WebApi/WebApi/bin/Config/hibernate.cfg.xml");
                            break;

                        case "Test":
                            cfg.Configure("/inetpub/wwwroot/ARTApi/bin/Config/hibernate.cfg.xml");
                            break;

                        case "Produccion":
                            cfg.Configure("/inetpub/Sitios/ARTApi/bin/Config/produccion.cfg.xml");
                            break;
                    }
                    

                    var mapper = new ModelMapper();

                    //Especifico uno por unos los mapeos de las entidades
                    #region EntidadesMapeadas
                    mapper.AddMapping<MapDenuncia>();
                    mapper.AddMapping<MapAfiliadoDatos>();
                    mapper.AddMapping<MapAfiliadoCtaCte>();
                    mapper.AddMapping<MapCuestionario>();
                    mapper.AddMapping<MapFormulario>();
                    mapper.AddMapping<MapSeccion>();
                    mapper.AddMapping<MapRespuestasCuestionario>();
                    mapper.AddMapping<MapRefEstablecimiento>();
                    mapper.AddMapping<MapReferenteDatos>();
                    mapper.AddMapping<MapRespuestasFormulario>();
                    mapper.AddMapping<MapRespuestasGremio>();
                    mapper.AddMapping<MapRespuestasContratista>();
                    mapper.AddMapping<MapRespuestasResponsable>();
                    mapper.AddMapping<MapRefReclamoConsulta>();
                    mapper.AddMapping<MapProveedorCuentaCorriente>();
                    mapper.AddMapping<MapProveedores>();
                    mapper.AddMapping<MapRefReclamoConsulta>();
                    mapper.AddMapping<MapRefReclamoConsultaDetalle>();
                    mapper.AddMapping<MapRefReclamoConsultaContacto>();
                    mapper.AddMapping<MapRefReclamoConsultaMedio>();
                    mapper.AddMapping<MapRefReclamoConsultaResponder>();
                    mapper.AddMapping<MapCtaCtePagos>();
                    mapper.AddMapping<MapCtaCteTiposPago>();
                    mapper.AddMapping<MapCtaCteRetenciones>();
                    mapper.AddMapping<MapCtaCteTiposRetencion>();
                    mapper.AddMapping<MapFormulariosRAR>();
                    mapper.AddMapping<MapFormulariosRARDetalle>();
                    mapper.AddMapping<MapFormulariosRARDetalleAgentes>();
                    mapper.AddMapping<MapRefAgenteCausante>();
                    mapper.AddMapping<MapRespuestasFormularioRel>();
                    mapper.AddMapping<MapSRTLocalidad>();
                    mapper.AddMapping<MapRefPais>();
                    mapper.AddMapping<MapRefEmpleador>();
                    mapper.AddMapping<MapPolizaCabecera>();
                    //mapper.AddMapping<MapUsuarios>();
                    #endregion

                    var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

                    cfg.AddMapping(mapping);
                    
                    _sessionFactory = cfg.BuildSessionFactory();
                }
                return _sessionFactory;
            }
            catch (Exception e)
            {                
                return null;
            }
        }

        #endregion

    }
}

