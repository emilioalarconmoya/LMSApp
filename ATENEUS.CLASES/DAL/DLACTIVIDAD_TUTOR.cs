using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
    public class DLACTIVIDADTUTOR : DLBase
    {
        public DLACTIVIDADTUTOR()
        {
        }

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_ACTIVIDAD_TUTOR";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_ACTIVIDAD_TUTOR";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_ACTIVIDAD_TUTOR";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_ACTIVIDAD_TUTOR";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_actividad_TUTOR";


            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EACTIVIDADTUTOR objACTIVIDADUNIDAD = obj as EACTIVIDADTUTOR;

            prms[0] = db.GetParameter();
            prms[0].Value = objACTIVIDADUNIDAD.CodActividad;
            prms[0].ParameterName = "@cod_actividad";

            prms[1] = db.GetParameter();
            prms[1].Value = objACTIVIDADUNIDAD.RutUsuario;
            prms[1].ParameterName = "@rut_usuario";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(6);
            EACTIVIDADTUTOR objACTIVIDADUNIDAD = obj as EACTIVIDADTUTOR;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objACTIVIDADUNIDAD.CodActividad;
            prms[0].ParameterName = "@cod_actividad";

            prms[1] = db.GetParameter();
            prms[1].Value = objACTIVIDADUNIDAD.Nombre;
            prms[1].ParameterName = "@nombre_Act";

            prms[2] = db.GetParameter();
            prms[2].Value = objACTIVIDADUNIDAD.RutUsuario;
            prms[2].ParameterName = "@rut_usuario";

            prms[3] = db.GetParameter();
            prms[3].Value = objACTIVIDADUNIDAD.Fechainicio;
            prms[3].ParameterName = "@fecha_inicio";

            prms[4] = db.GetParameter();
            prms[4].Value = objACTIVIDADUNIDAD.FechaFin;
            prms[4].ParameterName = "@fecha_fin";

            prms[5] = db.GetParameter();
            prms[5].Value = objACTIVIDADUNIDAD.CodEmpresa;
            prms[5].ParameterName = "@cod_empresa";




            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(7);
            EACTIVIDADTUTOR objACTIVIDADUNIDAD = obj as EACTIVIDADTUTOR;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objACTIVIDADUNIDAD.CodActividad;
            prms[0].ParameterName = "@cod_actividad";

            prms[1] = db.GetParameter();
            prms[1].Value = objACTIVIDADUNIDAD.Nombre;
            prms[1].ParameterName = "@nombre_Act";

            prms[2] = db.GetParameter();
            prms[2].Value = objACTIVIDADUNIDAD.RutUsuario;
            prms[2].ParameterName = "@rut_usuario";

            prms[3] = db.GetParameter();
            prms[3].Value = objACTIVIDADUNIDAD.Fechainicio;
            prms[3].ParameterName = "@fecha_inicio";

            prms[4] = db.GetParameter();
            prms[4].Value = objACTIVIDADUNIDAD.FechaFin;
            prms[4].ParameterName = "@fecha_fin";

            prms[5] = db.GetParameter();
            prms[5].Value = objACTIVIDADUNIDAD.CodActividadTutor;
            prms[5].ParameterName = "@cod_actividad_tutor";

            prms[6] = db.GetParameter();
            prms[6].Value = objACTIVIDADUNIDAD.CodEmpresa;
            prms[6].ParameterName = "@cod_empresa";



            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EACTIVIDADTUTOR objRoot = obj as EACTIVIDADTUTOR;

            objRoot.CodActividad = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

        public override void Fill(DomainObject obj, IDataReader dr)
        {
            EACTIVIDADTUTOR objACTIVIDADUNIDAD = obj as EACTIVIDADTUTOR;

            //Poner las rutinas del Tools que se necesiten

            objACTIVIDADUNIDAD.CodActividad = Utiles.ConvertToInt16(dr["cod_actividad"]);

            objACTIVIDADUNIDAD.Nombre = Utiles.ConvertToString(dr["nombre_act"]);

            objACTIVIDADUNIDAD.RutUsuario = Utiles.ConvertToInt32(dr["rut_usuario"]);

            objACTIVIDADUNIDAD.Fechainicio = Utiles.ConvertToDateTime(dr["fecha_inicio"]);

            objACTIVIDADUNIDAD.FechaFin = Convert.ToDateTime(dr["fecha_fin"]);

            objACTIVIDADUNIDAD.CodActividadTutor = Utiles.ConvertToInt32(dr["cod_actividad_tutor"]);

            objACTIVIDADUNIDAD.NombreAct = Utiles.ConvertToString(dr["nombre"]);

            objACTIVIDADUNIDAD.CodEmpresa = Utiles.ConvertToInt32(dr["cod_empresa"]);



        }
        #endregion

    }
}
