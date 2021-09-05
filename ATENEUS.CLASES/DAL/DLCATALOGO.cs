
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLCATALOGO.
	/// </summary>
	public class DLCATALOGO : DLBase
	{
		public DLCATALOGO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_CATALOGO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_CATALOGO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_CATALOGO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_CATALOGO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_CATALOGO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ECATALOGO objCATALOGO = obj as ECATALOGO;

            prms[0] = db.GetParameter();
            prms[0].Value = objCATALOGO.Codcatalogo;
            prms[0].ParameterName = "@cod_CATALOGO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ECATALOGO objCATALOGO = obj as ECATALOGO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCATALOGO.Nombre;
            prms[0].ParameterName = "@nombre";

            prms[1] = db.GetParameter();
            prms[1].Value = objCATALOGO.FlagActivo;
            prms[1].ParameterName = "@flag_activo";

            prms[2] = db.GetParameter();
            prms[2].Value = objCATALOGO.CodEmpresa;
            prms[2].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(4);
            ECATALOGO objCATALOGO = obj as ECATALOGO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCATALOGO.Codcatalogo;
            prms[0].ParameterName = "@cod_CATALOGO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCATALOGO.Nombre;
            prms[1].ParameterName = "@nombre";

            prms[2] = db.GetParameter();
            prms[2].Value = objCATALOGO.FlagActivo;
            prms[2].ParameterName = "@flag_activo";

            prms[3] = db.GetParameter();
            prms[3].Value = objCATALOGO.CodEmpresa;
            prms[3].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ECATALOGO objRoot = obj as ECATALOGO;

            objRoot.Codcatalogo = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ECATALOGO objCATALOGO = obj as ECATALOGO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objCATALOGO.Codcatalogo = Utiles.ConvertToInt16(dr["cod_CATALOGO"]);
            
            objCATALOGO.Nombre = Utiles.ConvertToString(dr["nombre_CATALOGO"]);

            objCATALOGO.FlagActivo = Utiles.ConvertToBoolean(dr["flag_activo"]);

            objCATALOGO.CodEmpresa = Utiles.ConvertToInt32(dr["cod_empresa"]);


        }

        #endregion

	}
}
