
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLUNIDAD.
	/// </summary>
	public class DLENCUESTASATISFACCION : DLBase
	{
		public DLENCUESTASATISFACCION()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_UNIDAD";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_ENCUESTA_SATISFACCION";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_ENCUESTA_SATISFACCION";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_ENCUESTA_SATISFACCION";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_ENCUESTA_SATISFACCION";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EUNIDAD objUNIDAD = obj as EUNIDAD;

            prms[0] = db.GetParameter();
            prms[0].Value = objUNIDAD.CodUnidad;
            prms[0].ParameterName = "@COD_ENCUESTA_SATISFACCION";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            EENCUESTASATISFACCION objenc = obj as EENCUESTASATISFACCION;

            //Poner las rutinas del Tools que se necesiten  

            prms[0] = db.GetParameter();
            prms[0].Value = Serial();
            prms[0].ParameterName = "@COD_ENCUESTA_SATISFACCION";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objenc.Nombre;
            prms[1].ParameterName = "@NOMBRE_ENCUESTA";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objenc.Descripcion;
            prms[2].ParameterName = "@descripcion";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objenc.CodEmpresa;
            prms[3].ParameterName = "@cod_empresa";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objenc.Activo;
            prms[4].ParameterName = "@flag_activo";
            	
            


            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(4);
            EENCUESTASATISFACCION objenc = obj as EENCUESTASATISFACCION;

            //Poner las rutinas del Tools que se necesiten  

            prms[0] = db.GetParameter();
            prms[0].Value = objenc.CodEncuestaSatisfaccion;
            prms[0].ParameterName = "@COD_ENCUESTA_SATISFACCION";

            prms[1] = db.GetParameter();
            prms[1].Value = objenc.Nombre;
            prms[1].ParameterName = "@NOMBRE_ENCUESTA";

            prms[2] = db.GetParameter();
            prms[2].Value = objenc.Descripcion;
            prms[2].ParameterName = "@descripcion";

            prms[3] = db.GetParameter();
            prms[3].Value = objenc.Activo;
            prms[3].ParameterName = "@flag_activo";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EENCUESTASATISFACCION objRoot = obj as EENCUESTASATISFACCION;

            objRoot.CodEncuestaSatisfaccion = Utiles.ConvertToInt16(id);
        }


        public Boolean Existe(long Cod)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = Cod;
            prms[0].ParameterName = "@codigo";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_existe_encuesta_satisfaccion", prms);

            return Utiles.ConvertToBoolean(dt.Rows[0][0]);
        }

        public Int16 Serial()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_serial_ENCUESTA_SATISFACCION");
            return Utiles.ConvertToInt16(dt.Rows[0][0]);
        }

        public void ActualizaEstadoEncuestaSatisfaccion(long CodencuestaSatis, Boolean flagActivo)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = CodencuestaSatis;
            prms[0].ParameterName = "@COD_ENCUESTA_SATISFACCION";

            prms[1] = db.GetParameter();
            prms[1].Value = flagActivo;
            prms[1].ParameterName = "@flag_activo";

            db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_update_ESTADO_ENCUESTA_SATISFACCION_FLAG_ACTIVO", prms);


        }

        #endregion

        #region Public Methods

        public override void Fill(DomainObject obj, IDataReader dr)
        {
            EENCUESTASATISFACCION objUNIDAD = obj as EENCUESTASATISFACCION;
    
            //Poner las rutinas del Tools que se necesiten
            
            objUNIDAD.CodEncuestaSatisfaccion = Utiles.ConvertToInt16(dr["COD_ENCUESTA_SATISFACCION"]);
            
            objUNIDAD.Nombre = Utiles.ConvertToString(dr["NOMBRE_ENCUESTA"]);
            
            objUNIDAD.Descripcion = Utiles.ConvertToString(dr["descripcion"]);

            objUNIDAD.Activo = Utiles.ConvertToBoolean(dr["flag_activo"]);

            objUNIDAD.CodEmpresa = Utiles.ConvertToInt32(dr["COD_EMPRESA"]);
        }

        #endregion

	}
}
