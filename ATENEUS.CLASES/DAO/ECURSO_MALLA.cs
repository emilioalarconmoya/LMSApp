using System;
using ATENEUS.CLASES.DAL;

namespace ATENEUS.CLASES.DAO
{
    [Serializable()]
    public class ECURSOMALLA : DomainObject
    {
        private System.Decimal _Cod_Malla = 0;

        private System.Int16 _cod_curso = 0;

        private System.Int32 _nivel = 0;

        private System.Int32 _pre_requisito = 0;

        private System.Int32 _orden = 0;
        //private System.String _color = "" ;
		
		private System.Int64 _cod_empresa = 0;


        public ECURSOMALLA() : base()
	    {
        }

        public ECURSOMALLA(long id) : base(id)
		{
        }

        #region Properties    	

        public System.Decimal CodMalla
        {
            get { return _Cod_Malla; }
            set { _Cod_Malla = value; }
        }


        public System.Int16 CodCurso
        {
            get { return _cod_curso; }
            set { _cod_curso = value; }
        }
        
        

        public System.Int32 Nivel
        {
            get { return _nivel; }
            set { _nivel = value; }
        }
        

        public System.Int32 Prequisito
        {
            get { return _pre_requisito; }
            set { _pre_requisito = value; }
        }

        public System.Int32 Orden
        {
            get { return _orden; }
            set { _orden = value; }
        }

        //public System.String Color
        //{
        //    get { return _color; }
        //    set { _color = value; }
        //}
		
		public System.Int64 CodEmpresa
        {
            get { return _cod_empresa; }
            set { _cod_empresa = value; }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLCURSOMALLA();
        }

        #endregion	    
    }
}
