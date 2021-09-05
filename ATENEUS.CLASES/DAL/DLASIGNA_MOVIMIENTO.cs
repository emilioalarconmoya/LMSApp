

using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLASIGNAMOVIMIENTO.
	/// </summary>
	public class DLASIGNAMOVIMIENTO : DLBase
	{
		public DLASIGNAMOVIMIENTO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_ASIGNA_MOVIMIENTO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_ASIGNA_MOVIMIENTO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_ASIGNA_MOVIMIENTO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_ASIGNA_MOVIMIENTO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_MOVIMIENTO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EASIGNAMOVIMIENTO objASIGNAMOVIMIENTO = obj as EASIGNAMOVIMIENTO;

            prms[0] = db.GetParameter();
            prms[0].Value = objASIGNAMOVIMIENTO.CODMOVIMIENTO;
            prms[0].ParameterName = "@COD_MOVIMIENTO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EASIGNAMOVIMIENTO objASIGNAMOVIMIENTO = obj as EASIGNAMOVIMIENTO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objASIGNAMOVIMIENTO.CODMOVIMIENTO;
            prms[0].ParameterName = "@COD_MOVIMIENTO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objASIGNAMOVIMIENTO.RUTUSUARIO;
            prms[1].ParameterName = "@RUT_USUARIO";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EASIGNAMOVIMIENTO objASIGNAMOVIMIENTO = obj as EASIGNAMOVIMIENTO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objASIGNAMOVIMIENTO.CODMOVIMIENTO;
            prms[0].ParameterName = "@COD_MOVIMIENTO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objASIGNAMOVIMIENTO.RUTUSUARIO;
            prms[1].ParameterName = "@RUT_USUARIO";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EASIGNAMOVIMIENTO objRoot = obj as EASIGNAMOVIMIENTO;

            objRoot.CODMOVIMIENTO = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EASIGNAMOVIMIENTO objASIGNAMOVIMIENTO = obj as EASIGNAMOVIMIENTO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objASIGNAMOVIMIENTO.CODMOVIMIENTO = Utiles.ConvertToDecimal(dr["COD_MOVIMIENTO"]);
            
            objASIGNAMOVIMIENTO.RUTUSUARIO = Utiles.ConvertToInt64(dr["RUT_USUARIO"]);
            
        }

        #endregion

	}
}
