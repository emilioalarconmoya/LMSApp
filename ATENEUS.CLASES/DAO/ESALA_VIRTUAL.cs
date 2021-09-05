
using System;
using ATENEUS.CLASES.DAL;

namespace ATENEUS.CLASES.DAO
{
    [Serializable()]
    public class ESALAVIRTUAL : DomainObject
    {
        private System.Int64 _rut_usuario = 0;

        private System.Int32 _Cod_tipo_sala_virtual = 0;
        
        private System.String _nombre_usuario = "";

        private System.String _contrasena = "";

        private System.String _url = "";

        private System.Boolean _flag_activo = false;

        private System.Int64 _cod_empresa = 0;

        public ESALAVIRTUAL() : base()
	    {
        }

        public ESALAVIRTUAL(long id) : base(id)
		{
        }

        #region Properties    	

        public System.Int64 RutUsuario
        {
            get { return _rut_usuario; }
            set { _rut_usuario = value; }
        }


        public System.Int32 CodTipoSalaVirtual
        {
            get { return _Cod_tipo_sala_virtual; }
            set { _Cod_tipo_sala_virtual = value; }
        }

        

        public System.String NombreUsuario
        {
            get { return _nombre_usuario; }
            set { _nombre_usuario = value; }
        }

        public System.String Contrasena
        {
            get { return _contrasena; }
            set { _contrasena = value; }
        }

        public System.String URL
        {
            get { return _url; }
            set { _url = value; }
        }

        public System.Boolean Activo
        {
            get { return _flag_activo; }
            set { _flag_activo = value; }
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
            return new DLSALAVIRTUAL();
        }

        #endregion	
    }
}
