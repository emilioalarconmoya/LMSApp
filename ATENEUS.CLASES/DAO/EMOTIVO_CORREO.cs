
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for EMOTIVOCORREO.
    /// </summary>
    [Serializable()]
    public class EMOTIVOCORREO : DomainObject
    {
	    	
	    private System.Int16  _cod_motivo_correo = 0;
        	
	    private System.String  _descripcion = String.Empty;
        	
        
	    public EMOTIVOCORREO() : base()
	    {
	    }
	    
		public EMOTIVOCORREO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodMotivoCorreo
	    {
		    get { return _cod_motivo_correo; }
		    set { _cod_motivo_correo = value; }
	    }
	    
	    	
	    public System.String Descripcion
	    {
		    get { return _descripcion; }
		    set { _descripcion = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLMOTIVOCORREO();
        }

        #endregion	    
    }
}