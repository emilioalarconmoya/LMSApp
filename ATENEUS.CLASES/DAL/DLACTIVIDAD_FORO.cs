
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLACTIVIDADFORO.
	/// </summary>
	public class DLACTIVIDADFORO : DLBase
	{
		public DLACTIVIDADFORO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_ACTIVIDAD_FORO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_ACTIVIDAD_FORO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_ACTIVIDAD_FORO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_ACTIVIDAD_FORO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_actividad";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EACTIVIDADFORO objACTIVIDADFORO = obj as EACTIVIDADFORO;

            prms[0] = db.GetParameter();
            prms[0].Value = objACTIVIDADFORO.CodActividad;
            prms[0].ParameterName = "@cod_actividad";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EACTIVIDADFORO objACTIVIDADFORO = obj as EACTIVIDADFORO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objACTIVIDADFORO.IdForo;
            prms[0].ParameterName = "@IDFORO";

            prms[1] = db.GetParameter();
            prms[1].Value = objACTIVIDADFORO.CodActividad;
            prms[1].ParameterName = "@COD_ACTIVIDAD";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EACTIVIDADFORO objACTIVIDADFORO = obj as EACTIVIDADFORO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objACTIVIDADFORO.CodActividad;
            prms[0].ParameterName = "@cod_actividad";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objACTIVIDADFORO.IdForo;
            prms[1].ParameterName = "@IdForo";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EACTIVIDADFORO objRoot = obj as EACTIVIDADFORO;

            objRoot.CodActividad = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EACTIVIDADFORO objACTIVIDADFORO = obj as EACTIVIDADFORO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objACTIVIDADFORO.CodActividad = Utiles.ConvertToInt16(dr["cod_actividad"]);

            objACTIVIDADFORO.IdForo = Utiles.ConvertToInt32(dr["IdForo"]);
            
        }

        #endregion

	}
}
