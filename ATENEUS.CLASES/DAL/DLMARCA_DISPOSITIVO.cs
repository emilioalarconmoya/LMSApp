
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLMARCADISPOSITIVO.
	/// </summary>
	public class DLMARCADISPOSITIVO : DLBase
	{
		public DLMARCADISPOSITIVO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_MARCA_DISPOSITIVO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_MARCA_DISPOSITIVO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_MARCA_DISPOSITIVO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_MARCA_DISPOSITIVO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@marca";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EMARCADISPOSITIVO objMARCADISPOSITIVO = obj as EMARCADISPOSITIVO;

            prms[0] = db.GetParameter();
            prms[0].Value = objMARCADISPOSITIVO.Marca;
            prms[0].ParameterName = "@marca";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(0);
            EMARCADISPOSITIVO objMARCADISPOSITIVO = obj as EMARCADISPOSITIVO;

            //Poner las rutinas del Tools que se necesiten
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EMARCADISPOSITIVO objMARCADISPOSITIVO = obj as EMARCADISPOSITIVO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objMARCADISPOSITIVO.Marca;
            prms[0].ParameterName = "@marca";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EMARCADISPOSITIVO objRoot = obj as EMARCADISPOSITIVO;

            objRoot.Marca = Utiles.ConvertToString(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EMARCADISPOSITIVO objMARCADISPOSITIVO = obj as EMARCADISPOSITIVO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objMARCADISPOSITIVO.Marca = Utiles.ConvertToString(dr["marca"]);
            
        }

        #endregion

	}
}
