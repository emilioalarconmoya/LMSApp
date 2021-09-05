
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPROVEEDOR.
	/// </summary>
	public class DLPROVEEDOR : DLBase
	{
		public DLPROVEEDOR()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_PROVEEDOR";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_PROVEEDOR";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_PROVEEDOR";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_PROVEEDOR";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_proveedor";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EPROVEEDOR objPROVEEDOR = obj as EPROVEEDOR;

            prms[0] = db.GetParameter();
            prms[0].Value = objPROVEEDOR.CodProveedor;
            prms[0].ParameterName = "@cod_proveedor";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(12);
            EPROVEEDOR objPROVEEDOR = obj as EPROVEEDOR;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = Serial();
            prms[0].ParameterName = "@COD_PROVEEDOR";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPROVEEDOR.Nombre;
            prms[1].ParameterName = "@nombre";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objPROVEEDOR.Direccion;
            prms[2].ParameterName = "@direccion";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objPROVEEDOR.Comuna;
            prms[3].ParameterName = "@comuna";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objPROVEEDOR.Ciudad;
            prms[4].ParameterName = "@ciudad";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objPROVEEDOR.CodigoPostal;
            prms[5].ParameterName = "@codigo_postal";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objPROVEEDOR.Pais;
            prms[6].ParameterName = "@pais";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objPROVEEDOR.Fono;
            prms[7].ParameterName = "@fono";
            	
            prms[8] = db.GetParameter();
            prms[8].Value = objPROVEEDOR.Rut;
            prms[8].ParameterName = "@rut";

            prms[9] = db.GetParameter();
            prms[9].Value = objPROVEEDOR.ClaveSence;
            prms[9].ParameterName = "@clave_sence";

            prms[10] = db.GetParameter();
            prms[10].Value = objPROVEEDOR.CodEmpresa;
            prms[10].ParameterName = "@cod_empresa";
			
			prms[11] = db.GetParameter();
            prms[11].Value = objPROVEEDOR.Token;
            prms[11].ParameterName = "@token";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(11);
            EPROVEEDOR objPROVEEDOR = obj as EPROVEEDOR;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPROVEEDOR.CodProveedor;
            prms[0].ParameterName = "@cod_proveedor";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPROVEEDOR.Nombre;
            prms[1].ParameterName = "@nombre";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objPROVEEDOR.Direccion;
            prms[2].ParameterName = "@direccion";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objPROVEEDOR.Comuna;
            prms[3].ParameterName = "@comuna";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objPROVEEDOR.Ciudad;
            prms[4].ParameterName = "@ciudad";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objPROVEEDOR.CodigoPostal;
            prms[5].ParameterName = "@codigo_postal";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objPROVEEDOR.Pais;
            prms[6].ParameterName = "@pais";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objPROVEEDOR.Fono;
            prms[7].ParameterName = "@fono";
            	
            prms[8] = db.GetParameter();
            prms[8].Value = objPROVEEDOR.Rut;
            prms[8].ParameterName = "@rut";
            	
            prms[9] = db.GetParameter();
            prms[9].Value = objPROVEEDOR.ClaveSence;
            prms[9].ParameterName = "@clave_sence";

            prms[10] = db.GetParameter();
            prms[10].Value = objPROVEEDOR.Token;
            prms[10].ParameterName = "@token";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EPROVEEDOR objRoot = obj as EPROVEEDOR;

            objRoot.CodProveedor = Utiles.ConvertToInt16(id);
        }


        public long Serial()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_serial_proveedor");
            return Utiles.ConvertToInt64(dt.Rows[0][0]);
        }
        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EPROVEEDOR objPROVEEDOR = obj as EPROVEEDOR;
    
            //Poner las rutinas del Tools que se necesiten
            
            objPROVEEDOR.CodProveedor = Utiles.ConvertToInt16(dr["cod_proveedor"]);
            
            objPROVEEDOR.Nombre = Utiles.ConvertToString(dr["nombre"]);
            
            objPROVEEDOR.Direccion = Utiles.ConvertToString(dr["direccion"]);
            
            objPROVEEDOR.Comuna = Utiles.ConvertToString(dr["comuna"]);
            
            objPROVEEDOR.Ciudad = Utiles.ConvertToString(dr["ciudad"]);
            
            objPROVEEDOR.CodigoPostal = Utiles.ConvertToString(dr["codigo_postal"]);
            
            objPROVEEDOR.Pais = Utiles.ConvertToString(dr["pais"]);
            
            objPROVEEDOR.Fono = Utiles.ConvertToString(dr["fono"]);
            
            objPROVEEDOR.Rut = Utiles.ConvertToInt64(dr["rut"]);

            objPROVEEDOR.ClaveSence = Utiles.ConvertToString(dr["clave_sence"]);

            objPROVEEDOR.Token = Utiles.ConvertToString(dr["token"]);

        }

        #endregion

	}
}
