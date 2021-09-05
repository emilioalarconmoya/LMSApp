
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
    public class DLSALAVIRTUAL : DLBase
    {
        public DLSALAVIRTUAL()
        {
        }

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_sala_virtual";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_sala_virtual";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_sala_virtual";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_sala_virtual";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@rut_usuario";

            //prms[1] = db.GetParameter();
            //prms[1].Value = id;
            //prms[1].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ESALAVIRTUAL objSala = obj as ESALAVIRTUAL;

            prms[0] = db.GetParameter();
            prms[0].Value = objSala.RutUsuario;
            prms[0].ParameterName = "@rut_usuario";

            prms[1] = db.GetParameter();
            prms[1].Value = objSala.CodTipoSalaVirtual;
            prms[1].ParameterName = "@cod_tipo_sala_virtual";

            //prms[2] = db.GetParameter();
            //prms[2].Value = objSala.CodEmpresa;
            //prms[2].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(7);


            //Poner las rutinas del Tools que se necesiten  

            ESALAVIRTUAL objSala = obj as ESALAVIRTUAL;

            prms[0] = db.GetParameter();
            prms[0].Value = objSala.RutUsuario;
            prms[0].ParameterName = "@rut_usuario";

            prms[1] = db.GetParameter();
            prms[1].Value = objSala.CodTipoSalaVirtual;
            prms[1].ParameterName = "@cod_tipo_sala_virtual";

            prms[2] = db.GetParameter();
            prms[2].Value = objSala.NombreUsuario;
            prms[2].ParameterName = "@nombre_usuario";

            prms[3] = db.GetParameter();
            prms[3].Value = objSala.Contrasena;
            prms[3].ParameterName = "@contrasena";

            prms[4] = db.GetParameter();
            prms[4].Value = objSala.URL;
            prms[4].ParameterName = "@url";

            prms[5] = db.GetParameter();
            prms[5].Value = objSala.Activo;
            prms[5].ParameterName = "@flag_activo";

            prms[6] = db.GetParameter();
            prms[6].Value = objSala.CodEmpresa;
            prms[6].ParameterName = "@cod_empresa";




            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(7);
            ESALAVIRTUAL objSala = obj as ESALAVIRTUAL;

            prms[0] = db.GetParameter();
            prms[0].Value = objSala.RutUsuario;
            prms[0].ParameterName = "@rut_usuario";

            prms[1] = db.GetParameter();
            prms[1].Value = objSala.CodTipoSalaVirtual;
            prms[1].ParameterName = "@cod_tipo_sala_virtual";

            prms[2] = db.GetParameter();
            prms[2].Value = objSala.NombreUsuario;
            prms[2].ParameterName = "@nombre_usuario";

            prms[3] = db.GetParameter();
            prms[3].Value = objSala.Contrasena;
            prms[3].ParameterName = "@contrasena";

            prms[4] = db.GetParameter();
            prms[4].Value = objSala.URL;
            prms[4].ParameterName = "@url";

            prms[5] = db.GetParameter();
            prms[5].Value = objSala.Activo;
            prms[5].ParameterName = "@flag_activo";

            prms[6] = db.GetParameter();
            prms[6].Value = objSala.CodEmpresa;
            prms[6].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ESALAVIRTUAL objRoot = obj as ESALAVIRTUAL;

            objRoot.RutUsuario = Utiles.ConvertToInt16(id);
        }


        //public Boolean Existe(long Cod)
        //{
        //    DB db = DatabaseFactory.Instance.GetDatabase();
        //    IDbDataParameter[] prms;
        //    prms = db.GetArrayParameter(1);

        //    prms[0] = db.GetParameter();
        //    prms[0].Value = Cod;
        //    prms[0].ParameterName = "@codigo";

        //    DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_existe_unidad", prms);

        //    return Utiles.ConvertToBoolean(dt.Rows[0][0]);
        //}

        //public Int16 Serial()
        //{
        //    DB db = DatabaseFactory.Instance.GetDatabase();
        //    DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_serial_unidad");
        //    return Utiles.ConvertToInt16(dt.Rows[0][0]);
        //}

        #endregion

        #region Public Methods

        public override void Fill(DomainObject obj, IDataReader dr)
        {
            ESALAVIRTUAL objSALA = obj as ESALAVIRTUAL;

            //Poner las rutinas del Tools que se necesiten

            objSALA.RutUsuario = Utiles.ConvertToInt32(dr["rut_usuario"]);

            objSALA.CodTipoSalaVirtual = Utiles.ConvertToInt32(dr["Cod_TIPO_SALA_VIRTUAL"]);

            objSALA.NombreUsuario = Utiles.ConvertToString(dr["NOMBRE_USUARIO"]);

            objSALA.Contrasena = Convert.ToString(dr["CONTRASENA"]);

            objSALA.URL    = Convert.ToString(dr["URL"]);

            objSALA.Activo = Convert.ToBoolean(dr["flag_activo"]);

            objSALA.CodEmpresa = Utiles.ConvertToInt32(dr["cod_empresa"]);


        }

        #endregion
    }
}
