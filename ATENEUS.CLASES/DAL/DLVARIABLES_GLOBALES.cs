
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLVARIABLESGLOBALES.
	/// </summary>
	public class DLVARIABLESGLOBALES : DLBase
	{
		public DLVARIABLESGLOBALES()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_VARIABLES_GLOBALES";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_VARIABLES_GLOBALES";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_VARIABLES_GLOBALES";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_VARIABLES_GLOBALES";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@nombre";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EVARIABLESGLOBALES objVARIABLESGLOBALES = obj as EVARIABLESGLOBALES;

            prms[0] = db.GetParameter();
            prms[0].Value = objVARIABLESGLOBALES.Nombre;
            prms[0].ParameterName = "@nombre";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EVARIABLESGLOBALES objVARIABLESGLOBALES = obj as EVARIABLESGLOBALES;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objVARIABLESGLOBALES.Valor;
            prms[1].ParameterName = "@valor";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EVARIABLESGLOBALES objVARIABLESGLOBALES = obj as EVARIABLESGLOBALES;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objVARIABLESGLOBALES.Nombre;
            prms[0].ParameterName = "@nombre";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objVARIABLESGLOBALES.Valor;
            prms[1].ParameterName = "@valor";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EVARIABLESGLOBALES objRoot = obj as EVARIABLESGLOBALES;

            objRoot.Nombre = Utiles.ConvertToString(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EVARIABLESGLOBALES objVARIABLESGLOBALES = obj as EVARIABLESGLOBALES;
    
            //Poner las rutinas del Tools que se necesiten
            
            objVARIABLESGLOBALES.Nombre = Utiles.ConvertToString(dr["nombre"]);
            
            objVARIABLESGLOBALES.Valor = Utiles.ConvertToString(dr["valor"]);
            
        }

        #endregion

	}
}
