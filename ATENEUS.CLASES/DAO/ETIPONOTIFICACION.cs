using System;
using ATENEUS.CLASES.DAL;

namespace ATENEUS.CLASES.DAO
{
    public class ETIPONOTIFICACION : DomainObject
    {
        private System.Int16 _cod_tipo_notificacion = 0;

        private System.String _nombre_tipo_notificacion = String.Empty;

        

        public ETIPONOTIFICACION() : base()
	    {
        }

        public ETIPONOTIFICACION(long id) : base(id)
		{
        }

        #region Properties    	

        public System.Int16 CodTipoNotificacion
        {
            get { return _cod_tipo_notificacion; }
            set { _cod_tipo_notificacion = value; }
        }


        public System.String Nombrenotificacion
        {
            get { return _nombre_tipo_notificacion; }
            set { _nombre_tipo_notificacion = value; }
        }


       


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLTIPONOTIFICACION();
        }

        #endregion	  
    }
}
