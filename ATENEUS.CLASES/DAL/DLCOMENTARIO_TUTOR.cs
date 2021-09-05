using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
    public class DLCOMENTARIOTUTOR : DLBase
    {
        public DLCOMENTARIOTUTOR()
        {
        }

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_COMENTARIO_TUTOR";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_COMENTARIO_TUTOR";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_COMENTARIO_TUTOR_";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_COMENTARIO_TUTOR";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_comentario";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ECOMENTARIOTUTOR objComentario = obj as ECOMENTARIOTUTOR;

            prms[0] = db.GetParameter();
            prms[0].Value = objComentario.CodComentario;
            prms[0].ParameterName = "@cod_comentario";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(6);
            ECOMENTARIOTUTOR objComentario = obj as ECOMENTARIOTUTOR;

            //Poner las rutinas del Tools que se necesiten

           
            prms[0] = db.GetParameter();
            prms[0].Value = objComentario.CodActividadTutor;
            prms[0].ParameterName = "@cod_actividad_tutor";

            prms[1] = db.GetParameter();
            prms[1].Value = objComentario.Comentario;
            prms[1].ParameterName = "@comentario";

            prms[2] = db.GetParameter();
            prms[2].Value = objComentario.FechaIngreso;
            prms[2].ParameterName = "@fecha";

            prms[3] = db.GetParameter();
            prms[3].Value = objComentario.RutUsuario;
            prms[3].ParameterName = "@rut_usuario";

            prms[4] = db.GetParameter();
            prms[4].Value = objComentario.codEmpresa;
            prms[4].ParameterName = "@cod_empresa";

            prms[5] = db.GetParameter();
            prms[5].Value = objComentario.FechaRespuesta;
            prms[5].ParameterName = "@fecha_respuesta";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ECOMENTARIOTUTOR objComentario = obj as ECOMENTARIOTUTOR;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objComentario.CodComentario;
            prms[0].ParameterName = "@cod_comentario";

            prms[1] = db.GetParameter();
            prms[1].Value = objComentario.FechaRespuesta;
            prms[1].ParameterName = "@fecha_respuesta";


            prms[2] = db.GetParameter();
            prms[2].Value = objComentario.Respuesta;
            prms[2].ParameterName = "@respuesta";

           

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ECOMENTARIOTUTOR objRoot = obj as ECOMENTARIOTUTOR;

            objRoot.CodComentario = Utiles.ConvertToInt32(id);
        }

        #endregion

        #region Public Methods

        public override void Fill(DomainObject obj, IDataReader dr)
        {
            ECOMENTARIOTUTOR objcomentario = obj as ECOMENTARIOTUTOR;

            //Poner las rutinas del Tools que se necesiten

            objcomentario.CodComentario = Utiles.ConvertToInt32(dr["cod_comentario"]);

            objcomentario.CodActividadTutor = Utiles.ConvertToInt32(dr["cod_actividad_tutor"]);

            objcomentario.Comentario = Utiles.ConvertToString(dr["comentario"]);

            objcomentario.FechaIngreso = Utiles.ConvertToDateTime(dr["fecha"]);

            objcomentario.RutUsuario = Utiles.ConvertToInt32(dr["rut_usuario"]);

            objcomentario.codEmpresa = Utiles.ConvertToInt32(dr["cod_empresa"]);

            objcomentario.FechaRespuesta = Utiles.ConvertToDateTime(dr["fecha_respuesta"]);

            objcomentario.Respuesta = Utiles.ConvertToString(dr["respuesta"]);


        }

        #endregion
    }
}
