

using System;
using ATENEUS.CLASES.DAL;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EMOVIMIENTOCARTOLA.
	/// </summary>
    public class EMOVIMIENTOCARTOLA : DomainObject
    {
	    	
	    private System.Decimal  _COD_MOVIMIENTO = 0;
        	
	    private System.Int16  _COD_TIPO_MOVIMIENTO = 0;
        	
	    private System.Int64  _RUT_USUARIO = 0;
        	
	    private System.Int32  _PUNTOS = 0;
        	
	    private System.DateTime  _FECHA_HORA = DateTime.Now;
        	
	    private System.String  _OBSERVACION = String.Empty;

        private System.Int32 _SALDO = 0;

        private System.DateTime _FECHA_CADUCIDAD = DateTime.Now;

        private System.Int32 _PUNTOS_USADOS = 0;


        public EMOVIMIENTOCARTOLA() : base()
	    {
	    }
	    
		public EMOVIMIENTOCARTOLA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CODMOVIMIENTO
	    {
		    get { return _COD_MOVIMIENTO; }
		    set { _COD_MOVIMIENTO = value; }
	    }
	    
	    	
	    public System.Int16 CODTIPOMOVIMIENTO
	    {
		    get { return _COD_TIPO_MOVIMIENTO; }
		    set { _COD_TIPO_MOVIMIENTO = value; }
	    }
	    
	    	
	    public System.Int64 RUTUSUARIO
	    {
		    get { return _RUT_USUARIO; }
		    set { _RUT_USUARIO = value; }
	    }
	    
	    	
	    public System.Int32 PUNTOS
	    {
		    get { return _PUNTOS; }
		    set { _PUNTOS = value; }
	    }
	    
	    	
	    public System.DateTime FECHAHORA
	    {
		    get { return _FECHA_HORA; }
		    set { _FECHA_HORA = value; }
	    }
	    
	    	
	    public System.String OBSERVACION
	    {
		    get { return _OBSERVACION; }
		    set { _OBSERVACION = value; }
	    }

        public int SALDO
        {
            get
            {
                return _SALDO;
            }

            set
            {
                _SALDO = value;
            }
        }

        public DateTime FECHA_CADUCIDAD
        {
            get
            {
                return _FECHA_CADUCIDAD;
            }

            set
            {
                _FECHA_CADUCIDAD = value;
            }
        }

        public int PUNTOS_USADOS
        {
            get
            {
                return _PUNTOS_USADOS;
            }

            set
            {
                _PUNTOS_USADOS = value;
            }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLMOVIMIENTOCARTOLA();
        }

        #endregion	    
    }
}