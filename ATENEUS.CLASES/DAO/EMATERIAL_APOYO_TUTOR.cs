using System;
using ATENEUS.CLASES.DAL;

namespace ATENEUS.CLASES.DAO
{
    [Serializable]
    public class EMATERIALAPOYOTUTOR : DomainObject
    {
        private System.Decimal _cod_material = 0;

        private System.Int32 _cod_actividad_tutor = 0;

        private System.String _archivo = String.Empty;

        private System.String _nombre = String.Empty;

        private System.String _descripcion = String.Empty;

        private System.Int64 _cod_empresa = 0;


        public EMATERIALAPOYOTUTOR() : base()
	    {
        }

        public EMATERIALAPOYOTUTOR(long id) : base(id)
		{
        }

        #region Properties    	

        public System.Decimal CodMaterial
        {
            get { return _cod_material; }
            set { _cod_material = value; }
        }


        public System.Int32 CodActividadTutor
        {
            get { return _cod_actividad_tutor; }
            set { _cod_actividad_tutor = value; }
        }


        public System.String Archivo
        {
            get { return _archivo; }
            set { _archivo = value; }
        }


        public System.String Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }


        public System.String Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
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
            return new DLMATERIALAPOYOTUTOR();
        }

        #endregion	    
    }
}
