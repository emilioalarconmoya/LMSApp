
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLCARACTERISTICA.
	/// </summary>
	public class DLCARACTERISTICA : DLBase
	{
		public DLCARACTERISTICA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_CARACTERISTICA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_CARACTERISTICA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_CARACTERISTICA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_CARACTERISTICA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_caracteristica";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ECARACTERISTICA objCARACTERISTICA = obj as ECARACTERISTICA;

            prms[0] = db.GetParameter();
            prms[0].Value = objCARACTERISTICA.CodCaracteristica;
            prms[0].ParameterName = "@cod_caracteristica";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ECARACTERISTICA objCARACTERISTICA = obj as ECARACTERISTICA;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = Serial();
            prms[0].ParameterName = "@COD_CARACTERISTICA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCARACTERISTICA.Nombre;
            prms[1].ParameterName = "@nombre";

            prms[2] = db.GetParameter();
            prms[2].Value = objCARACTERISTICA.CodEmpresa;
            prms[2].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ECARACTERISTICA objCARACTERISTICA = obj as ECARACTERISTICA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCARACTERISTICA.CodCaracteristica;
            prms[0].ParameterName = "@cod_caracteristica";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCARACTERISTICA.Nombre;
            prms[1].ParameterName = "@nombre";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ECARACTERISTICA objRoot = obj as ECARACTERISTICA;

            objRoot.CodCaracteristica = Utiles.ConvertToInt16(id);
        }

        public long Serial()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_serial_caracteristica");
            return Utiles.ConvertToInt64(dt.Rows[0][0]);
        }

        public Boolean EnUso(Int16 CodCaracteristica)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodCaracteristica;
            prms[0].ParameterName = "@CodCaracteristica";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_caracteristica_en_uso", prms);
            return Utiles.ConvertToBoolean(dt.Rows[0][0]);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ECARACTERISTICA objCARACTERISTICA = obj as ECARACTERISTICA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objCARACTERISTICA.CodCaracteristica = Utiles.ConvertToInt16(dr["cod_caracteristica"]);

            objCARACTERISTICA.Nombre = Utiles.ConvertToString(dr["nombre"]);
            
        }

        #endregion

	}
}
