

using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLTIPOMOVIMIENTO.
	/// </summary>
	public class DLTIPOMOVIMIENTO : DLBase
	{
		public DLTIPOMOVIMIENTO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_TIPO_MOVIMIENTO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_TIPO_MOVIMIENTO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_TIPO_MOVIMIENTO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_TIPO_MOVIMIENTO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_TIPO_MOVIMIENTO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ETIPOMOVIMIENTO objTIPOMOVIMIENTO = obj as ETIPOMOVIMIENTO;

            prms[0] = db.GetParameter();
            prms[0].Value = objTIPOMOVIMIENTO.CODTIPOMOVIMIENTO;
            prms[0].ParameterName = "@COD_TIPO_MOVIMIENTO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ETIPOMOVIMIENTO objTIPOMOVIMIENTO = obj as ETIPOMOVIMIENTO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objTIPOMOVIMIENTO.CODTIPOMOVIMIENTO;
            prms[0].ParameterName = "@COD_TIPO_MOVIMIENTO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objTIPOMOVIMIENTO.NOMBRE;
            prms[1].ParameterName = "@NOMBRE";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ETIPOMOVIMIENTO objTIPOMOVIMIENTO = obj as ETIPOMOVIMIENTO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objTIPOMOVIMIENTO.CODTIPOMOVIMIENTO;
            prms[0].ParameterName = "@COD_TIPO_MOVIMIENTO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objTIPOMOVIMIENTO.NOMBRE;
            prms[1].ParameterName = "@NOMBRE";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ETIPOMOVIMIENTO objRoot = obj as ETIPOMOVIMIENTO;

            objRoot.CODTIPOMOVIMIENTO = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ETIPOMOVIMIENTO objTIPOMOVIMIENTO = obj as ETIPOMOVIMIENTO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objTIPOMOVIMIENTO.CODTIPOMOVIMIENTO = Utiles.ConvertToInt16(dr["COD_TIPO_MOVIMIENTO"]);
            
            objTIPOMOVIMIENTO.NOMBRE = Utiles.ConvertToString(dr["NOMBRE"]);
            
        }

        #endregion

	}
}
