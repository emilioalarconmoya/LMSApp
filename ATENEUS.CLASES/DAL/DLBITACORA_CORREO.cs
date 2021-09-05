
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
    public class DLBITACORACORREO : DLBase
    {
        public DLBITACORACORREO()
        {
        }

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_BITACORA_CORREO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_BITACORA_CORREO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_BITACORA_CORREO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_BITACORA_CORREO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_bitacora_correo";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EBITACORACORREO objBITACORAACTIVIDADUSUARIO = obj as EBITACORACORREO;

            prms[0] = db.GetParameter();
            prms[0].Value = objBITACORAACTIVIDADUSUARIO.CodBitacoraCorreo;
            prms[0].ParameterName = "@cod_bitacora_correo";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(9);
            EBITACORACORREO objBITACORAACTIVIDADUSUARIO = obj as EBITACORACORREO;

            //Poner las rutinas del Tools que se necesiten
            

            prms[0] = db.GetParameter();
            prms[0].Value = objBITACORAACTIVIDADUSUARIO.Nombre;
            prms[0].ParameterName = "@nombre";

            prms[1] = db.GetParameter();
            prms[1].Value = objBITACORAACTIVIDADUSUARIO.Rut;
            prms[1].ParameterName = "@rut";

            prms[2] = db.GetParameter();
            prms[2].Value = objBITACORAACTIVIDADUSUARIO.Email;
            prms[2].ParameterName = "@email";

            prms[3] = db.GetParameter();
            prms[3].Value = objBITACORAACTIVIDADUSUARIO.Asunto;
            prms[3].ParameterName = "@asunto";

            prms[4] = db.GetParameter();
            prms[4].Value = objBITACORAACTIVIDADUSUARIO.FechaHora;
            prms[4].ParameterName = "@fecha_hora";

            prms[5] = db.GetParameter();
            prms[5].Value = objBITACORAACTIVIDADUSUARIO.Cuerpo;
            prms[5].ParameterName = "@cuerpo";

            prms[6] = db.GetParameter();
            prms[6].Value = objBITACORAACTIVIDADUSUARIO.Curso;
            prms[6].ParameterName = "@curso";

            prms[7] = db.GetParameter();
            prms[7].Value = objBITACORAACTIVIDADUSUARIO.CodEmpresa;
            prms[7].ParameterName = "@cod_empresa";

            prms[8] = db.GetParameter();
            prms[8].Value = objBITACORAACTIVIDADUSUARIO.CodtipoNotificacion;
            prms[8].ParameterName = "@cod_tipo_notificacion";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(8);
            EBITACORACORREO objBITACORAACTIVIDADUSUARIO = obj as EBITACORACORREO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objBITACORAACTIVIDADUSUARIO.CodBitacoraCorreo;
            prms[0].ParameterName = "@cod_activ_usr";

            prms[1] = db.GetParameter();
            prms[1].Value = objBITACORAACTIVIDADUSUARIO.Nombre;
            prms[1].ParameterName = "@nombre";

            prms[2] = db.GetParameter();
            prms[2].Value = objBITACORAACTIVIDADUSUARIO.Rut;
            prms[2].ParameterName = "@rut";

            prms[3] = db.GetParameter();
            prms[3].Value = objBITACORAACTIVIDADUSUARIO.Email;
            prms[3].ParameterName = "@email";

            prms[4] = db.GetParameter();
            prms[4].Value = objBITACORAACTIVIDADUSUARIO.Asunto;
            prms[4].ParameterName = "@asunto";

            prms[5] = db.GetParameter();
            prms[5].Value = objBITACORAACTIVIDADUSUARIO.FechaHora;
            prms[5].ParameterName = "@fecha_hora";

            prms[6] = db.GetParameter();
            prms[6].Value = objBITACORAACTIVIDADUSUARIO.Cuerpo;
            prms[6].ParameterName = "@cuerpo";

            prms[7] = db.GetParameter();
            prms[7].Value = objBITACORAACTIVIDADUSUARIO.CodEmpresa;
            prms[7].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EBITACORACORREO objRoot = obj as EBITACORACORREO;

            objRoot.CodBitacoraCorreo = id;
        }

        #endregion

        #region Public Methods

        public override void Fill(DomainObject obj, IDataReader dr)
        {
            EBITACORACORREO objBITACORAACTIVIDADUSUARIO = obj as EBITACORACORREO;

            //Poner las rutinas del Tools que se necesiten

            objBITACORAACTIVIDADUSUARIO.CodBitacoraCorreo = Utiles.ConvertToInt64(dr["cod_bitacora_correo"]);

            objBITACORAACTIVIDADUSUARIO.Nombre = Utiles.ConvertToString(dr["nombre"]);

            objBITACORAACTIVIDADUSUARIO.Rut = Utiles.ConvertToString(dr["rut"]);

            objBITACORAACTIVIDADUSUARIO.Email = Utiles.ConvertToString(dr["email"]);

            objBITACORAACTIVIDADUSUARIO.Asunto = Utiles.ConvertToString(dr["asunto"]);

            objBITACORAACTIVIDADUSUARIO.FechaHora = Utiles.ConvertToDateTime(dr["fecha_hora"]);

            objBITACORAACTIVIDADUSUARIO.Cuerpo = Utiles.ConvertToString(dr["cuerpo"]);

            objBITACORAACTIVIDADUSUARIO.CodEmpresa = Utiles.ConvertToInt32(dr["cod_empresa"]);

        }

        public DateTime FechaHoraUltimaBitacora(long CodActivUsr)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActivUsr;
            prms[0].ParameterName = "@cod_bitacora_correo";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_fecha_hora_ultima_bitacora", prms);
            if (dt.Rows.Count > 0)
            {
                return Utiles.ConvertToDateTime(dt.Rows[0][0]);
            }
            else
            {
                return DateTime.Now;
            }
        }

        public DataTable ReporteBitacora(string nombre, string email, string asunto, string rut, string fechaDesde, string fechaHasta, string curso, int codCaracteristica, int codAtributo, Int64 codEmpresa, int CodtipoNotificacion)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(11);

            prms[0] = db.GetParameter();
            prms[0].Value = nombre;
            prms[0].ParameterName = "@nombre";

            prms[1] = db.GetParameter();
            prms[1].Value = email;
            prms[1].ParameterName = "@email";

            prms[2] = db.GetParameter();
            prms[2].Value = asunto;
            prms[2].ParameterName = "@asunto";

            prms[3] = db.GetParameter();
            prms[3].Value = rut;
            prms[3].ParameterName = "@rut";

            prms[4] = db.GetParameter();
            prms[4].Value = fechaDesde;
            prms[4].ParameterName = "@fecha_desde";

            prms[5] = db.GetParameter();
            prms[5].Value = fechaHasta;
            prms[5].ParameterName = "@fecha_hasta";

            prms[6] = db.GetParameter();
            prms[6].Value = curso;
            prms[6].ParameterName = "@curso";

            prms[7] = db.GetParameter();
            prms[7].Value = codCaracteristica;
            prms[7].ParameterName = "@codcaracteristica";

            prms[8] = db.GetParameter();
            prms[8].Value = codAtributo;
            prms[8].ParameterName = "@codatributo";

            prms[9] = db.GetParameter();
            prms[9].Value = codEmpresa;
            prms[9].ParameterName = "@cod_empresa";

            prms[10] = db.GetParameter();
            prms[10].Value = CodtipoNotificacion;
            prms[10].ParameterName = "@codTipoNotificacion";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_bitacora_correo", prms);

            return dt;
        }

        public int CountCorreos(string fecha, Int64 codEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);
            
            prms[0] = db.GetParameter();
            prms[0].Value = fecha;
            prms[0].ParameterName = "@fecha";

            prms[1] = db.GetParameter();
            prms[1].Value = codEmpresa;
            prms[1].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_count_correo", prms);

            if (dt.Rows.Count > 0)
            {
                return Utiles.ConvertToInt32(dt.Rows[0][0]);
            }
            else
            {
                return 0;
            }
        }

        public DataTable ReporteBitacoraTotales(Int32 agno, Int64 codEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = agno;
            prms[0].ParameterName = "@agno";

            prms[1] = db.GetParameter();
            prms[1].Value = codEmpresa;
            prms[1].ParameterName = "@cod_empresa";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_totales_bitacora_correo", prms);

            return dt;
        }
        #endregion
    }
}
