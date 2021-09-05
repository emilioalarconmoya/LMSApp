
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLUNIDADFORO.
	/// </summary>
	public class DLUNIDADFORO : DLBase
	{
		public DLUNIDADFORO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_UNIDAD_FORO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_UNIDAD_FORO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_UNIDAD_FORO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_UNIDAD_FORO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_unidad";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EUNIDADFORO objUNIDADFORO = obj as EUNIDADFORO;

            prms[0] = db.GetParameter();
            prms[0].Value = objUNIDADFORO.CodUnidad;
            prms[0].ParameterName = "@cod_unidad";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EUNIDADFORO objUNIDADFORO = obj as EUNIDADFORO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objUNIDADFORO.IdForo;
            prms[0].ParameterName = "@IDFORO";

            prms[1] = db.GetParameter();
            prms[1].Value = objUNIDADFORO.CodUnidad;
            prms[1].ParameterName = "@COD_UNIDAD";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EUNIDADFORO objUNIDADFORO = obj as EUNIDADFORO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objUNIDADFORO.CodUnidad;
            prms[0].ParameterName = "@cod_unidad";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objUNIDADFORO.IdForo;
            prms[1].ParameterName = "@IdForo";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EUNIDADFORO objRoot = obj as EUNIDADFORO;

            objRoot.CodUnidad = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EUNIDADFORO objUNIDADFORO = obj as EUNIDADFORO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objUNIDADFORO.CodUnidad = Utiles.ConvertToInt16(dr["cod_unidad"]);
            
            objUNIDADFORO.IdForo = Utiles.ConvertToInt32(dr["IdForo"]);
            
        }

        #endregion

	}
}
