
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLMALLA.
	/// </summary>
	public class DLMALLA : DLBase
	{
		public DLMALLA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_MALLA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_MALLA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_MALLA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_MALLA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@Cod_Malla";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EMALLA objMALLA = obj as EMALLA;

            prms[0] = db.GetParameter();
            prms[0].Value = objMALLA.CodMalla;
            prms[0].ParameterName = "@Cod_Malla";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(4);
            EMALLA objMALLA = obj as EMALLA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objMALLA.Nombre;
            prms[0].ParameterName = "@Nombre";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objMALLA.Descripcion;
            prms[1].ParameterName = "@Descripcion";

            prms[2] = db.GetParameter();
            prms[2].Value = objMALLA.CodEmpresa;
            prms[2].ParameterName = "@COD_EMPRESA";

            prms[3] = db.GetParameter();
            prms[3].Value = objMALLA.Vigente;
            prms[3].ParameterName = "@vigente";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            EMALLA objMALLA = obj as EMALLA;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objMALLA.CodMalla;
            prms[0].ParameterName = "@Cod_Malla";

            prms[1] = db.GetParameter();
            prms[1].Value = objMALLA.Nombre;
            prms[1].ParameterName = "@Nombre";

            prms[2] = db.GetParameter();
            prms[2].Value = objMALLA.Descripcion;
            prms[2].ParameterName = "@Descripcion";

            prms[3] = db.GetParameter();
            prms[3].Value = objMALLA.Vigente;
            prms[3].ParameterName = "@Vigente";

            prms[4] = db.GetParameter();
            prms[4].Value = objMALLA.CodEmpresa;
            prms[4].ParameterName = "@COD_EMPRESA";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EMALLA objRoot = obj as EMALLA;

            objRoot.CodMalla = Convert.ToInt32(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EMALLA objMALLA = obj as EMALLA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objMALLA.CodMalla = Utiles.ConvertToInt32(dr["Cod_Malla"]);
            
            objMALLA.Nombre = Utiles.ConvertToString(dr["Nombre"]);

            objMALLA.Descripcion = Utiles.ConvertToString(dr["Descripcion"]);

            objMALLA.CodEmpresa = Utiles.ConvertToInt32(dr["Cod_EMPRESA"]);

            objMALLA.Vigente = Utiles.ConvertToBoolean(dr["flag_vigente"]);

        }

        #endregion

	}
}
