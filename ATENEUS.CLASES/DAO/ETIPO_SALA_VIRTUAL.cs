using System;
using ATENEUS.CLASES.DAL;

namespace ATENEUS.CLASES.DAO
{
    [Serializable()]
    public class ETIPOSALAVIRTUAL : DomainObject
    {
        private System.Int16 _cod_tipo = 0;

        private System.String _nombre = String.Empty;

        public ETIPOSALAVIRTUAL() : base()
	    {
        }

        public ETIPOSALAVIRTUAL(long id) : base(id)
		{
        }

        #region Properties    	

        public System.Int16 CodTipo
        {
            get { return _cod_tipo; }
            set { _cod_tipo = value; }
        }


        public System.String Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLTIPOSALAVIRTUAL();
        }

        #endregion	    
    }
}
