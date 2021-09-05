
using System;
using ATENEUS.CLASES.DAL;

namespace ATENEUS.CLASES.DAO
{
    public class ECURSOACTIVIDAD : DomainObject
    {
        private System.Int32 _cod_curso = 0;

        private System.Int32 _cod_actividad = 0;

        private System.Boolean _flag_auto_inscripcion = false;

        private System.Boolean _flag_solicitado = false;

        private System.Int32 _dias_autoinscripcion = 0;

        private System.Double _nota_minima = 0.0;
		
		private System.Int64 _cod_empresa = 0;


        public ECURSOACTIVIDAD() : base()
	    {
        }

        public ECURSOACTIVIDAD(long id) : base(id)
		{
        }

        public ECURSOACTIVIDAD(long codCurso, long codActividad) 
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


        public System.Boolean FlagAutoInscripcion
        {
            get { return _flag_auto_inscripcion; }
            set { _flag_auto_inscripcion = value; }
        }


        public System.Boolean FlagSolicitado
        {
            get { return _flag_solicitado; }
            set { _flag_solicitado = value; }
        }

        public System.Int32 DiasAutoInscripcion
        {
            get { return _dias_autoinscripcion; }
            set { _dias_autoinscripcion = value; }
        }

        public System.Double NotaMinima
        {
            get { return _nota_minima; }
            set { _nota_minima = value; }
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
            return new DLCURSOACTIVIDAD();
        }

        #endregion	    
    }
}
