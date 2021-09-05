
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLBITACORANAVEGACION.
	/// </summary>
	public class DLBITACORANAVEGACION : DLBase
	{
		public DLBITACORANAVEGACION()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_BITACORA_NAVEGACION";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_BITACORA_NAVEGACION";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_BITACORA_NAVEGACION";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_BITACORA_NAVEGACION";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@codigo_bitacora";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EBITACORANAVEGACION objBITACORANAVEGACION = obj as EBITACORANAVEGACION;

            prms[0] = db.GetParameter();
            prms[0].Value = objBITACORANAVEGACION.CodigoBitacora;
            prms[0].ParameterName = "@codigo_bitacora";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(11);
            EBITACORANAVEGACION objBITACORANAVEGACION = obj as EBITACORANAVEGACION;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objBITACORANAVEGACION.RutUsuario;
            prms[1].ParameterName = "@rut_usuario";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objBITACORANAVEGACION.CodActivUsr;
            prms[2].ParameterName = "@cod_activ_usr";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objBITACORANAVEGACION.UserAgent;
            prms[3].ParameterName = "@user_agent";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objBITACORANAVEGACION.DireccionIp;
            prms[4].ParameterName = "@direccion_ip";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objBITACORANAVEGACION.Pais;
            prms[5].ParameterName = "@pais";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objBITACORANAVEGACION.PaginaNavegacion;
            prms[6].ParameterName = "@pagina_navegacion";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objBITACORANAVEGACION.Sesion;
            prms[7].ParameterName = "@sesion";
            	
            prms[8] = db.GetParameter();
            prms[8].Value = objBITACORANAVEGACION.SesionID;
            prms[8].ParameterName = "@sesionID";
            	
            prms[9] = db.GetParameter();
            prms[9].Value = objBITACORANAVEGACION.VersionBrowser;
            prms[9].ParameterName = "@version_browser";
            	
            prms[10] = db.GetParameter();
            prms[10].Value = objBITACORANAVEGACION.Browser;
            prms[10].ParameterName = "@browser";
            	
            prms[11] = db.GetParameter();
            prms[11].Value = objBITACORANAVEGACION.Plataforma;
            prms[11].ParameterName = "@plataforma";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(12);
            EBITACORANAVEGACION objBITACORANAVEGACION = obj as EBITACORANAVEGACION;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objBITACORANAVEGACION.CodigoBitacora;
            prms[0].ParameterName = "@codigo_bitacora";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objBITACORANAVEGACION.RutUsuario;
            prms[1].ParameterName = "@rut_usuario";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objBITACORANAVEGACION.CodActivUsr;
            prms[2].ParameterName = "@cod_activ_usr";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objBITACORANAVEGACION.UserAgent;
            prms[3].ParameterName = "@user_agent";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objBITACORANAVEGACION.DireccionIp;
            prms[4].ParameterName = "@direccion_ip";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objBITACORANAVEGACION.Pais;
            prms[5].ParameterName = "@pais";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objBITACORANAVEGACION.PaginaNavegacion;
            prms[6].ParameterName = "@pagina_navegacion";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objBITACORANAVEGACION.Sesion;
            prms[7].ParameterName = "@sesion";
            	
            prms[8] = db.GetParameter();
            prms[8].Value = objBITACORANAVEGACION.SesionID;
            prms[8].ParameterName = "@sesionID";
            	
            prms[9] = db.GetParameter();
            prms[9].Value = objBITACORANAVEGACION.VersionBrowser;
            prms[9].ParameterName = "@version_browser";
            	
            prms[10] = db.GetParameter();
            prms[10].Value = objBITACORANAVEGACION.Browser;
            prms[10].ParameterName = "@browser";
            	
            prms[11] = db.GetParameter();
            prms[11].Value = objBITACORANAVEGACION.Plataforma;
            prms[11].ParameterName = "@plataforma";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EBITACORANAVEGACION objRoot = obj as EBITACORANAVEGACION;

            objRoot.CodigoBitacora = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EBITACORANAVEGACION objBITACORANAVEGACION = obj as EBITACORANAVEGACION;
    
            //Poner las rutinas del Tools que se necesiten
            
            objBITACORANAVEGACION.CodigoBitacora = Utiles.ConvertToDecimal(dr["codigo_bitacora"]);
            
            objBITACORANAVEGACION.RutUsuario = Utiles.ConvertToInt64(dr["rut_usuario"]);
            
            objBITACORANAVEGACION.CodActivUsr = Utiles.ConvertToDecimal(dr["cod_activ_usr"]);
            
            objBITACORANAVEGACION.UserAgent = Utiles.ConvertToString(dr["user_agent"]);
            
            objBITACORANAVEGACION.DireccionIp = Utiles.ConvertToString(dr["direccion_ip"]);
            
            objBITACORANAVEGACION.Pais = Utiles.ConvertToString(dr["pais"]);
            
            objBITACORANAVEGACION.PaginaNavegacion = Utiles.ConvertToString(dr["pagina_navegacion"]);
            
            objBITACORANAVEGACION.Sesion = Utiles.ConvertToInt32(dr["sesion"]);
            
            objBITACORANAVEGACION.SesionID = Utiles.ConvertToString(dr["sesionID"]);
            
            objBITACORANAVEGACION.VersionBrowser = Utiles.ConvertToString(dr["version_browser"]);
            
            objBITACORANAVEGACION.Browser = Utiles.ConvertToString(dr["browser"]);

            objBITACORANAVEGACION.Plataforma = Utiles.ConvertToString(dr["plataforma"]);
            
        }

        #endregion

	}
}
