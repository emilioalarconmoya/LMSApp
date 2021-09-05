
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLDECLARACIONJURADA.
	/// </summary>
	public class DLDECLARACIONJURADA : DLBase
	{
		public DLDECLARACIONJURADA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_DECLARACION_JURADA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_DECLARACION_JURADA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_DECLARACION_JURADA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_DECLARACION_JURADA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_declaracion";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EDECLARACIONJURADA objDECLARACIONJURADA = obj as EDECLARACIONJURADA;

            prms[0] = db.GetParameter();
            prms[0].Value = objDECLARACIONJURADA.CodDeclaracion;
            prms[0].ParameterName = "@cod_declaracion";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(7);
            EDECLARACIONJURADA objDECLARACIONJURADA = obj as EDECLARACIONJURADA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objDECLARACIONJURADA.CodActivUsr;
            prms[1].ParameterName = "@cod_activ_usr";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objDECLARACIONJURADA.Profesion;
            prms[2].ParameterName = "@profesion";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objDECLARACIONJURADA.Direccion;
            prms[3].ParameterName = "@direccion";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objDECLARACIONJURADA.Comuna;
            prms[4].ParameterName = "@comuna";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objDECLARACIONJURADA.FlagFirmada;
            prms[5].ParameterName = "@flag_firmada";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objDECLARACIONJURADA.Ip;
            prms[6].ParameterName = "@ip";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objDECLARACIONJURADA.FechaHoraFirma;
            prms[7].ParameterName = "@fecha_hora_firma";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(8);
            EDECLARACIONJURADA objDECLARACIONJURADA = obj as EDECLARACIONJURADA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objDECLARACIONJURADA.CodDeclaracion;
            prms[0].ParameterName = "@cod_declaracion";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objDECLARACIONJURADA.CodActivUsr;
            prms[1].ParameterName = "@cod_activ_usr";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objDECLARACIONJURADA.Profesion;
            prms[2].ParameterName = "@profesion";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objDECLARACIONJURADA.Direccion;
            prms[3].ParameterName = "@direccion";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objDECLARACIONJURADA.Comuna;
            prms[4].ParameterName = "@comuna";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objDECLARACIONJURADA.FlagFirmada;
            prms[5].ParameterName = "@flag_firmada";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objDECLARACIONJURADA.Ip;
            prms[6].ParameterName = "@ip";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objDECLARACIONJURADA.FechaHoraFirma;
            prms[7].ParameterName = "@fecha_hora_firma";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EDECLARACIONJURADA objRoot = obj as EDECLARACIONJURADA;

            objRoot.CodDeclaracion = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EDECLARACIONJURADA objDECLARACIONJURADA = obj as EDECLARACIONJURADA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objDECLARACIONJURADA.CodDeclaracion = Utiles.ConvertToDecimal(dr["cod_declaracion"]);
            
            objDECLARACIONJURADA.CodActivUsr = Utiles.ConvertToDecimal(dr["cod_activ_usr"]);
            
            objDECLARACIONJURADA.Profesion = Utiles.ConvertToString(dr["profesion"]);
            
            objDECLARACIONJURADA.Direccion = Utiles.ConvertToString(dr["direccion"]);
            
            objDECLARACIONJURADA.Comuna = Utiles.ConvertToString(dr["comuna"]);
            
            objDECLARACIONJURADA.FlagFirmada = Utiles.ConvertToBoolean(dr["flag_firmada"]);
            
            objDECLARACIONJURADA.Ip = Utiles.ConvertToString(dr["ip"]);

            objDECLARACIONJURADA.FechaHoraFirma = Utiles.ConvertToDateTime(dr["fecha_hora_firma"]);
            
        }

        #endregion

	}
}
