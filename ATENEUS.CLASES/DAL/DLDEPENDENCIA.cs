
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLDEPENDENCIA.
	/// </summary>
	public class DLDEPENDENCIA : DLBase
	{
		public DLDEPENDENCIA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_DEPENDENCIA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_DEPENDENCIA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_DEPENDENCIA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_DEPENDENCIA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@Cod_Malla";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EDEPENDENCIA objDEPENDENCIA = obj as EDEPENDENCIA;

            prms[0] = db.GetParameter();
            prms[0].Value = objDEPENDENCIA.CodMalla;
            prms[0].ParameterName = "@Cod_Malla";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EDEPENDENCIA objDEPENDENCIA = obj as EDEPENDENCIA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objDEPENDENCIA.ACTCodActividad;
            prms[1].ParameterName = "@ACT_cod_actividad";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objDEPENDENCIA.CodActividad;
            prms[2].ParameterName = "@cod_actividad";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            EDEPENDENCIA objDEPENDENCIA = obj as EDEPENDENCIA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objDEPENDENCIA.CodMalla;
            prms[0].ParameterName = "@Cod_Malla";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objDEPENDENCIA.ACTCodActividad;
            prms[1].ParameterName = "@ACT_cod_actividad";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objDEPENDENCIA.CodActividad;
            prms[2].ParameterName = "@cod_actividad";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EDEPENDENCIA objRoot = obj as EDEPENDENCIA;

            objRoot.CodMalla = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EDEPENDENCIA objDEPENDENCIA = obj as EDEPENDENCIA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objDEPENDENCIA.CodMalla = Utiles.ConvertToDecimal(dr["Cod_Malla"]);
            
            objDEPENDENCIA.ACTCodActividad = Utiles.ConvertToInt16(dr["ACT_cod_actividad"]);

            objDEPENDENCIA.CodActividad = Utiles.ConvertToInt16(dr["cod_actividad"]);
            
        }

        #endregion

	}
}
