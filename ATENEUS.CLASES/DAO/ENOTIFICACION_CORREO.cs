using System;
using ATENEUS.CLASES.DAL;

namespace ATENEUS.CLASES.DAO
{
    public class ENOTIFICACIONCORREO : DomainObject
    {
        private System.Int32 _cod_notificacion_correo = 0;
        private System.Int32 _cod_tipo_notificacion = 0;
        private System.String _asunto = "";
        private System.String _cuerpo = ""; //mensaje
		private System.Int64 _cod_empresa = 0;

        public ENOTIFICACIONCORREO() : base()
	    {
        }

        public ENOTIFICACIONCORREO(Int64 id) : base(id)
		{
        }

        #region Properties    	

        public System.Int32 CodNotificacionCorreo
        {
            get { return _cod_notificacion_correo; }
            set { _cod_notificacion_correo = value; }
        }


        public System.Int32 CodTipoNotificacion
        {
            get { return _cod_tipo_notificacion; }
            set { _cod_tipo_notificacion = value; }
        }


        public System.String Asunto
        {
            get { return _asunto; }
            set { _asunto = value; }
        }


        public System.String Cuerpo
        {
            get { return _cuerpo; }
            set { _cuerpo = value; }
        }
		
		public System.Int64 CodEmpresa
        {
            get { return _cod_empresa; }
            set { _cod_empresa = value; }
        }


        #endregion

        protected override DLBase GetMapper()
        {
            return new DLNOTIFICACIONCORREO();
        }

    }
}
