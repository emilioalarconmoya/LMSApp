
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPREGUNTA.
	/// </summary>
	public class DLPREGUNTA : DLBase
	{
		public DLPREGUNTA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_PREGUNTA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_PREGUNTA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_PREGUNTA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_PREGUNTA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_pregunta";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EPREGUNTA objPREGUNTA = obj as EPREGUNTA;

            prms[0] = db.GetParameter();
            prms[0].Value = objPREGUNTA.CodPregunta;
            prms[0].ParameterName = "@cod_pregunta";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(4);
            EPREGUNTA objPREGUNTA = obj as EPREGUNTA;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objPREGUNTA.CodPregunta;
            prms[0].ParameterName = "@cod_pregunta";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPREGUNTA.CodTipoPreg;
            prms[1].ParameterName = "@cod_tipo_preg";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objPREGUNTA.Texto;
            prms[2].ParameterName = "@texto";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objPREGUNTA.CodCliente;
            prms[3].ParameterName = "@cod_cliente";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(4);
            EPREGUNTA objPREGUNTA = obj as EPREGUNTA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPREGUNTA.CodPregunta;
            prms[0].ParameterName = "@cod_pregunta";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPREGUNTA.CodTipoPreg;
            prms[1].ParameterName = "@cod_tipo_preg";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objPREGUNTA.Texto;
            prms[2].ParameterName = "@texto";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objPREGUNTA.CodCliente;
            prms[3].ParameterName = "@cod_cliente";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EPREGUNTA objRoot = obj as EPREGUNTA;

            objRoot.CodPregunta = Utiles.ConvertToInt16(id);
        }

        public long Serial()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_serial_pregunta");
            return Utiles.ConvertToInt64(dt.Rows[0][0]);
        }

        #endregion

        #region Public Methods

        public EPREGUNTA PreguntaUnidad(Int16 CodPregunta)
        {
            //DB db = DatabaseFactory.Instance.GetDatabase();
            
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodPregunta;
            prms[0].ParameterName = "@CodPregunta";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_pregunta_unidad", prms);

            EPREGUNTA objPregunta = new EPREGUNTA();

            while (dr.Read())
            {

                objPregunta.CodPregunta = Utiles.ConvertToInt16(dr["cod_pregunta"]);

                objPregunta.CodTipoPreg = Utiles.ConvertToInt16(dr["cod_tipo_preg"]);

                objPregunta.Texto = Utiles.ConvertToString(dr["texto"]);

                objPregunta.CodCliente = Utiles.ConvertToString(dr["cod_cliente"]);

                objPregunta.CodCorrecta = Utiles.ConvertToInt16(dr["cod_correcta"]);

                DLALTERNATIVAList objAltList = new DLALTERNATIVAList();

                objPregunta.Alternativas = objAltList.AlternativasPregunta(Utiles.ConvertToInt16(dr["cod_pregunta"]));
            }

            dr.Close();

            return objPregunta;
        }


        public EPREGUNTA PreguntaEncuestaSatisfaccion(Int16 CodPregunta)
        {
            //DB db = DatabaseFactory.Instance.GetDatabase();

            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodPregunta;
            prms[0].ParameterName = "@CodPregunta";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_pregunta_unidad", prms);

            EPREGUNTA objPregunta = new EPREGUNTA();

            while (dr.Read())
            {

                objPregunta.CodPregunta = Utiles.ConvertToInt16(dr["cod_pregunta"]);

                objPregunta.CodTipoPreg = Utiles.ConvertToInt16(dr["cod_tipo_preg"]);

                objPregunta.Texto = Utiles.ConvertToString(dr["texto"]);

                objPregunta.CodCliente = Utiles.ConvertToString(dr["cod_cliente"]);

                objPregunta.CodCorrecta = Utiles.ConvertToInt16(dr["cod_correcta"]);

                DLALTERNATIVAList objAltList = new DLALTERNATIVAList();

                objPregunta.Alternativas = objAltList.AlternativasPreguntaEncuesta(Utiles.ConvertToInt16(dr["cod_pregunta"]));
            }

            dr.Close();

            return objPregunta;
        }
        public override void Fill(DomainObject obj, IDataReader dr)
        {
            EPREGUNTA objPREGUNTA = obj as EPREGUNTA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objPREGUNTA.CodPregunta = Utiles.ConvertToInt16(dr["cod_pregunta"]);
            
            objPREGUNTA.CodTipoPreg = Utiles.ConvertToInt16(dr["cod_tipo_preg"]);
            
            objPREGUNTA.Texto = Utiles.ConvertToString(dr["texto"]);
            
            objPREGUNTA.CodCliente = Utiles.ConvertToString(dr["cod_cliente"]);

            DLALTERNATIVAList objAltList = new DLALTERNATIVAList();

            objPREGUNTA.Alternativas = objAltList.AlternativasPregunta(Utiles.ConvertToInt16(dr["cod_pregunta"]));
            
        }

        #endregion

	}
}
