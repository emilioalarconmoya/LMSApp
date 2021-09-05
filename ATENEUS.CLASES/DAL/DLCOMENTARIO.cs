
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLCOMENTARIO.
	/// </summary>
	public class DLCOMENTARIO : DLBase
	{
		public DLCOMENTARIO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_COMENTARIO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_COMENTARIO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_COMENTARIO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_COMENTARIO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@IdMensaje";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ECOMENTARIO objCOMENTARIO = obj as ECOMENTARIO;

            prms[0] = db.GetParameter();
            prms[0].Value = objCOMENTARIO.IdMensaje;
            prms[0].ParameterName = "@IdMensaje";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(10);
            ECOMENTARIO objCOMENTARIO = obj as ECOMENTARIO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objCOMENTARIO.Quees;
            prms[0].ParameterName = "@quees";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCOMENTARIO.IdForo;
            prms[1].ParameterName = "@IdForo";

            if (objCOMENTARIO.IdHead == 0)
            {

                prms[2] = db.GetParameter();
                prms[2].Value = Serial();
                prms[2].ParameterName = "@IdHead";
            }
            else
            {

                prms[2] = db.GetParameter();
                prms[2].Value = objCOMENTARIO.IdHead;
                prms[2].ParameterName = "@IdHead";
            }
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objCOMENTARIO.Autor;
            prms[3].ParameterName = "@autor";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objCOMENTARIO.Email;
            prms[4].ParameterName = "@email";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objCOMENTARIO.Fechahora;
            prms[5].ParameterName = "@fechahora";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objCOMENTARIO.Tema;
            prms[6].ParameterName = "@tema";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objCOMENTARIO.Cuerpo;
            prms[7].ParameterName = "@cuerpo";
            	
            prms[8] = db.GetParameter();
            prms[8].Value = objCOMENTARIO.Ultimo;
            prms[8].ParameterName = "@ultimo";
            	
            prms[9] = db.GetParameter();
            prms[9].Value = objCOMENTARIO.Respuestas;
            prms[9].ParameterName = "@respuestas";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(11);
            ECOMENTARIO objCOMENTARIO = obj as ECOMENTARIO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCOMENTARIO.IdMensaje;
            prms[0].ParameterName = "@IdMensaje";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCOMENTARIO.IdForo;
            prms[1].ParameterName = "@IdForo";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objCOMENTARIO.IdHead;
            prms[2].ParameterName = "@IdHead";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objCOMENTARIO.Autor;
            prms[3].ParameterName = "@autor";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objCOMENTARIO.Email;
            prms[4].ParameterName = "@email";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objCOMENTARIO.Fechahora;
            prms[5].ParameterName = "@fechahora";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objCOMENTARIO.Tema;
            prms[6].ParameterName = "@tema";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objCOMENTARIO.Cuerpo;
            prms[7].ParameterName = "@cuerpo";
            	
            prms[8] = db.GetParameter();
            prms[8].Value = objCOMENTARIO.Ultimo;
            prms[8].ParameterName = "@ultimo";
            	
            prms[9] = db.GetParameter();
            prms[9].Value = objCOMENTARIO.Respuestas;
            prms[9].ParameterName = "@respuestas";
            	
            prms[10] = db.GetParameter();
            prms[10].Value = objCOMENTARIO.Quees;
            prms[10].ParameterName = "@quees";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ECOMENTARIO objRoot = obj as ECOMENTARIO;

            objRoot.IdMensaje = id;
        }


        public long Serial()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_serial_comentario");
            return Utiles.ConvertToInt64(dt.Rows[0][0]);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ECOMENTARIO objCOMENTARIO = obj as ECOMENTARIO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objCOMENTARIO.IdMensaje = Utiles.ConvertToDecimal(dr["IdMensaje"]);
            
            objCOMENTARIO.IdForo = Utiles.ConvertToInt16(dr["IdForo"]);
            
            objCOMENTARIO.IdHead = Utiles.ConvertToInt16(dr["IdHead"]);
            
            objCOMENTARIO.Autor = Utiles.ConvertToString(dr["autor"]);
            
            objCOMENTARIO.Email = Utiles.ConvertToString(dr["email"]);
            
            objCOMENTARIO.Fechahora = Utiles.ConvertToDateTime(dr["fechahora"]);
            
            objCOMENTARIO.Tema = Utiles.ConvertToString(dr["tema"]);
            
            objCOMENTARIO.Cuerpo = Utiles.ConvertToString(dr["cuerpo"]);
            
            objCOMENTARIO.Ultimo = Utiles.ConvertToDateTime(dr["ultimo"]);
            
            objCOMENTARIO.Respuestas = Utiles.ConvertToInt16(dr["respuestas"]);

            objCOMENTARIO.Quees = Utiles.ConvertToString(dr["quees"]);
            
        }

        #endregion

	}
}
