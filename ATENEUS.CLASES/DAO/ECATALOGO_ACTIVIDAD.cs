using ATENEUS.CLASES.DAL;
using System;

namespace ATENEUS.CLASES.DAO
{
    public class ECATALOGOACTIVIDAD : DomainObject
    {
        private System.Int32 _cod_catalogo_actividad = 0;
        
        private System.Int16 _stock = 0;

        private System.Int32 _cod_actividad = 0;

        private System.Int32 _cod_catalogo = 0;

        private System.Int32 _dias_auto_inscripcion = 0;

        private System.Boolean _flag_inscribir_curso = false;

        private System.Boolean _flag_diploma = false;

        private System.Double _nota_minima = 0;

        private System.Int64 _cod_empresa = 0;

        public ECATALOGOACTIVIDAD() : base()
	    {
        }

        public ECATALOGOACTIVIDAD(long id) : base(id)
		{
        }

        #region Properties    	

        public System.Int32 Codcatalogo
        {
            get { return _cod_catalogo; }
            set { _cod_catalogo = value; }
        }

        public System.Int32 CodcatalogoActividad
        {
            get { return _cod_catalogo_actividad; }
            set { _cod_catalogo_actividad = value; }
        }
        
        public System.Int16 Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        public System.Int32 CodActividad
        {
            get { return _cod_actividad; }
            set { _cod_actividad = value; }
        }

        public System.Int32 DiasAutoInscripcion
        {
            get { return _dias_auto_inscripcion; }
            set { _dias_auto_inscripcion = value; }
        }

        public System.Boolean FlagInscribirCurso
        {
            get { return _flag_inscribir_curso; }
            set { _flag_inscribir_curso = value; }
        }

        public System.Boolean FlagDiploma
        {
            get { return _flag_diploma; }
            set { _flag_diploma = value; }
        }

        public System.Double NotaMinima
        {
            get { return _nota_minima; }
            set { _nota_minima = value; }
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
            return new DLCATALOGOACTIVIDAD();
        }

        #endregion	    
    }
}
