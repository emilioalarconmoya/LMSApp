
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLBITACORAREPOSITORIO.
	/// </summary>
	public class DLBITACORAREPOSITORIO : DLBase
	{
		public DLBITACORAREPOSITORIO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_BITACORA_REPOSITORIO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_BITACORA_REPOSITORIO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_BITACORA_REPOSITORIO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_BITACORA_REPOSITORIO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_bitacora";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EBITACORAREPOSITORIO objBITACORAREPOSITORIO = obj as EBITACORAREPOSITORIO;

            prms[0] = db.GetParameter();
            prms[0].Value = objBITACORAREPOSITORIO.CodBitacora;
            prms[0].ParameterName = "@cod_bitacora";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(4);
            EBITACORAREPOSITORIO objBITACORAREPOSITORIO = obj as EBITACORAREPOSITORIO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objBITACORAREPOSITORIO.RutUsuario;
            prms[1].ParameterName = "@rut_usuario";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objBITACORAREPOSITORIO.CodUnidad;
            prms[2].ParameterName = "@cod_unidad";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objBITACORAREPOSITORIO.CodTipoBitacora;
            prms[3].ParameterName = "@cod_tipo_bitacora";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objBITACORAREPOSITORIO.FechaHora;
            prms[4].ParameterName = "@fecha_hora";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            EBITACORAREPOSITORIO objBITACORAREPOSITORIO = obj as EBITACORAREPOSITORIO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objBITACORAREPOSITORIO.CodBitacora;
            prms[0].ParameterName = "@cod_bitacora";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objBITACORAREPOSITORIO.RutUsuario;
            prms[1].ParameterName = "@rut_usuario";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objBITACORAREPOSITORIO.CodUnidad;
            prms[2].ParameterName = "@cod_unidad";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objBITACORAREPOSITORIO.CodTipoBitacora;
            prms[3].ParameterName = "@cod_tipo_bitacora";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objBITACORAREPOSITORIO.FechaHora;
            prms[4].ParameterName = "@fecha_hora";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EBITACORAREPOSITORIO objRoot = obj as EBITACORAREPOSITORIO;

            objRoot.CodBitacora = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EBITACORAREPOSITORIO objBITACORAREPOSITORIO = obj as EBITACORAREPOSITORIO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objBITACORAREPOSITORIO.CodBitacora = Utiles.ConvertToDecimal(dr["cod_bitacora"]);
            
            objBITACORAREPOSITORIO.RutUsuario = Utiles.ConvertToInt64(dr["rut_usuario"]);
            
            objBITACORAREPOSITORIO.CodUnidad = Utiles.ConvertToInt16(dr["cod_unidad"]);
            
            objBITACORAREPOSITORIO.CodTipoBitacora = Utiles.ConvertToDecimal(dr["cod_tipo_bitacora"]);

            objBITACORAREPOSITORIO.FechaHora = Utiles.ConvertToDateTime(dr["fecha_hora"]);
            
        }

        #endregion

	}
}
