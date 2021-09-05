

using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPRODUCTOTIENDA.
	/// </summary>
	public class DLPRODUCTOTIENDA : DLBase
	{
		public DLPRODUCTOTIENDA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_PRODUCTO_TIENDA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_PRODUCTO_TIENDA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_PRODUCTO_TIENDA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_PRODUCTO_TIENDA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_PRODUCTO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EPRODUCTOTIENDA objPRODUCTOTIENDA = obj as EPRODUCTOTIENDA;

            prms[0] = db.GetParameter();
            prms[0].Value = objPRODUCTOTIENDA.CODPRODUCTO;
            prms[0].ParameterName = "@COD_PRODUCTO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(6);
            EPRODUCTOTIENDA objPRODUCTOTIENDA = obj as EPRODUCTOTIENDA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPRODUCTOTIENDA.CODPRODUCTO;
            prms[0].ParameterName = "@COD_PRODUCTO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPRODUCTOTIENDA.CODTIENDA;
            prms[1].ParameterName = "@COD_TIENDA";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objPRODUCTOTIENDA.STOCK;
            prms[2].ParameterName = "@STOCK";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objPRODUCTOTIENDA.COSTOPUNTOS;
            prms[3].ParameterName = "@COSTO_PUNTOS";

            prms[4] = db.GetParameter();
            prms[4].Value = objPRODUCTOTIENDA.SALDO_INICIAL;
            prms[4].ParameterName = "@SALDO_INICIAL";

            prms[5] = db.GetParameter();
            prms[5].Value = objPRODUCTOTIENDA.MAX_CANJEES;
            prms[5].ParameterName = "@MAX_CANJEES";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(6);
            EPRODUCTOTIENDA objPRODUCTOTIENDA = obj as EPRODUCTOTIENDA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPRODUCTOTIENDA.CODPRODUCTO;
            prms[0].ParameterName = "@COD_PRODUCTO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPRODUCTOTIENDA.CODTIENDA;
            prms[1].ParameterName = "@COD_TIENDA";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objPRODUCTOTIENDA.STOCK;
            prms[2].ParameterName = "@STOCK";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objPRODUCTOTIENDA.COSTOPUNTOS;
            prms[3].ParameterName = "@COSTO_PUNTOS";

            prms[4] = db.GetParameter();
            prms[4].Value = objPRODUCTOTIENDA.SALDO_INICIAL;
            prms[4].ParameterName = "@SALDO_INICIAL";

            prms[5] = db.GetParameter();
            prms[5].Value = objPRODUCTOTIENDA.MAX_CANJEES;
            prms[5].ParameterName = "@MAX_CANJEES";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EPRODUCTOTIENDA objRoot = obj as EPRODUCTOTIENDA;

            objRoot.CODPRODUCTO = Utiles.ConvertToString(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EPRODUCTOTIENDA objPRODUCTOTIENDA = obj as EPRODUCTOTIENDA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objPRODUCTOTIENDA.CODPRODUCTO = Utiles.ConvertToString(dr["COD_PRODUCTO"]);
            
            objPRODUCTOTIENDA.CODTIENDA = Utiles.ConvertToString(dr["COD_TIENDA"]);
            
            objPRODUCTOTIENDA.STOCK = Utiles.ConvertToInt32(dr["STOCK"]);
            
            objPRODUCTOTIENDA.COSTOPUNTOS = Utiles.ConvertToInt32(dr["COSTO_PUNTOS"]);

            objPRODUCTOTIENDA.SALDO_INICIAL = Utiles.ConvertToInt32(dr["SALDO_INICIAL"]);

            objPRODUCTOTIENDA.MAX_CANJEES = Utiles.ConvertToInt32(dr["MAX_CANJEES"]);

        }

        #endregion

	}
}
