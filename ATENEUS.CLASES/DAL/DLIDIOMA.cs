
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLIDIOMA.
	/// </summary>
	public class DLIDIOMA : DLBase
	{
		public DLIDIOMA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_IDIOMA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_IDIOMA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_IDIOMA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_IDIOMA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_idioma";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EIDIOMA objIDIOMA = obj as EIDIOMA;

            prms[0] = db.GetParameter();
            prms[0].Value = objIDIOMA.CodIdioma;
            prms[0].ParameterName = "@cod_idioma";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EIDIOMA objIDIOMA = obj as EIDIOMA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objIDIOMA.Idioma;
            prms[1].ParameterName = "@idioma";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EIDIOMA objIDIOMA = obj as EIDIOMA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objIDIOMA.CodIdioma;
            prms[0].ParameterName = "@cod_idioma";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objIDIOMA.Idioma;
            prms[1].ParameterName = "@idioma";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EIDIOMA objRoot = obj as EIDIOMA;

            objRoot.CodIdioma = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EIDIOMA objIDIOMA = obj as EIDIOMA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objIDIOMA.CodIdioma = Utiles.ConvertToInt16(dr["cod_idioma"]);
            
            objIDIOMA.Idioma = Utiles.ConvertToString(dr["idioma"]);
            
        }

        #endregion

	}
}
