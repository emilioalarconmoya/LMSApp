
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLMODULO.
	/// </summary>
	public class DLMODULO : DLBase
	{
		public DLMODULO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_MODULO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_MODULO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_MODULO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_MODULO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_modulo";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EMODULO objMODULO = obj as EMODULO;

            prms[0] = db.GetParameter();
            prms[0].Value = objMODULO.CodModulo;
            prms[0].ParameterName = "@cod_modulo";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EMODULO objMODULO = obj as EMODULO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objMODULO.Nombre;
            prms[1].ParameterName = "@nombre";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EMODULO objMODULO = obj as EMODULO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objMODULO.CodModulo;
            prms[0].ParameterName = "@cod_modulo";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objMODULO.Nombre;
            prms[1].ParameterName = "@nombre";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EMODULO objRoot = obj as EMODULO;

            objRoot.CodModulo = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EMODULO objMODULO = obj as EMODULO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objMODULO.CodModulo = Utiles.ConvertToInt16(dr["cod_modulo"]);
            
            objMODULO.Nombre = Utiles.ConvertToString(dr["nombre"]);
            
        }

        #endregion

	}
}
