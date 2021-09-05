

using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLTIENDA.
	/// </summary>
	public class DLTIENDA : DLBase
	{
		public DLTIENDA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_TIENDA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_TIENDA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_TIENDA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_TIENDA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_TIENDA";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ETIENDA objTIENDA = obj as ETIENDA;

            prms[0] = db.GetParameter();
            prms[0].Value = objTIENDA.CODTIENDA;
            prms[0].ParameterName = "@COD_TIENDA";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(7);
            ETIENDA objTIENDA = obj as ETIENDA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objTIENDA.CODTIENDA;
            prms[0].ParameterName = "@COD_TIENDA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objTIENDA.CODATRIBUTO;
            prms[1].ParameterName = "@COD_ATRIBUTO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objTIENDA.CODCARACTERISTICA;
            prms[2].ParameterName = "@COD_CARACTERISTICA";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objTIENDA.NOMBRE;
            prms[3].ParameterName = "@NOMBRE";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objTIENDA.INICIO;
            prms[4].ParameterName = "@INICIO";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objTIENDA.FIN;
            prms[5].ParameterName = "@FIN";

            prms[6] = db.GetParameter();
            prms[6].Value = objTIENDA.CodEmpresa;
            prms[6].ParameterName = "@cod_empresa";


            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(6);
            ETIENDA objTIENDA = obj as ETIENDA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objTIENDA.CODTIENDA;
            prms[0].ParameterName = "@COD_TIENDA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objTIENDA.CODATRIBUTO;
            prms[1].ParameterName = "@COD_ATRIBUTO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objTIENDA.CODCARACTERISTICA;
            prms[2].ParameterName = "@COD_CARACTERISTICA";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objTIENDA.NOMBRE;
            prms[3].ParameterName = "@NOMBRE";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objTIENDA.INICIO;
            prms[4].ParameterName = "@INICIO";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objTIENDA.FIN;
            prms[5].ParameterName = "@FIN";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ETIENDA objRoot = obj as ETIENDA;

            objRoot.CODTIENDA = Utiles.ConvertToString(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ETIENDA objTIENDA = obj as ETIENDA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objTIENDA.CODTIENDA = Utiles.ConvertToString(dr["COD_TIENDA"]);
            
            objTIENDA.CODATRIBUTO = Utiles.ConvertToInt16(dr["COD_ATRIBUTO"]);
            
            objTIENDA.CODCARACTERISTICA = Utiles.ConvertToInt16(dr["COD_CARACTERISTICA"]);
            
            objTIENDA.NOMBRE = Utiles.ConvertToString(dr["NOMBRE"]);
            
            objTIENDA.INICIO = Utiles.ConvertToDateTime(dr["INICIO"]);
            
            objTIENDA.FIN = Utiles.ConvertToDateTime(dr["FIN"]);
            
        }

        #endregion

	}
}
