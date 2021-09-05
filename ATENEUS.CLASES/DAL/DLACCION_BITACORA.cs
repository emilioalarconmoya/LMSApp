
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLACCIONBITACORA.
	/// </summary>
	public class DLACCIONBITACORA : DLBase
	{
		public DLACCIONBITACORA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_ACCION_BITACORA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_ACCION_BITACORA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_ACCION_BITACORA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_ACCION_BITACORA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_accion";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EACCIONBITACORA objACCIONBITACORA = obj as EACCIONBITACORA;

            prms[0] = db.GetParameter();
            prms[0].Value = objACCIONBITACORA.CodAccion;
            prms[0].ParameterName = "@cod_accion";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EACCIONBITACORA objACCIONBITACORA = obj as EACCIONBITACORA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objACCIONBITACORA.Descripcion;
            prms[1].ParameterName = "@descripcion";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EACCIONBITACORA objACCIONBITACORA = obj as EACCIONBITACORA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objACCIONBITACORA.CodAccion;
            prms[0].ParameterName = "@cod_accion";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objACCIONBITACORA.Descripcion;
            prms[1].ParameterName = "@descripcion";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EACCIONBITACORA objRoot = obj as EACCIONBITACORA;

            objRoot.CodAccion = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EACCIONBITACORA objACCIONBITACORA = obj as EACCIONBITACORA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objACCIONBITACORA.CodAccion = Utiles.ConvertToDecimal(dr["cod_accion"]);

            objACCIONBITACORA.Descripcion = Utiles.ConvertToString(dr["descripcion"]);
            
        }

        #endregion

	}
}
