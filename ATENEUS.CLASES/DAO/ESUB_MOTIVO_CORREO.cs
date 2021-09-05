
using System;
using ATENEUS.CLASES.DAL;
//using ATENEUS.CLASES.BusinessFacade;

namespace ATENEUS.CLASES.DAO
{
	/// <summary>
	/// Summary description for ESUBMOTIVOCORREO.
    /// </summary>
    [Serializable()]
    public class ESUBMOTIVOCORREO : DomainObject
    {
	    	
	    private System.Int16  _cod_motivo_correo = 0;
        	
	    private System.Int16  _cod_sub_motivo_correo = 0;
        	
	    private System.String  _descripcion = String.Empty;
        	
        
	    public ESUBMOTIVOCORREO() : base()
	    {
	    }
	    
		public ESUBMOTIVOCORREO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CodMotivoCorreo
	    {
		    get { return _cod_motivo_correo; }
		    set { _cod_motivo_correo = value; }
	    }
	    
	    	
	    public System.Int16 CodSubMotivoCorreo
	    {
		    get { return _cod_sub_motivo_correo; }
		    set { _cod_sub_motivo_correo = value; }
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
            return new DLSUBMOTIVOCORREO();
        }

        #endregion	    
    }
}