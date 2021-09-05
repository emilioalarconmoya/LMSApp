using System;
using ATENEUS.CLASES.DAL;

namespace ATENEUS.CLASES.DAO
{
    public class EBITACORACORREO : DomainObject
    {
        private System.Int64 _cod_bitacora_correo = 0;

        private System.Int32 _cod_empresa = 0;

        private System.String _nombre = "";

        private System.String _rut = "";

        private System.String _email = "";

        private System.String _asunto = String.Empty;

        private System.DateTime _fecha_hora = System.DateTime.Now;

        private System.String _cuerpo = "";

        private System.String _curso = "";

        private System.Int64 _cod_tipo_notificacion = 1;

        public EBITACORACORREO() : base()
	    {
        }

        public EBITACORACORREO(long id) : base(id)
		{
        }


        #region Properties    	

        public System.Int64 CodBitacoraCorreo
        {
            get { return _cod_bitacora_correo; }
            set { _cod_bitacora_correo = value; }
        }


        public System.Int32 CodEmpresa
        {
            get { return _cod_empresa; }
            set { _cod_empresa = value; }
        }


        public System.String Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }


        public System.String Rut
        {
            get { return _rut; }
            set { _rut = value; }
        }


        public System.String Email
        {
            get { return _email; }
            set { _email = value; }
        }


        public System.String Asunto
        {
            get { return _asunto; }
            set { _asunto = value; }
        }


        public System.DateTime FechaHora
        {
            get { return _fecha_hora; }
            set { _fecha_hora = value; }
        }

        public System.String Cuerpo
        {
            get { return _cuerpo; }
            set { _cuerpo = value; }
        }

        public System.String Curso
        {
            get { return _curso; }
            set { _curso = value; }
        }
        public System.Int64 CodtipoNotificacion
        {
            get { return _cod_tipo_notificacion; }
            set { _cod_tipo_notificacion = value; }
        }
        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLBITACORACORREO();
        }

        #endregion	    
    }
}
