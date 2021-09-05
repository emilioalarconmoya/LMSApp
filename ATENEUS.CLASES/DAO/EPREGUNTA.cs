
using System;
using ATENEUS.CLASES.DAL;
using System.Collections.Generic;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EPREGUNTA.
    /// </summary>
    [Serializable()]
    public class EPREGUNTA : DomainObject
    {
	    	
	    private System.Int16  _cod_pregunta = 0;

        private System.Int16 _cod_tipo_preg = 0;
        	
	    private System.String  _texto = String.Empty;

        private System.String _cod_cliente = String.Empty;

        private System.Double _puntaje_max = 0.0;

        private System.Int16 _cod_correcta = 0;

        private System.String _imagen = String.Empty;

        private System.Int16 _ancho = 0;

        private System.Int16 _alto = 0;

        private System.String _link = String.Empty;

        private List<EALTERNATIVA> _Alternativas = new List<EALTERNATIVA>();
        	
        
	    public EPREGUNTA() : base()
	    {
	    }
	    
		public EPREGUNTA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodPregunta
	    {
		    get { return _cod_pregunta; }
		    set { _cod_pregunta = value; }
	    }


        public System.Int16 CodTipoPreg
	    {
		    get { return _cod_tipo_preg; }
		    set { _cod_tipo_preg = value; }
	    }
	    
	    	
	    public System.String Texto
	    {
		    get { return _texto; }
		    set { _texto = value; }
	    }
	    
	    	
	    public System.String CodCliente
	    {
		    get { return _cod_cliente; }
		    set { _cod_cliente = value; }
	    }

        public System.Double PuntajeMax
        {
            get { return _puntaje_max; }
            set { _puntaje_max = value; }
        }

        public System.Int16 CodCorrecta
        {
            get { return _cod_correcta; }
            set { _cod_correcta = value; }
        }

        public List<EALTERNATIVA> Alternativas
        {
            get { return _Alternativas; }
            set { _Alternativas = value; }
        }

        public string Imagen
        {
            get
            {
                return _imagen;
            }

            set
            {
                _imagen = value;
            }
        }

        public short Ancho
        {
            get
            {
                return _ancho;
            }

            set
            {
                _ancho = value;
            }
        }

        public short Alto
        {
            get
            {
                return _alto;
            }

            set
            {
                _alto = value;
            }
        }

        public string Link
        {
            get
            {
                return _link;
            }

            set
            {
                _link = value;
            }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLPREGUNTA();
        }

        #endregion	    
    }
}