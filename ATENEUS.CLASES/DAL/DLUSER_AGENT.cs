
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLUSERAGENT.
	/// </summary>
	public class DLUSERAGENT : DLBase
	{
		public DLUSERAGENT()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_USER_AGENT";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_USER_AGENT";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_USER_AGENT";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_USER_AGENT";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@user_agent";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EUSERAGENT objUSERAGENT = obj as EUSERAGENT;

            prms[0] = db.GetParameter();
            prms[0].Value = objUSERAGENT.UserAgent;
            prms[0].ParameterName = "@user_agent";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EUSERAGENT objUSERAGENT = obj as EUSERAGENT;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objUSERAGENT.Marca;
            prms[1].ParameterName = "@marca";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objUSERAGENT.Modelo;
            prms[2].ParameterName = "@modelo";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            EUSERAGENT objUSERAGENT = obj as EUSERAGENT;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objUSERAGENT.UserAgent;
            prms[0].ParameterName = "@user_agent";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objUSERAGENT.Marca;
            prms[1].ParameterName = "@marca";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objUSERAGENT.Modelo;
            prms[2].ParameterName = "@modelo";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EUSERAGENT objRoot = obj as EUSERAGENT;

            objRoot.UserAgent = Utiles.ConvertToString(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EUSERAGENT objUSERAGENT = obj as EUSERAGENT;
    
            //Poner las rutinas del Tools que se necesiten
            
            objUSERAGENT.UserAgent = Utiles.ConvertToString(dr["user_agent"]);
            
            objUSERAGENT.Marca = Utiles.ConvertToString(dr["marca"]);
            
            objUSERAGENT.Modelo = Utiles.ConvertToString(dr["modelo"]);
            
        }

        #endregion

	}
}
