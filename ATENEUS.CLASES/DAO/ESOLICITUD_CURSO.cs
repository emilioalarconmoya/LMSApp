using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATENEUS.CLASES.DAL;

namespace ATENEUS.CLASES.DAO
{
    public class ESOLICITUDCURSO : DomainObject
    {
        private System.Int32 _cod_curso = 0;

        private System.Int32 _cod_actividad = 0;

        private System.Int32 _rut_usuario = 0;

        private System.Boolean _flag_solicitado = false;

        private System.DateTime _fecha_hora;

        private System.DateTime _fecha_aprobacion;
		
		private System.Int64 _cod_empresa = 0;

        public ESOLICITUDCURSO() : base()
	    {
        }

        public ESOLICITUDCURSO(long id) : base(id)
		{
        }

        public ESOLICITUDCURSO(long codCurso, long codActividad, long rutUsuario)
        {
        }

        #region Properties    	

        public System.Int32 CodActividad
        {
            get { return _cod_actividad; }
            set { _cod_actividad = value; }
        }


        public System.Int32 CodCurso
        {
            get { return _cod_curso; }
            set { _cod_curso = value; }
        }


        public System.Int32 RutUsuario
        {
            get { return _rut_usuario; }
            set { _rut_usuario = value; }
        }


        public System.Boolean FlagSolicitado
        {
            get { return _flag_solicitado; }
            set { _flag_solicitado = value; }
        }

        public System.DateTime FechaHora
        {
            get { return _fecha_hora; }
            set { _fecha_hora = value; }
        }

        public System.DateTime FechaAprobacion
        {
            get { return _fecha_aprobacion; }
            set { _fecha_aprobacion = value; }
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
            return new DLSOLICITUDCURSO();
        }

        #endregion	  
    }
}
