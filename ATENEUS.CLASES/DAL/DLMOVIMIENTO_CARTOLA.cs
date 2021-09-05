

using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLMOVIMIENTOCARTOLA.
	/// </summary>
	public class DLMOVIMIENTOCARTOLA : DLBase
	{
		public DLMOVIMIENTOCARTOLA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_MOVIMIENTO_CARTOLA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_MOVIMIENTO_CARTOLA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_MOVIMIENTO_CARTOLA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_MOVIMIENTO_CARTOLA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_MOVIMIENTO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EMOVIMIENTOCARTOLA objMOVIMIENTOCARTOLA = obj as EMOVIMIENTOCARTOLA;

            prms[0] = db.GetParameter();
            prms[0].Value = objMOVIMIENTOCARTOLA.CODMOVIMIENTO;
            prms[0].ParameterName = "@COD_MOVIMIENTO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(8);
            EMOVIMIENTOCARTOLA objMOVIMIENTOCARTOLA = obj as EMOVIMIENTOCARTOLA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objMOVIMIENTOCARTOLA.SALDO;
            prms[0].ParameterName = "@SALDO";

            prms[1] = db.GetParameter();
            prms[1].Value = objMOVIMIENTOCARTOLA.CODTIPOMOVIMIENTO;
            prms[1].ParameterName = "@COD_TIPO_MOVIMIENTO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objMOVIMIENTOCARTOLA.RUTUSUARIO;
            prms[2].ParameterName = "@RUT_USUARIO";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objMOVIMIENTOCARTOLA.PUNTOS;
            prms[3].ParameterName = "@PUNTOS";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objMOVIMIENTOCARTOLA.FECHAHORA;
            prms[4].ParameterName = "@FECHA_HORA";

            prms[5] = db.GetParameter();
            prms[5].Value = objMOVIMIENTOCARTOLA.OBSERVACION;
            prms[5].ParameterName = "@OBSERVACION";

            prms[6] = db.GetParameter();
            prms[6].Value = objMOVIMIENTOCARTOLA.FECHA_CADUCIDAD;
            prms[6].ParameterName = "@FECHA_CADUCIDAD";

            prms[7] = db.GetParameter();
            prms[7].Value = objMOVIMIENTOCARTOLA.PUNTOS_USADOS;
            prms[7].ParameterName = "@PUNTOS_USADOS";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(9);
            EMOVIMIENTOCARTOLA objMOVIMIENTOCARTOLA = obj as EMOVIMIENTOCARTOLA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objMOVIMIENTOCARTOLA.CODMOVIMIENTO;
            prms[0].ParameterName = "@COD_MOVIMIENTO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objMOVIMIENTOCARTOLA.CODTIPOMOVIMIENTO;
            prms[1].ParameterName = "@COD_TIPO_MOVIMIENTO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objMOVIMIENTOCARTOLA.RUTUSUARIO;
            prms[2].ParameterName = "@RUT_USUARIO";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objMOVIMIENTOCARTOLA.PUNTOS;
            prms[3].ParameterName = "@PUNTOS";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objMOVIMIENTOCARTOLA.FECHAHORA;
            prms[4].ParameterName = "@FECHA_HORA";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objMOVIMIENTOCARTOLA.OBSERVACION;
            prms[5].ParameterName = "@OBSERVACION";

            prms[6] = db.GetParameter();
            prms[6].Value = objMOVIMIENTOCARTOLA.FECHA_CADUCIDAD;
            prms[6].ParameterName = "@FECHA_CADUCIDAD";

            prms[7] = db.GetParameter();
            prms[7].Value = objMOVIMIENTOCARTOLA.PUNTOS_USADOS;
            prms[7].ParameterName = "@PUNTOS_USADOS";

            prms[8] = db.GetParameter();
            prms[8].Value = objMOVIMIENTOCARTOLA.SALDO;
            prms[8].ParameterName = "@SALDO";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EMOVIMIENTOCARTOLA objRoot = obj as EMOVIMIENTOCARTOLA;

            objRoot.CODMOVIMIENTO = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EMOVIMIENTOCARTOLA objMOVIMIENTOCARTOLA = obj as EMOVIMIENTOCARTOLA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objMOVIMIENTOCARTOLA.CODMOVIMIENTO = Utiles.ConvertToInt16(dr["COD_MOVIMIENTO"]);
            
            objMOVIMIENTOCARTOLA.CODTIPOMOVIMIENTO = Utiles.ConvertToInt16(dr["COD_TIPO_MOVIMIENTO"]);
            
            objMOVIMIENTOCARTOLA.RUTUSUARIO = Utiles.ConvertToInt64(dr["RUT_USUARIO"]);
            
            objMOVIMIENTOCARTOLA.PUNTOS = Utiles.ConvertToInt16(dr["PUNTOS"]);
            
            objMOVIMIENTOCARTOLA.FECHAHORA = Utiles.ConvertToDateTime(dr["FECHA_HORA"]);
            
            objMOVIMIENTOCARTOLA.OBSERVACION = Utiles.ConvertToString(dr["OBSERVACION"]);

            objMOVIMIENTOCARTOLA.SALDO = Utiles.ConvertToInt32(dr["SALDO"]);

            objMOVIMIENTOCARTOLA.FECHA_CADUCIDAD = Utiles.ConvertToDateTime(dr["FECHA_CADUCIDAD"]);

            objMOVIMIENTOCARTOLA.PUNTOS_USADOS = Utiles.ConvertToInt32(dr["PUNTOS_USADOS"]);

        }

        #endregion

	}
}
