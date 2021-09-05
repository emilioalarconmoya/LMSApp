

using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPRODUCTOCANJEADO.
	/// </summary>
	public class DLPRODUCTOCANJEADO : DLBase
	{
		public DLPRODUCTOCANJEADO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_PRODUCTO_CANJEADO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_PRODUCTO_CANJEADO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_PRODUCTO_CANJEADO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_PRODUCTO_CANJEADO";
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
            EPRODUCTOCANJEADO objPRODUCTOCANJEADO = obj as EPRODUCTOCANJEADO;

            prms[0] = db.GetParameter();
            prms[0].Value = objPRODUCTOCANJEADO.CODPRODUCTO;
            prms[0].ParameterName = "@COD_PRODUCTO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(7);
            EPRODUCTOCANJEADO objPRODUCTOCANJEADO = obj as EPRODUCTOCANJEADO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPRODUCTOCANJEADO.CODPRODUCTO;
            prms[0].ParameterName = "@COD_PRODUCTO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPRODUCTOCANJEADO.CODMOVIMIENTO;
            prms[1].ParameterName = "@COD_MOVIMIENTO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objPRODUCTOCANJEADO.CODTIENDA;
            prms[2].ParameterName = "@COD_TIENDA";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objPRODUCTOCANJEADO.COSTOPUNTOS;
            prms[3].ParameterName = "@COSTO_PUNTOS";

            prms[4] = db.GetParameter();
            prms[4].Value = objPRODUCTOCANJEADO.FLAG_ENTREGADO;
            prms[4].ParameterName = "@FLAG_ENTREGADO";

            prms[5] = db.GetParameter();
            prms[5].Value = objPRODUCTOCANJEADO.FECHA_ENTREGA;
            prms[5].ParameterName = "@FECHA_ENTREGA";

            prms[6] = db.GetParameter();
            prms[6].Value = objPRODUCTOCANJEADO.ENTREGADO_POR;
            prms[6].ParameterName = "@ENTREGADO_POR";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(7);
            EPRODUCTOCANJEADO objPRODUCTOCANJEADO = obj as EPRODUCTOCANJEADO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPRODUCTOCANJEADO.CODPRODUCTO;
            prms[0].ParameterName = "@COD_PRODUCTO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPRODUCTOCANJEADO.CODMOVIMIENTO;
            prms[1].ParameterName = "@COD_MOVIMIENTO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objPRODUCTOCANJEADO.CODTIENDA;
            prms[2].ParameterName = "@COD_TIENDA";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objPRODUCTOCANJEADO.COSTOPUNTOS;
            prms[3].ParameterName = "@COSTO_PUNTOS";

            prms[4] = db.GetParameter();
            prms[4].Value = objPRODUCTOCANJEADO.FLAG_ENTREGADO;
            prms[4].ParameterName = "@FLAG_ENTREGADO";

            prms[5] = db.GetParameter();
            prms[5].Value = objPRODUCTOCANJEADO.FECHA_ENTREGA;
            prms[5].ParameterName = "@FECHA_ENTREGA";

            prms[6] = db.GetParameter();
            prms[6].Value = objPRODUCTOCANJEADO.ENTREGADO_POR;
            prms[6].ParameterName = "@ENTREGADO_POR";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EPRODUCTOCANJEADO objRoot = obj as EPRODUCTOCANJEADO;

            objRoot.CODPRODUCTO = Utiles.ConvertToString(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EPRODUCTOCANJEADO objPRODUCTOCANJEADO = obj as EPRODUCTOCANJEADO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objPRODUCTOCANJEADO.CODPRODUCTO = Utiles.ConvertToString(dr["COD_PRODUCTO"]);
            
            objPRODUCTOCANJEADO.CODMOVIMIENTO = Utiles.ConvertToDecimal(dr["COD_MOVIMIENTO"]);
            
            objPRODUCTOCANJEADO.CODTIENDA = Utiles.ConvertToString(dr["COD_TIENDA"]);
            
            objPRODUCTOCANJEADO.COSTOPUNTOS = Utiles.ConvertToInt32(dr["COSTO_PUNTOS"]);

            objPRODUCTOCANJEADO.FLAG_ENTREGADO = Utiles.ConvertToBoolean(dr["FLAG_ENTREGADO"]);

            objPRODUCTOCANJEADO.FECHA_ENTREGA = Utiles.ConvertToDateTime(dr["FECHA_ENTREGA"]);

            objPRODUCTOCANJEADO.ENTREGADO_POR = Utiles.ConvertToInt64(dr["ENTREGADO_POR"]);

        }

        #endregion

	}
}
