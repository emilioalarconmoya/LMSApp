using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATENEUS.CLASES.DAL;

namespace ATENEUS.CLASES.DAO
{
    public class ESOLICITUDCURSOCATALOGO : DomainObject
    {
        private System.Int32 _cod_solicitud = 0;

        private System.Int32 _cod_actividad = 0;

        private System.Int32 _cod_catalogo = 0;

        private System.Int32 _rut_usuario = 0;
        
        private System.DateTime _fecha_solicitud;

        private System.DateTime _fecha_acepta_soli;

        private System.DateTime _fecha_rechaza_soli;

        private System.Int32 _cod_estado_solicitud = 0;

        private System.Int64 _cod_empresa = 0;


        public ESOLICITUDCURSOCATALOGO() : base()
	    {
        }

        public ESOLICITUDCURSOCATALOGO(long id) : base(id)
		{
        }

        public ESOLICITUDCURSOCATALOGO(long _cod_solicitud, long codActividad, long rutUsuario)
        {
        }

        #region Properties    	

        public System.Int32 CodActividad
        {
            get { return _cod_actividad; }
            set { _cod_actividad = value; }
        }

        public System.Int32 CodCatalogo
        {
            get { return _cod_catalogo; }
            set { _cod_catalogo = value; }
        }


        public System.Int32 CodSolicitud
        {
            get { return _cod_solicitud; }
            set { _cod_solicitud = value; }
        }


        public System.Int32 RutUsuario
        {
            get { return _rut_usuario; }
            set { _rut_usuario = value; }
        }


        public System.DateTime FechaSolicitud
        {
            get { return _fecha_solicitud; }
            set { _fecha_solicitud = value; }
        }

        public System.DateTime FechaAceptada
        {
            get { return _fecha_acepta_soli; }
            set { _fecha_acepta_soli = value; }
        }

        public System.DateTime FechaRechaza
        {
            get { return _fecha_rechaza_soli; }
            set { _fecha_rechaza_soli = value; }
        }

        public System.Int32 CodEstadoSolicitud
        {
            get { return _cod_estado_solicitud; }
            set { _cod_estado_solicitud = value; }
        }

        public System.Int64 CodEmpresa
        {
            get { return _cod_empresa; }
            set { _cod_empresa = value; }
        }

        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLSOLICITUDCURSOCATALOGO();
        }

        #endregion	  
    }
}
