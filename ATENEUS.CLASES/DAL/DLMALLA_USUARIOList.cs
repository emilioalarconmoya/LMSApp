
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
    public class DLMALLAUSUARIOList : DLGenericBaseList<EMALLAUSUARIO>
    {
        public DLMALLAUSUARIOList()
        {
            this._proc_select_all = "proc_select_MALLA_ACT_USUARIO_all";
        }

        #region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EMALLAUSUARIO> SelectAll(Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);
            prms[0] = db.GetParameter();
            prms[0].Value = CodEmpresa;
            prms[0].ParameterName = "@cod_empresa";


            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, prms);

            return GetCollection(dr);
        }

        public List<EMALLAUSUARIO> GetMallasAsignadas(string listaRuts, string listaActividades, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = listaRuts;
            prms[0].ParameterName = "@LISTRUTUSUARIOS";

            prms[1] = db.GetParameter();
            prms[1].Value = listaActividades;
            prms[1].ParameterName = "@LISTMALLAS";
			
			prms[2] = db.GetParameter();
            prms[2].Value = CodEmpresa; 
            prms[2].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_MALLAS_ASIGNADAS", prms);

            return GetCollection(dr);
        }

        public List<EMALLAUSUARIO> SelectUsuariosMalla(Int32 codMalla, Int64 rut, string nombre, string apellidos, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(5);

            prms[0] = db.GetParameter();
            prms[0].Value = codMalla;
            prms[0].ParameterName = "@CODMALLA";

            prms[1] = db.GetParameter();
            prms[1].Value = rut;
            prms[1].ParameterName = "@Rut";

            prms[2] = db.GetParameter();
            prms[2].Value = Utiles.SubStringSQL(nombre);
            prms[2].ParameterName = "@Nombres";

            prms[3] = db.GetParameter();
            prms[3].Value = Utiles.SubStringSQL(apellidos);
            prms[3].ParameterName = "@Apellidos";
			
			prms[4] = db.GetParameter();
            prms[4].Value = CodEmpresa; 
            prms[4].ParameterName = "@codempresa";


            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_usuarios_por_malla", prms);


            List<EMALLAUSUARIO> lst = new List<EMALLAUSUARIO>();

            while (dr.Read())
            {
                EMALLAUSUARIO objMALLA = new EMALLAUSUARIO();

                objMALLA.CodMalla = Utiles.ConvertToInt32(dr["cod_malla"]);

                objMALLA.NombreMalla = Utiles.ConvertToString(dr["nombre_malla"]);

                objMALLA.NombreUsuario = Utiles.ConvertToString(dr["NOMBRE_USUARIO"]);

                objMALLA.RutUsuario = Utiles.ConvertToInt32(dr["RUT_USUARIO"]);

                objMALLA.Vigente = Utiles.ConvertToBoolean(dr["flag_vigente"]);
				
				objMALLA.CodEmpresa = Utiles.ConvertToInt32(dr["cod_empresa"]);
				
                lst.Add(objMALLA);
            }
            dr.Close();
            return lst;
        }

        public DataTable SelectUsuariosMallaDescarga(Int32 codMalla, Int64 rut, string nombre, string apellidos, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(5);

            prms[0] = db.GetParameter();
            prms[0].Value = codMalla;
            prms[0].ParameterName = "@CODMALLA";

            prms[1] = db.GetParameter();
            prms[1].Value = rut;
            prms[1].ParameterName = "@Rut";

            prms[2] = db.GetParameter();
            prms[2].Value = Utiles.SubStringSQL(nombre);
            prms[2].ParameterName = "@Nombres";

            prms[3] = db.GetParameter();
            prms[3].Value = Utiles.SubStringSQL(apellidos);
            prms[3].ParameterName = "@Apellidos";
			
			prms[4] = db.GetParameter();
            prms[4].Value = CodEmpresa; 
            prms[4].ParameterName = "@cod_empresa";


            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_usuarios_por_malla_DESCARGA", prms);

            return dt;


           
        }

        #endregion
    }
}
