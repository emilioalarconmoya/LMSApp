using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;
using System.Data;

namespace ATENEUS.CLASES.DAL
{
    public class DLEMPRESALIST : DLGenericBaseList<EEMPRESA>
    {
        public DLEMPRESALIST()
        {
            this._proc_select_all = "proc_select_EMPRESA_all";
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EEMPRESA> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public DataTable SelectEmpresaParametros(Int64  Rut, string Nombres)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@RutEmpresa";

            prms[1] = db.GetParameter();
            prms[1].Value = Utiles.SubStringSQL(Nombres);
            prms[1].ParameterName = "@Nombre";
            
            //IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_empresa_all_parametros", prms);
            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_empresa_all_parametros", prms);

            //List<EEMPRESA> lst = new List<EEMPRESA>();
            
            //while (dr.Read())
            //{
            //    EEMPRESA objEMPRESA = new EEMPRESA();

            //    //Poner las rutinas del Tools que se necesiten

            //    objEMPRESA.CodEmpresa = Utiles.ConvertToInt64(dr["COD_EMPRESA"]);

            //    objEMPRESA.RutEmpresa = Utiles.ConvertToInt64(dr["RUT_EMPRESA"]);

            //    objEMPRESA.NombreFantasia = Utiles.ConvertToString(dr["NOMBRE_FANTASIA"]);

            //    objEMPRESA.RazonSocial = Utiles.ConvertToString(dr["RAZON_SOCIAL"]);

            //    objEMPRESA.NombreContacto = Utiles.ConvertToString(dr["NOMBRE_CONTACTO"]);

            //    objEMPRESA.EmpresaEmail = Utiles.ConvertToString(dr["EMPRESA_EMAIL"]);

            //    objEMPRESA.EmailContacto = Utiles.ConvertToString(dr["EMAIL_CONTACTO"]);

            //    objEMPRESA.Vigente = Utiles.ConvertToBoolean(dr["VIGENTE"]);

            //    objEMPRESA.EspacioDisco = Utiles.ConvertToInt64(dr["ESPACIO_DISCO_MB"]);

            //    objEMPRESA.Host = Utiles.ConvertToString(dr["EMPRESA_HOST"]);

            //    objEMPRESA.Port = Utiles.ConvertToInt64(dr["EMPRESA_PORT"]);

            //    objEMPRESA.User = Utiles.ConvertToString(dr["EMPRESA_USUARIO"]);

            //    objEMPRESA.Pass = Utiles.ConvertToString(dr["EMPRESA_PASS"]);

            //    lst.Add(objEMPRESA);
               
            //}
            return dt;
        }
        
              public Boolean UpdateEspacioDiscoDAL(Int64 CodEmpresa,long EspacioUtilizado)
        {
            try
            {
                DB db = DatabaseFactory.Instance.GetDatabase();
                IDbDataParameter[] prms;
                prms = db.GetArrayParameter(2);

                prms[0] = db.GetParameter();
                prms[0].Value = CodEmpresa;
                prms[0].ParameterName = "@cod_empresa";

                prms[1] = db.GetParameter();
                prms[1].Value = EspacioUtilizado;
                prms[1].ParameterName = "@espacio_utilizado";

                db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_update_empresa_espacio_utilizado", prms);

                return true;
            }
            catch 
            {
                return false;
                
            }
           
        }
        public EEMPRESA SelectEmpresaParametros(Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodEmpresa;
            prms[0].ParameterName = "@cod_empresa";           

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_empresa_by_codigo", prms);
            EEMPRESA objEMPRESA = new EEMPRESA();
            while (dr.Read())
            {
                objEMPRESA.CodEmpresa = Utiles.ConvertToInt64(dr["COD_EMPRESA"]);

                objEMPRESA.RutEmpresa = Utiles.ConvertToInt64(dr["RUT_EMPRESA"]);

                objEMPRESA.NombreFantasia = Utiles.ConvertToString(dr["NOMBRE_FANTASIA"]);

                objEMPRESA.RazonSocial = Utiles.ConvertToString(dr["RAZON_SOCIAL"]);

                objEMPRESA.NombreContacto = Utiles.ConvertToString(dr["NOMBRE_CONTACTO"]);

                objEMPRESA.EmpresaEmail = Utiles.ConvertToString(dr["EMPRESA_EMAIL"]);

                objEMPRESA.EmailContacto = Utiles.ConvertToString(dr["EMAIL_CONTACTO"]);

                objEMPRESA.Vigente = Utiles.ConvertToBoolean(dr["VIGENTE"]);

                objEMPRESA.EspacioDisco = Utiles.ConvertToInt64(dr["ESPACIO_DISCO_MB"]);

                objEMPRESA.Host = Utiles.ConvertToString(dr["EMPRESA_HOST"]);

                objEMPRESA.Port = Utiles.ConvertToInt64(dr["EMPRESA_PORT"]);

                objEMPRESA.User = Utiles.ConvertToString(dr["EMPRESA_USUARIO"]);

                objEMPRESA.Pass = Utiles.ConvertToString(dr["EMPRESA_PASS"]);
            }
            return objEMPRESA;
        }

        public Boolean ExisteEmpresaDAL(Int64 Rut)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@rut_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_existe_empresa", prms);

            return Utiles.ConvertToBoolean(dt.Rows[0][0]);
        }
        public Int64 InsertEmpresaDAL(EEMPRESA Empresa)
        {
            try
            {

                DB db = DatabaseFactory.Instance.GetDatabase();
                IDbDataParameter[] prms;
                prms = db.GetArrayParameter(12);

                prms[0] = db.GetParameter();
                prms[0].Value = Empresa.RutEmpresa;
                prms[0].ParameterName = "@rut_empresa";

                prms[1] = db.GetParameter();
                prms[1].Value = Empresa.NombreFantasia;
                prms[1].ParameterName = "@nombre_fantasia";

                prms[2] = db.GetParameter();
                prms[2].Value = Empresa.RazonSocial;
                prms[2].ParameterName = "@razon_social";

                prms[3] = db.GetParameter();
                prms[3].Value = Empresa.NombreContacto;
                prms[3].ParameterName = "@nombre_contacto";

                prms[4] = db.GetParameter();
                prms[4].Value = Empresa.EmpresaEmail;
                prms[4].ParameterName = "@empresa_email";

                prms[5] = db.GetParameter();
                prms[5].Value = Empresa.EmailContacto;
                prms[5].ParameterName = "@email_contacto";

                prms[6] = db.GetParameter();
                prms[6].Value = Empresa.Vigente;
                prms[6].ParameterName = "@vigente";

                prms[7] = db.GetParameter();
                prms[7].Value = Empresa.EspacioDisco;
                prms[7].ParameterName = "@espacio_disco_mb";

                prms[8] = db.GetParameter();
                prms[8].Value = Empresa.Host;
                prms[8].ParameterName = "@host";

                prms[9] = db.GetParameter();
                prms[9].Value = Empresa.Port;
                prms[9].ParameterName = "@port";

                prms[10] = db.GetParameter();
                prms[10].Value = Empresa.User;
                prms[10].ParameterName = "@usuario";

                prms[11] = db.GetParameter();
                prms[11].Value = Empresa.Pass;
                prms[11].ParameterName = "@pass";

                

            return Utiles.ConvertToInt64(db.ExecuteScalar(CommandType.StoredProcedure, "proc_insert_empresa", prms));
            }
            catch 
            {
                throw;
               
            }

        }

        public bool UpdateEmpresaDAL(EEMPRESA Empresa)
        {
            try
            {

                DB db = DatabaseFactory.Instance.GetDatabase();
                IDbDataParameter[] prms;
                prms = db.GetArrayParameter(13);

                prms[0] = db.GetParameter();
                prms[0].Value = Empresa.RutEmpresa;
                prms[0].ParameterName = "@rut_empresa";

                prms[1] = db.GetParameter();
                prms[1].Value = Empresa.NombreFantasia;
                prms[1].ParameterName = "@nombre_fantasia";

                prms[2] = db.GetParameter();
                prms[2].Value = Empresa.RazonSocial;
                prms[2].ParameterName = "@razon_social";

                prms[3] = db.GetParameter();
                prms[3].Value = Empresa.NombreContacto;
                prms[3].ParameterName = "@nombre_contacto";

                prms[4] = db.GetParameter();
                prms[4].Value = Empresa.EmpresaEmail;
                prms[4].ParameterName = "@empresa_email";

                prms[5] = db.GetParameter();
                prms[5].Value = Empresa.EmailContacto;
                prms[5].ParameterName = "@email_contacto";

                prms[6] = db.GetParameter();
                prms[6].Value = Empresa.Vigente;
                prms[6].ParameterName = "@vigente";

                prms[7] = db.GetParameter();
                prms[7].Value = Empresa.EspacioDisco;
                prms[7].ParameterName = "@espacio_disco_mb";

                prms[8] = db.GetParameter();
                prms[8].Value = Empresa.Host;
                prms[8].ParameterName = "@host";

                prms[9] = db.GetParameter();
                prms[9].Value = Empresa.Port;
                prms[9].ParameterName = "@port";

                prms[10] = db.GetParameter();
                prms[10].Value = Empresa.User;
                prms[10].ParameterName = "@usuario";

                prms[11] = db.GetParameter();
                prms[11].Value = Empresa.Pass;
                prms[11].ParameterName = "@pass";

                prms[12] = db.GetParameter();
                prms[12].Value = Empresa.CodEmpresa;
                prms[12].ParameterName = "@cod_empresa";

                db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_update_empresa", prms);

                return true;
            }
            catch
            {
                throw;

            }

        }

    }
}
