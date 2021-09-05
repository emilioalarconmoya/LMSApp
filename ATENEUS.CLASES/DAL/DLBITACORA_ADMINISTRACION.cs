
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLBITACORAADMINISTRACION.
	/// </summary>
	public class DLBITACORAADMINISTRACION : DLBase
	{
		public DLBITACORAADMINISTRACION()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_BITACORA_ADMINISTRACION";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_BITACORA_ADMINISTRACION";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_BITACORA_ADMINISTRACION";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_BITACORA_ADMINISTRACION";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@id_bitacora";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EBITACORAADMINISTRACION objBITACORAADMINISTRACION = obj as EBITACORAADMINISTRACION;

            prms[0] = db.GetParameter();
            prms[0].Value = objBITACORAADMINISTRACION.IdBitacora;
            prms[0].ParameterName = "@id_bitacora";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            EBITACORAADMINISTRACION objBITACORAADMINISTRACION = obj as EBITACORAADMINISTRACION;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objBITACORAADMINISTRACION.RutUsuario;
            prms[1].ParameterName = "@rut_usuario";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objBITACORAADMINISTRACION.CodAccion;
            prms[2].ParameterName = "@cod_accion";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objBITACORAADMINISTRACION.USURutUsuario;
            prms[3].ParameterName = "@USU_rut_usuario";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objBITACORAADMINISTRACION.FechaHora;
            prms[4].ParameterName = "@fecha_hora";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objBITACORAADMINISTRACION.Descripcion;
            prms[5].ParameterName = "@descripcion";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(6);
            EBITACORAADMINISTRACION objBITACORAADMINISTRACION = obj as EBITACORAADMINISTRACION;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objBITACORAADMINISTRACION.IdBitacora;
            prms[0].ParameterName = "@id_bitacora";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objBITACORAADMINISTRACION.RutUsuario;
            prms[1].ParameterName = "@rut_usuario";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objBITACORAADMINISTRACION.CodAccion;
            prms[2].ParameterName = "@cod_accion";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objBITACORAADMINISTRACION.USURutUsuario;
            prms[3].ParameterName = "@USU_rut_usuario";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objBITACORAADMINISTRACION.FechaHora;
            prms[4].ParameterName = "@fecha_hora";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objBITACORAADMINISTRACION.Descripcion;
            prms[5].ParameterName = "@descripcion";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EBITACORAADMINISTRACION objRoot = obj as EBITACORAADMINISTRACION;

            objRoot.IdBitacora = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EBITACORAADMINISTRACION objBITACORAADMINISTRACION = obj as EBITACORAADMINISTRACION;
    
            //Poner las rutinas del Tools que se necesiten
            
            objBITACORAADMINISTRACION.IdBitacora = Utiles.ConvertToDecimal(dr["id_bitacora"]);
            
            objBITACORAADMINISTRACION.RutUsuario = Utiles.ConvertToInt64(dr["rut_usuario"]);
            
            objBITACORAADMINISTRACION.CodAccion = Utiles.ConvertToDecimal(dr["cod_accion"]);
            
            objBITACORAADMINISTRACION.USURutUsuario = Utiles.ConvertToInt64(dr["USU_rut_usuario"]);
            
            objBITACORAADMINISTRACION.FechaHora = Utiles.ConvertToDateTime(dr["fecha_hora"]);

            objBITACORAADMINISTRACION.Descripcion = Utiles.ConvertToString(dr["descripcion"]);
            
        }

        #endregion

	}
}
