using System;
using ATENEUS.CLASES.DAL;

namespace ATENEUS.CLASES.DAO
{
    public class ETIPOCURSO : DomainObject
    {
        private System.Int16 _cod_tipo_curso = 0;

        private System.String _nombre_curso = String.Empty;

        private System.String _observacion = String.Empty;

        private System.String _color = String.Empty;
		
		private System.Int64 _cod_empresa = 0;


        public ETIPOCURSO() : base()
	    {
        }

        public ETIPOCURSO(long id) : base(id)
		{
        }

        #region Properties    	

        public System.Int16 CodTipoCurso
        {
            get { return _cod_tipo_curso; }
            set { _cod_tipo_curso = value; }
        }


        public System.String NombreCurso
        {
            get { return _nombre_curso; }
            set { _nombre_curso = value; }
        }


        public System.String Observacion
        {
            get { return _observacion; }
            set { _observacion = value; }
        }

        public System.String Color
        {
            get { return _color; }
            set { _color = value; }
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
            return new DLTIPOCURSO();
        }

        #endregion	    
    }
}
