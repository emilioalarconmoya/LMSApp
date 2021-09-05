using System;
using ATENEUS.CLASES.DAL;
namespace ATENEUS.CLASES.DAO
{
    [Serializable()]
    public class ECOMENTARIOTUTOR : DomainObject
    {
       
        private System.Int32 _cod_comentario = 0;

        private System.Int32 _cod_actividad_tutor = 0;

        private System.String _comentario = "";

        private System.DateTime _fecha = System.DateTime.Now;

        private System.Int32 _rut_usuario = 0;

        private System.Int64 _cod_empresa = 0;

        private System.DateTime _fecha_respuesta = System.DateTime.Now;

        private System.String _respuesta = "";  //respuesta del tutor

        public ECOMENTARIOTUTOR() : base()
	    {
        }

        public ECOMENTARIOTUTOR(long id) : base(id)
		{
        }

        #region Properties   


        public System.Int32 CodComentario
        {
            get { return _cod_comentario; }
            set { _cod_comentario = value; }
        }

        public System.Int32 CodActividadTutor
        {
            get { return _cod_actividad_tutor; }
            set { _cod_actividad_tutor = value; }
        }

        public System.String Comentario
        {
            get { return _comentario; }
            set { _comentario = value; }
        }


        public System.DateTime FechaIngreso
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public System.Int32 RutUsuario
        {
            get { return _rut_usuario; }
            set { _rut_usuario = value; }
        }

        public System.Int64 codEmpresa
        {
            get { return _cod_empresa; }
            set { _cod_empresa = value; }
        }

        public System.DateTime FechaRespuesta
        {
            get { return _fecha_respuesta; }
            set { _fecha_respuesta = value; }
        }

        public System.String Respuesta
        {
            get { return _respuesta; }
            set { _respuesta = value; }
        }

        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLCOMENTARIOTUTOR();
        }

        #endregion	
    }
}
