
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLCAMPOPLANTILLA.
	/// </summary>
	public class DLCAMPOPLANTILLA : DLBase
	{
		public DLCAMPOPLANTILLA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_CAMPO_PLANTILLA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_CAMPO_PLANTILLA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_CAMPO_PLANTILLA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_CAMPO_PLANTILLA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_plantilla";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ECAMPOPLANTILLA objCAMPOPLANTILLA = obj as ECAMPOPLANTILLA;

            prms[0] = db.GetParameter();
            prms[0].Value = objCAMPOPLANTILLA.CodPlantilla;
            prms[0].ParameterName = "@cod_plantilla";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ECAMPOPLANTILLA objCAMPOPLANTILLA = obj as ECAMPOPLANTILLA;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objCAMPOPLANTILLA.CodPlantilla;
            prms[0].ParameterName = "@cod_plantilla";

            prms[1] = db.GetParameter();
            prms[1].Value = objCAMPOPLANTILLA.CodCampo;
            prms[1].ParameterName = "@cod_campo";

            prms[2] = db.GetParameter();
            prms[2].Value = objCAMPOPLANTILLA.Orden;
            prms[2].ParameterName = "@orden";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ECAMPOPLANTILLA objCAMPOPLANTILLA = obj as ECAMPOPLANTILLA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCAMPOPLANTILLA.CodPlantilla;
            prms[0].ParameterName = "@cod_plantilla";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCAMPOPLANTILLA.CodCampo;
            prms[1].ParameterName = "@cod_campo";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ECAMPOPLANTILLA objRoot = obj as ECAMPOPLANTILLA;

            objRoot.CodPlantilla = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ECAMPOPLANTILLA objCAMPOPLANTILLA = obj as ECAMPOPLANTILLA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objCAMPOPLANTILLA.CodPlantilla = Utiles.ConvertToDecimal(dr["cod_plantilla"]);
            
            objCAMPOPLANTILLA.CodCampo = Utiles.ConvertToDecimal(dr["cod_campo"]);

            objCAMPOPLANTILLA.Orden = Utiles.ConvertToInt16(dr["orden"]);

        }

        #endregion

	}
}
