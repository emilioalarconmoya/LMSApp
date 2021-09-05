using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
    public class DLSESSIONUSUARIO : DLBase
    {

        public DLSESSIONUSUARIO()
		{
		}

        #region Protected Methods
        
        protected override string GetSelectProcedure()
        {
            return "proc_select_session_usuario";
        }
        
        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@rut_usuario";

            prms[1] = db.GetParameter();
            prms[1].Value = id;
            prms[1].ParameterName = "@passwd_enc";

            return prms;
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
            ESESSIONUSUARIO objUSUARIO = obj as ESESSIONUSUARIO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objUSUARIO.RutUsuario = Utiles.ConvertToInt64(dr["rut_usuario"]);
            
            objUSUARIO.Nombres = Utiles.ConvertToString(dr["nombres"]);
            
            objUSUARIO.Apellidos = Utiles.ConvertToString(dr["apellidos"]);
            
            objUSUARIO.Email = Utiles.ConvertToString(dr["email"]);
            
            objUSUARIO.ClaveSence = Utiles.ConvertToString(dr["clave_sence"]);
            
            objUSUARIO.Profesion = Utiles.ConvertToString(dr["profesion"]);
            
            objUSUARIO.Direccion = Utiles.ConvertToString(dr["direccion"]);
            
            objUSUARIO.Comuna = Utiles.ConvertToString(dr["comuna"]);

            objUSUARIO.EsAdministrador = Utiles.ConvertToBoolean(dr["es_administrador"]);

            objUSUARIO.EsGestion = Utiles.ConvertToBoolean(dr["es_gestion"]);

            objUSUARIO.EsTutor = Utiles.ConvertToBoolean(dr["es_tutor"]);

            objUSUARIO.EsSuperusuario = Utiles.ConvertToBoolean(dr["es_superusuario"]);

            objUSUARIO.ChatHabilitad = Utiles.ConvertToBoolean(dr["flag_chat"]);

            objUSUARIO.ForoHabilitad = Utiles.ConvertToBoolean(dr["flag_foro"]);

            objUSUARIO.Pass = Utiles.ConvertToString(dr["PASSWD_ENC"]);

            objUSUARIO.CodEmpresa = Utiles.ConvertToInt64(dr["COD_EMPRESA"]);

            if (Utiles.ConvertToInt16(dr["es_alumno"]) > 0)
            {
                objUSUARIO.EsAlumno = true;
            }
            else
            {
                objUSUARIO.EsAlumno = false;
            }
            
        }


         public ESESSIONUSUARIO SelectSessionUsuario(long Rut, string Passwd, string Email)
         {
             
             DB db = DatabaseFactory.Instance.GetDatabase();
             IDbDataParameter[] prms = db.GetArrayParameter(3);

             prms[0] = db.GetParameter();
             prms[0].Value = Rut;
             prms[0].ParameterName = "@rut_usuario";

             prms[1] = db.GetParameter();
             prms[1].Value = CCryptografia.Encriptar(Passwd);
             prms[1].ParameterName = "@passwd_enc";

             prms[2] = db.GetParameter();
             prms[2].Value = Email;
             prms[2].ParameterName = "@email";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_session_usuario", prms);

             ESESSIONUSUARIO objSessionUsuario = new ESESSIONUSUARIO();
             if ((dr != null) && dr.Read())
             {
                 this.Fill(objSessionUsuario, dr);
                 objSessionUsuario.IsPersisted = true;
             }
             dr.Close();

             return objSessionUsuario;
        }


        public ESESSIONUSUARIO SelectSessionUsuarioNonSecure(long Rut)
        {

            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@rut_usuario";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_session_usuario_non_secure", prms);

            ESESSIONUSUARIO objSessionUsuario = new ESESSIONUSUARIO();
            if ((dr != null) && dr.Read())
            {
                this.Fill(objSessionUsuario, dr);
                objSessionUsuario.IsPersisted = true;
            }
            dr.Close();
            
            return objSessionUsuario;
        }

        public ESESSIONUSUARIO SelectSessionUsuarioNonSecure(String Email)
        {

            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = Email;
            prms[0].ParameterName = "@email";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_session_usuario_non_secure_email", prms);

            ESESSIONUSUARIO objSessionUsuario = new ESESSIONUSUARIO();
            if ((dr != null) && dr.Read())
            {
                this.Fill(objSessionUsuario, dr);
                objSessionUsuario.IsPersisted = true;
            }
            dr.Close();



            return objSessionUsuario;
        }

        public ESESSIONUSUARIO SelectSessionUsuarioNonEmpSecure(String NombreEmpresa)
        {

            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = NombreEmpresa;
            prms[0].ParameterName = "@nombre";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_session_usuario_non_secure_nombre_empresa", prms);

            ESESSIONUSUARIO objSessionUsuario = new ESESSIONUSUARIO();
            if ((dr != null) && dr.Read())
            {
                this.Fill(objSessionUsuario, dr);
                objSessionUsuario.IsPersisted = true;
            }
            dr.Close();



            return objSessionUsuario;
        }

        
		public DataTable SelectUsuariosPorDNI(String dni)
        {

            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = dni;
            prms[0].ParameterName = "@dni";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_usuarios_por_dni", prms);

            return dt;
        }
        public DataTable SelectSessionNonEmpSecure(String NombreEmpresa)
        {

            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = NombreEmpresa;
            prms[0].ParameterName = "@nombre";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_session_nombre_empresa", prms);

            return dt;
            
            
        }

        public Boolean SelectTieneCatalogo(long rut)
        {

            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = rut;
            prms[0].ParameterName = "@rut";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_tiene_catalogo", prms);

            if(dt.Rows.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }

           


        }
        #endregion
    }
}
