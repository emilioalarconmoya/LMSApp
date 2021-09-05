
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLTUTOR.
	/// </summary>
	public class DLTUTOR : DLBase
	{
		public DLTUTOR()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_TUTOR";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_TUTOR";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_TUTOR";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_TUTOR";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@rut_usuario";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ETUTOR objTUTOR = obj as ETUTOR;

            prms[0] = db.GetParameter();
            prms[0].Value = objTUTOR.RutUsuario;
            prms[0].ParameterName = "@rut_usuario";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ETUTOR objTUTOR = obj as ETUTOR;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objTUTOR.CodActivUsr;
            prms[1].ParameterName = "@cod_activ_usr";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ETUTOR objTUTOR = obj as ETUTOR;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objTUTOR.RutUsuario;
            prms[0].ParameterName = "@rut_usuario";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objTUTOR.CodActivUsr;
            prms[1].ParameterName = "@cod_activ_usr";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ETUTOR objRoot = obj as ETUTOR;

            objRoot.RutUsuario = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ETUTOR objTUTOR = obj as ETUTOR;
    
            //Poner las rutinas del Tools que se necesiten
            
            objTUTOR.RutUsuario = Utiles.ConvertToInt64(dr["rut_usuario"]);
            
            objTUTOR.CodActivUsr = Utiles.ConvertToDecimal(dr["cod_activ_usr"]);
            
        }

        #endregion

	}
}
