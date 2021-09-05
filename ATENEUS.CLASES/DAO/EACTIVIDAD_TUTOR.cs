using System;
using ATENEUS.CLASES.DAL;

namespace ATENEUS.CLASES.DAO
{
    [Serializable()]
    public class EACTIVIDADTUTOR : DomainObject
    {
        private System.Int32 _cod_actividad_tutor = 0;
        private System.String _nombre = "";
        private System.Int32 _cod_actividad = 0;

        private System.Int64 _rut_usuario = 0;

        private System.DateTime _fecha_inicio = System.DateTime.Now;

        private System.DateTime _fecha_fin = System.DateTime.Now;

        private System.String _nombre_actividad = "";

        private System.Int64 _cod_empresa = 0;



        public EACTIVIDADTUTOR() : base()
	    {
        }

        public EACTIVIDADTUTOR(long id) : base(id)
		{
        }

        #region Properties   

        public System.Int32 CodActividadTutor
        {
            get { return _cod_actividad_tutor; }
            set { _cod_actividad_tutor = value; }
        }

        public System.String Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public System.Int32 CodActividad
        {
            get { return _cod_actividad; }
            set { _cod_actividad = value; }
        }


        public System.Int64 RutUsuario
        {
            get { return _rut_usuario; }
            set { _rut_usuario = value; }
        }


        public System.DateTime Fechainicio
        {
            get { return _fecha_inicio; }
            set { _fecha_inicio = value; }
        }

        public System.DateTime FechaFin
        {
            get { return _fecha_fin; }
            set { _fecha_fin = value; }
        }

        public System.String NombreAct
        {
            get { return _nombre_actividad; }
            set { _nombre_actividad = value; }
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
            return new DLACTIVIDADTUTOR();
        }

        #endregion	
    }
}
