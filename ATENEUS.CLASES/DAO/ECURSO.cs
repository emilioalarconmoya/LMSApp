
using System;
using ATENEUS.CLASES.DAL;

namespace ATENEUS.CLASES.DAO
{
    [Serializable()]
    public class ECURSO : DomainObject
    {
        private System.Int32 _cod_curso = 0;

        private System.Int32 _cod_tipo_curso = 0;

        private System.String _Nombre_curso = String.Empty;

        private System.String _nombre_tipo_curso = String.Empty;

        private System.String _color = String.Empty;
		
		private System.Int64 _cod_empresa = 0;



        public ECURSO() : base()
	    {
        }

        public ECURSO(long id) : base(id)
		{
        }

        #region Properties    	

        public System.Int32 CodCurso
        {
            get { return _cod_curso; }
            set { _cod_curso = value; }
        }


        public System.Int32 CodTipoCurso
        {
            get { return _cod_tipo_curso; }
            set { _cod_tipo_curso = value; }
        }

        public System.String NombreCurso
        {
            get { return _Nombre_curso; }
            set { _Nombre_curso = value; }
        }

        public System.String NombreTipoCurso
        {
            get { return _nombre_tipo_curso; }
            set { _nombre_tipo_curso = value; }
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
            return new DLCURSO();
        }

        #endregion	    
    }
}
