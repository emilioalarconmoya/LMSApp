
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPLANTILLA.
	/// </summary>
	public class DLPLANTILLA : DLBase
	{
		public DLPLANTILLA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_PLANTILLA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_PLANTILLA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_PLANTILLA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_PLANTILLA";
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
            EPLANTILLA objPLANTILLA = obj as EPLANTILLA;

            prms[0] = db.GetParameter();
            prms[0].Value = objPLANTILLA.CodPlantilla;
            prms[0].ParameterName = "@cod_plantilla";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EPLANTILLA objPLANTILLA = obj as EPLANTILLA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPLANTILLA.NombrePlantilla;
            prms[0].ParameterName = "@nombre_plantilla";

            prms[1] = db.GetParameter();
            prms[1].Value = objPLANTILLA.CodEmpresa;
            prms[1].ParameterName = "@cod_empresa";


            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EPLANTILLA objPLANTILLA = obj as EPLANTILLA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPLANTILLA.CodPlantilla;
            prms[0].ParameterName = "@cod_plantilla";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPLANTILLA.NombrePlantilla;
            prms[1].ParameterName = "@nombre_plantilla";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EPLANTILLA objRoot = obj as EPLANTILLA;

            objRoot.CodPlantilla = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EPLANTILLA objPLANTILLA = obj as EPLANTILLA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objPLANTILLA.CodPlantilla = Utiles.ConvertToDecimal(dr["cod_plantilla"]);

            objPLANTILLA.NombrePlantilla = Utiles.ConvertToString(dr["nombre_plantilla"]);

            DLCAMPOList _objCA = new DLCAMPOList();
            objPLANTILLA.Campos = _objCA.GetCamposPlantilla(objPLANTILLA.CodPlantilla);


        }

        #endregion

	}
}
