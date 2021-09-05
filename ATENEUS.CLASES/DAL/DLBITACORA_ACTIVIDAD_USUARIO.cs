
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLBITACORAACTIVIDADUSUARIO.
	/// </summary>
	public class DLBITACORAACTIVIDADUSUARIO : DLBase
	{
		public DLBITACORAACTIVIDADUSUARIO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_BITACORA_ACTIVIDAD_USUARIO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_BITACORA_ACTIVIDAD_USUARIO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_BITACORA_ACTIVIDAD_USUARIO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_BITACORA_ACTIVIDAD_USUARIO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_activ_usr";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EBITACORAACTIVIDADUSUARIO objBITACORAACTIVIDADUSUARIO = obj as EBITACORAACTIVIDADUSUARIO;

            prms[0] = db.GetParameter();
            prms[0].Value = objBITACORAACTIVIDADUSUARIO.CodActivUsr;
            prms[0].ParameterName = "@cod_activ_usr";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(7);
            EBITACORAACTIVIDADUSUARIO objBITACORAACTIVIDADUSUARIO = obj as EBITACORAACTIVIDADUSUARIO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objBITACORAACTIVIDADUSUARIO.CodActivUsr;
            prms[0].ParameterName = "@cod_activ_usr";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objBITACORAACTIVIDADUSUARIO.FechaHoraInicio;
            prms[1].ParameterName = "@fecha_hora_inicio";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objBITACORAACTIVIDADUSUARIO.FechaHoraFin;
            prms[2].ParameterName = "@fecha_hora_fin";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objBITACORAACTIVIDADUSUARIO.FlagComunicoInicio;
            prms[3].ParameterName = "@flag_comunico_inicio";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objBITACORAACTIVIDADUSUARIO.FlagComunicoFin;
            prms[4].ParameterName = "@flag_comunico_fin";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objBITACORAACTIVIDADUSUARIO.ResultadoInicio;
            prms[5].ParameterName = "@resultado_inicio";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objBITACORAACTIVIDADUSUARIO.ResultadoFin;
            prms[6].ParameterName = "@resultado_fin";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(7);
            EBITACORAACTIVIDADUSUARIO objBITACORAACTIVIDADUSUARIO = obj as EBITACORAACTIVIDADUSUARIO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objBITACORAACTIVIDADUSUARIO.CodActivUsr;
            prms[0].ParameterName = "@cod_activ_usr";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objBITACORAACTIVIDADUSUARIO.FechaHoraInicio;
            prms[1].ParameterName = "@fecha_hora_inicio";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objBITACORAACTIVIDADUSUARIO.FechaHoraFin;
            prms[2].ParameterName = "@fecha_hora_fin";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objBITACORAACTIVIDADUSUARIO.FlagComunicoInicio;
            prms[3].ParameterName = "@flag_comunico_inicio";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objBITACORAACTIVIDADUSUARIO.FlagComunicoFin;
            prms[4].ParameterName = "@flag_comunico_fin";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objBITACORAACTIVIDADUSUARIO.ResultadoInicio;
            prms[5].ParameterName = "@resultado_inicio";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objBITACORAACTIVIDADUSUARIO.ResultadoFin;
            prms[6].ParameterName = "@resultado_fin";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EBITACORAACTIVIDADUSUARIO objRoot = obj as EBITACORAACTIVIDADUSUARIO;

            objRoot.CodActivUsr = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EBITACORAACTIVIDADUSUARIO objBITACORAACTIVIDADUSUARIO = obj as EBITACORAACTIVIDADUSUARIO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objBITACORAACTIVIDADUSUARIO.CodActivUsr = Utiles.ConvertToDecimal(dr["cod_activ_usr"]);
            
            objBITACORAACTIVIDADUSUARIO.FechaHoraInicio = Utiles.ConvertToDateTime(dr["fecha_hora_inicio"]);
            
            objBITACORAACTIVIDADUSUARIO.FechaHoraFin = Utiles.ConvertToDateTime(dr["fecha_hora_fin"]);
            
            objBITACORAACTIVIDADUSUARIO.FlagComunicoInicio = Utiles.ConvertToBoolean(dr["flag_comunico_inicio"]);
            
            objBITACORAACTIVIDADUSUARIO.FlagComunicoFin = Utiles.ConvertToBoolean(dr["flag_comunico_fin"]);
            
            objBITACORAACTIVIDADUSUARIO.ResultadoInicio = Utiles.ConvertToString(dr["resultado_inicio"]);

            objBITACORAACTIVIDADUSUARIO.ResultadoFin = Utiles.ConvertToString(dr["resultado_fin"]);
            
        }

         public DateTime FechaHoraUltimaBitacora(long CodActivUsr)
         {
             DB db = DatabaseFactory.Instance.GetDatabase();
             IDbDataParameter[] prms;
             prms = db.GetArrayParameter(1);

             prms[0] = db.GetParameter();
             prms[0].Value = CodActivUsr;
             prms[0].ParameterName = "@cod_activ_usr";

             DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_fecha_hora_ultima_bitacora", prms);
             if (dt.Rows.Count > 0)
             {
                 return Utiles.ConvertToDateTime(dt.Rows[0][0]);
             }
             else
             {
                 return DateTime.Now;
             }
         }
        #endregion

	}
}
