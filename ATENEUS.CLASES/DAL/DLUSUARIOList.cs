
using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;
//using Moebius.ErrorManagement;
//using ATENEUS.BUSINESS.Collections;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLUSUARIOList.
	/// </summary>
    public class DLUSUARIOList : DLGenericBaseList<EUSUARIO>
	{
		public DLUSUARIOList()
		{
            this._proc_select_all = "proc_select_USUARIO_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EUSUARIO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public DataTable selectTutor(long CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodEmpresa;
            prms[0].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_tutor_all", prms);

            return dt;
        }

        public List<EUSUARIO> SelectUsuarioParametros(long Rut, string Nombres, string Apellidos, string Email,Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(5);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@Rut";

            prms[1] = db.GetParameter();
            prms[1].Value = Utiles.SubStringSQL(Nombres);
            prms[1].ParameterName = "@Nombres";

            prms[2] = db.GetParameter();
            prms[2].Value = Utiles.SubStringSQL(Apellidos);
            prms[2].ParameterName = "@Apellidos";

            prms[3] = db.GetParameter();
            prms[3].Value = Utiles.SubStringSQL(Email);
            prms[3].ParameterName = "@Email";

            prms[4] = db.GetParameter();
            prms[4].Value = CodEmpresa;
            prms[4].ParameterName = "@cod_empresa";


            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_buscador_usuario", prms);

            return GetCollection(dr);

        }

        public List<EUSUARIO> SelectUsuarioParametrosAtributo(long Rut, string Nombres, string Apellidos, string Email, long rutTutor, Int32 CodCaracteristica, Int32 CodAtributo, Int64 codEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;

            IDataReader dr;
            prms = db.GetArrayParameter(7);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@Rut";

            prms[1] = db.GetParameter();
            prms[1].Value = Utiles.SubStringSQL(Nombres);
            prms[1].ParameterName = "@Nombres";

            prms[2] = db.GetParameter();
            prms[2].Value = Utiles.SubStringSQL(Apellidos);
            prms[2].ParameterName = "@Apellidos";

            prms[3] = db.GetParameter();
            prms[3].Value = Utiles.SubStringSQL(Email);
            prms[3].ParameterName = "@Email";

            prms[4] = db.GetParameter();
            prms[4].Value = CodCaracteristica;
            prms[4].ParameterName = "@codcaracteristica";

            if (CodAtributo == 0)
            {
                CodAtributo = -1;
            }

            prms[5] = db.GetParameter();
            prms[5].Value = CodAtributo;
            prms[5].ParameterName = "@codatributo";

            prms[6] = db.GetParameter();
            prms[6].Value = codEmpresa;
            prms[6].ParameterName = "@cod_empresa";

            dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_buscador_usuario_atributo", prms);


            return GetCollection(dr);

        }

        public List<EUSUARIO> GetUsuariosParametros(long Rut, string Nombres, Int16 CodCaract, Int16 CodAtrib,Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(5);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@Rut";

            prms[1] = db.GetParameter();
            prms[1].Value = Utiles.SubStringSQL(Nombres);
            prms[1].ParameterName = "@Nombres";

            prms[2] = db.GetParameter();
            prms[2].Value = CodCaract;
            prms[2].ParameterName = "@CodCaract";

            prms[3] = db.GetParameter();
            prms[3].Value = CodAtrib;
            prms[3].ParameterName = "@CodAtrib";

            prms[4] = db.GetParameter();
            prms[4].Value = CodEmpresa;
            prms[4].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_buscador_usuarios", prms);

            return GetCollection(dr);

        }

        public DataTable GetUsuariosApp(string rut)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = Utiles.RutUsrALng(rut);
            prms[0].ParameterName = "@rut";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_USUARIO_all_app", prms);

            return dt;

        }

        public DataTable GetUsuariosCargados(long Rut, string Nombres, string Apellidos, Int16 CodCaract, Int16 CodAtrib, Int64 CodEmpresa, int codEstado)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(7);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@Rut";

            prms[1] = db.GetParameter();
            prms[1].Value = Nombres;
            prms[1].ParameterName = "@Nombres";

            prms[2] = db.GetParameter();
            prms[2].Value = Apellidos;
            prms[2].ParameterName = "@Apellidos";

            prms[3] = db.GetParameter();
            prms[3].Value = CodCaract;
            prms[3].ParameterName = "@codcaracteristica";

            if (CodAtrib == 0)
            {
                CodAtrib = -1;
            }

            prms[4] = db.GetParameter();
            prms[4].Value = CodAtrib;
            prms[4].ParameterName = "@codatributo";

            prms[5] = db.GetParameter();
            prms[5].Value = CodEmpresa;
            prms[5].ParameterName = "@codempresa";

            prms[6] = db.GetParameter();
            prms[6].Value = codEstado;
            prms[6].ParameterName = "@cod_estado";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_USUARIO_CARGADOS", prms);

            return dt;

        }


        public List<EUSUARIO> SelectUsuarioParametros(long Rut, string Nombres)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@Rut";

            prms[1] = db.GetParameter();
            prms[1].Value = Utiles.SubStringSQL(Nombres);
            prms[1].ParameterName = "@Nombres";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_usuario_paramentros", prms);

            return GetCollection(dr);

        }


        public DataTable GetUsuarioSaldo(long Rut, string Nombres, Int16 CodCaract, Int16 CodAtrib)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@Rut";

            prms[1] = db.GetParameter();
            prms[1].Value = Utiles.SubStringSQL(Nombres);
            prms[1].ParameterName = "@Nombres";

            prms[2] = db.GetParameter();
            prms[2].Value = CodCaract;
            prms[2].ParameterName = "@CodCaract";

            prms[3] = db.GetParameter();
            prms[3].Value = CodAtrib;
            prms[3].ParameterName = "@CodAtrib";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_USUARIO_SALDO", prms);

            return dt;

        }

        public string GetNombreUsuario(long Rut)
        {
            string strNombre = "";
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@RUTUSUARIO";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_NOMBRE_USUARIO", prms);
            while (dr.Read())
            {
                strNombre = Utiles.ConvertToString(dr["NOMBRE"]);
            }
            dr.Close();
            return strNombre;

        }

        #endregion
    }
}
