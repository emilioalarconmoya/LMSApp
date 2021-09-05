
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLRESULTADOSUAMS.
	/// </summary>
	public class DLRESULTADOSUAMS : DLBase
	{
		public DLRESULTADOSUAMS()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_RESULTADOS_UAMS";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_RESULTADOS_UAMS";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_RESULTADOS_UAMS";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_RESULTADOS_UAMS";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_resultado_uams";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ERESULTADOSUAMS objRESULTADOSUAMS = obj as ERESULTADOSUAMS;

            prms[0] = db.GetParameter();
            prms[0].Value = objRESULTADOSUAMS.CodResultadoUams;
            prms[0].ParameterName = "@cod_resultado_uams";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            ERESULTADOSUAMS objRESULTADOSUAMS = obj as ERESULTADOSUAMS;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objRESULTADOSUAMS.CodUnidad;
            prms[1].ParameterName = "@cod_unidad";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objRESULTADOSUAMS.CodActivUsr;
            prms[2].ParameterName = "@cod_activ_usr";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objRESULTADOSUAMS.CantidadPasos;
            prms[3].ParameterName = "@cantidad_pasos";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objRESULTADOSUAMS.CantidadErrores;
            prms[4].ParameterName = "@cantidad_errores";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objRESULTADOSUAMS.FechaHora;
            prms[5].ParameterName = "@fecha_hora";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(6);
            ERESULTADOSUAMS objRESULTADOSUAMS = obj as ERESULTADOSUAMS;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objRESULTADOSUAMS.CodResultadoUams;
            prms[0].ParameterName = "@cod_resultado_uams";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objRESULTADOSUAMS.CodUnidad;
            prms[1].ParameterName = "@cod_unidad";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objRESULTADOSUAMS.CodActivUsr;
            prms[2].ParameterName = "@cod_activ_usr";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objRESULTADOSUAMS.CantidadPasos;
            prms[3].ParameterName = "@cantidad_pasos";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objRESULTADOSUAMS.CantidadErrores;
            prms[4].ParameterName = "@cantidad_errores";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objRESULTADOSUAMS.FechaHora;
            prms[5].ParameterName = "@fecha_hora";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ERESULTADOSUAMS objRoot = obj as ERESULTADOSUAMS;

            objRoot.CodResultadoUams = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ERESULTADOSUAMS objRESULTADOSUAMS = obj as ERESULTADOSUAMS;
    
            //Poner las rutinas del Tools que se necesiten
            
            objRESULTADOSUAMS.CodResultadoUams = Utiles.ConvertToDecimal(dr["cod_resultado_uams"]);
            
            objRESULTADOSUAMS.CodUnidad = Utiles.ConvertToInt16(dr["cod_unidad"]);
            
            objRESULTADOSUAMS.CodActivUsr = Utiles.ConvertToDecimal(dr["cod_activ_usr"]);
            
            objRESULTADOSUAMS.CantidadPasos = Utiles.ConvertToInt32(dr["cantidad_pasos"]);
            
            objRESULTADOSUAMS.CantidadErrores = Utiles.ConvertToInt32(dr["cantidad_errores"]);

            objRESULTADOSUAMS.FechaHora = Utiles.ConvertToDateTime(dr["fecha_hora"]);
            
        }

        #endregion

	}
}
