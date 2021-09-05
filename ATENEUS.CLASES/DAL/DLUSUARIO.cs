
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLUSUARIO.
	/// </summary>
	public class DLUSUARIO : DLBase
	{
		public DLUSUARIO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_USUARIO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_USUARIO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_USUARIO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_USUARIO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@rut_usuario";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EUSUARIO objUSUARIO = obj as EUSUARIO;

            prms[0] = db.GetParameter();
            prms[0].Value = objUSUARIO.RutUsuario;
            prms[0].ParameterName = "@rut_usuario";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(15);
            EUSUARIO objUSUARIO = obj as EUSUARIO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objUSUARIO.RutUsuario;
            prms[0].ParameterName = "@RUT_USUARIO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objUSUARIO.Nombres;
            prms[1].ParameterName = "@nombres";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objUSUARIO.Apellidos;
            prms[2].ParameterName = "@apellidos";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objUSUARIO.PasswdEnc;
            prms[3].ParameterName = "@passwd_enc";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objUSUARIO.Email;
            prms[4].ParameterName = "@email";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objUSUARIO.FechaCaducidad;
            prms[5].ParameterName = "@Fecha_caducidad";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objUSUARIO.FechaCreacion;
            prms[6].ParameterName = "@Fecha_Creacion";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objUSUARIO.Bloqueado;
            prms[7].ParameterName = "@Bloqueado";
            	
            prms[8] = db.GetParameter();
            prms[8].Value = objUSUARIO.ClaveSence;
            prms[8].ParameterName = "@clave_sence";
            	
            prms[9] = db.GetParameter();
            prms[9].Value = objUSUARIO.Profesion;
            prms[9].ParameterName = "@profesion";
            	
            prms[10] = db.GetParameter();
            prms[10].Value = objUSUARIO.Direccion;
            prms[10].ParameterName = "@direccion";
            	
            prms[11] = db.GetParameter();
            prms[11].Value = objUSUARIO.Comuna;
            prms[11].ParameterName = "@comuna";
			
			prms[12] = db.GetParameter();
            prms[12].Value = objUSUARIO.DNI;
            prms[12].ParameterName = "@dni";

            prms[13] = db.GetParameter();
            prms[13].Value = objUSUARIO.CodEmpresa;
            prms[13].ParameterName = "@cod_empresa";

            prms[14] = db.GetParameter();
            prms[14].Value = objUSUARIO.Fono;
            prms[14].ParameterName = "@fono";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(15);
            EUSUARIO objUSUARIO = obj as EUSUARIO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objUSUARIO.RutUsuario;
            prms[0].ParameterName = "@rut_usuario";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objUSUARIO.Nombres;
            prms[1].ParameterName = "@nombres";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objUSUARIO.Apellidos;
            prms[2].ParameterName = "@apellidos";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objUSUARIO.PasswdEnc;
            prms[3].ParameterName = "@passwd_enc";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objUSUARIO.Email;
            prms[4].ParameterName = "@email";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objUSUARIO.FechaCaducidad;
            prms[5].ParameterName = "@Fecha_caducidad";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objUSUARIO.FechaCreacion;
            prms[6].ParameterName = "@Fecha_Creacion";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objUSUARIO.Bloqueado;
            prms[7].ParameterName = "@Bloqueado";
            	
            prms[8] = db.GetParameter();
            prms[8].Value = objUSUARIO.ClaveSence;
            prms[8].ParameterName = "@clave_sence";
            	
            prms[9] = db.GetParameter();
            prms[9].Value = objUSUARIO.Profesion;
            prms[9].ParameterName = "@profesion";
            	
            prms[10] = db.GetParameter();
            prms[10].Value = objUSUARIO.Direccion;
            prms[10].ParameterName = "@direccion";
            	
            prms[11] = db.GetParameter();
            prms[11].Value = objUSUARIO.Comuna;
            prms[11].ParameterName = "@comuna";
			
			prms[12] = db.GetParameter();
            prms[12].Value = objUSUARIO.DNI;
            prms[12].ParameterName = "@dni";

            prms[13] = db.GetParameter();
            prms[13].Value = objUSUARIO.CodEmpresa;
            prms[13].ParameterName = "@cod_empresa";

            prms[14] = db.GetParameter();
            prms[14].Value = objUSUARIO.Fono;
            prms[14].ParameterName = "@fono";

            return prms;
        }


        public void SetCaracteristicasUsuario(long Rut, string Caracterisitca, string Atributo,Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(4);
			if(Caracterisitca == "" || Caracterisitca == null)
            {
                Caracterisitca = "Característica nueva";
            }

            if (Atributo == "" || Atributo == null)
            {
                Atributo = "-";
            }

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@RUT";

            prms[1] = db.GetParameter();
            prms[1].Value = Caracterisitca;
            prms[1].ParameterName = "@CARACTERISTICA";

            prms[2] = db.GetParameter();
            prms[2].Value = Atributo;
            prms[2].ParameterName = "@ATRIBUTO";

            prms[3] = db.GetParameter();
            prms[3].Value = CodEmpresa;
            prms[3].ParameterName = "@cod_empresa";

            db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_CREAR_CARACTERISTICAS_USUARIO", prms);

        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EUSUARIO objRoot = obj as EUSUARIO;

            objRoot.RutUsuario = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            try
            {
                EUSUARIO objUSUARIO = obj as EUSUARIO;

                //Poner las rutinas del Tools que se necesiten

                objUSUARIO.RutUsuario = Utiles.ConvertToInt64(dr["rut_usuario"]);

                objUSUARIO.Nombres = Utiles.ConvertToString(dr["nombres"]);

                objUSUARIO.Apellidos = Utiles.ConvertToString(dr["apellidos"]);

                objUSUARIO.PasswdEnc = Utiles.ConvertToString(dr["passwd_enc"]);

                objUSUARIO.Email = Utiles.ConvertToString(dr["email"]);

                objUSUARIO.FechaCaducidad = Utiles.ConvertToDateTime(dr["Fecha_caducidad"]);

                objUSUARIO.FechaCreacion = Utiles.ConvertToDateTime(dr["Fecha_Creacion"]);

                objUSUARIO.Bloqueado = Utiles.ConvertToBoolean(dr["Bloqueado"]);

                objUSUARIO.ClaveSence = Utiles.ConvertToString(dr["clave_sence"]);

                objUSUARIO.Profesion = Utiles.ConvertToString(dr["profesion"]);

                objUSUARIO.Direccion = Utiles.ConvertToString(dr["direccion"]);

                objUSUARIO.Comuna = Utiles.ConvertToString(dr["comuna"]);
				
				objUSUARIO.DNI = Utiles.ConvertToString(dr["dni"]);

                objUSUARIO.Fono = Utiles.ConvertToString(dr["fono"]);

                if (dr.FieldCount < 12)
                {
                      objUSUARIO.CodEmpresa = Utiles.ConvertToInt64(dr["COD_EMPRESA"]);
                }                

            }
            catch (Exception e)
            {

                throw;
            }
           
            
        }

         public Boolean ExisteUsuario(long RutUsuario,Int64 CodEmpresa)
         {
             DB db = DatabaseFactory.Instance.GetDatabase();
             IDbDataParameter[] prms;
             prms = db.GetArrayParameter(2);

             prms[0] = db.GetParameter();
             prms[0].Value = RutUsuario;
             prms[0].ParameterName = "@rut_usuario";

            prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa;
            prms[1].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_existe_usuario", prms);

             return Utiles.ConvertToBoolean(dt.Rows[0][0]);
         }

        public Boolean ExisteUsuarioEnOtraEmpresa(long RutUsuario)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = RutUsuario;
            prms[0].ParameterName = "@rut_usuario";
            
            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_existe_usuario_en_otra_empresa", prms);

            return Utiles.ConvertToBoolean(dt.Rows[0][0]);
        }

        public Boolean ExisteUsuarioDni(string dni)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = dni;
            prms[0].ParameterName = "@dni";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_existe_usuario_dni", prms);

            return Utiles.ConvertToBoolean(dt.Rows[0][0]);
        }

        public Boolean ExisteEmailUsuario(string Email, long RutUsuario)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = Email;
            prms[0].ParameterName = "@Email";

            prms[1] = db.GetParameter();
            prms[1].Value = RutUsuario;
            prms[1].ParameterName = "@RutUsuario";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_existe_email_usuario", prms);

            return Utiles.ConvertToBoolean(dt.Rows[0][0]);
        }
        public Int64 UltimoRutNegativo()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
           

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_ultimo_rut_negativo", null);

            return Utiles.ConvertToInt64(dt.Rows[0][0]);
        }
        #endregion

    }
}
