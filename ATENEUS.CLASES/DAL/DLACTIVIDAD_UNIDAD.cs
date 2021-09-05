
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLACTIVIDADUNIDAD.
	/// </summary>
	public class DLACTIVIDADUNIDAD : DLBase
	{
		public DLACTIVIDADUNIDAD()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_ACTIVIDAD_UNIDAD";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_ACTIVIDAD_UNIDAD";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_ACTIVIDAD_UNIDAD";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_ACTIVIDAD_UNIDAD";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_actividad";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EACTIVIDADUNIDAD objACTIVIDADUNIDAD = obj as EACTIVIDADUNIDAD;

            prms[0] = db.GetParameter();
            prms[0].Value = objACTIVIDADUNIDAD.CodActividad;
            prms[0].ParameterName = "@cod_actividad";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(7);
            EACTIVIDADUNIDAD objACTIVIDADUNIDAD = obj as EACTIVIDADUNIDAD;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objACTIVIDADUNIDAD.CodActividad;
            prms[0].ParameterName = "@cod_actividad";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objACTIVIDADUNIDAD.CodUnidad;
            prms[1].ParameterName = "@cod_unidad";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objACTIVIDADUNIDAD.OrdenRelativo;
            prms[2].ParameterName = "@orden_relativo";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objACTIVIDADUNIDAD.NivelPrerequisitos;
            prms[3].ParameterName = "@nivel_prerequisitos";

            prms[4] = db.GetParameter();
            prms[4].Value = objACTIVIDADUNIDAD.FechaHora;
            prms[4].ParameterName = "@FECHA_HORA";

            prms[5] = db.GetParameter();
            prms[5].Value = objACTIVIDADUNIDAD.FlagActivo;
            prms[5].ParameterName = "@FLAG_ACTIVO";

            prms[6] = db.GetParameter();
            prms[6].Value = objACTIVIDADUNIDAD.Nivel;
            prms[6].ParameterName = "@nivel";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(7);
            EACTIVIDADUNIDAD objACTIVIDADUNIDAD = obj as EACTIVIDADUNIDAD;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objACTIVIDADUNIDAD.CodActividad;
            prms[0].ParameterName = "@cod_actividad";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objACTIVIDADUNIDAD.CodUnidad;
            prms[1].ParameterName = "@cod_unidad";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objACTIVIDADUNIDAD.OrdenRelativo;
            prms[2].ParameterName = "@orden_relativo";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objACTIVIDADUNIDAD.NivelPrerequisitos;
            prms[3].ParameterName = "@nivel_prerequisitos";

            prms[4] = db.GetParameter();
            prms[4].Value = objACTIVIDADUNIDAD.FechaHora;
            prms[4].ParameterName = "@FECHA_HORA";

            prms[5] = db.GetParameter();
            prms[5].Value = objACTIVIDADUNIDAD.FlagActivo;
            prms[5].ParameterName = "@FLAG_ACTIVO";

            prms[6] = db.GetParameter();
            prms[6].Value = objACTIVIDADUNIDAD.Nivel;
            prms[6].ParameterName = "@nivel";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EACTIVIDADUNIDAD objRoot = obj as EACTIVIDADUNIDAD;

            objRoot.CodActividad = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EACTIVIDADUNIDAD objACTIVIDADUNIDAD = obj as EACTIVIDADUNIDAD;
    
            //Poner las rutinas del Tools que se necesiten
            
            objACTIVIDADUNIDAD.CodActividad = Utiles.ConvertToInt16(dr["cod_actividad"]);
            
            objACTIVIDADUNIDAD.CodUnidad = Utiles.ConvertToInt16(dr["cod_unidad"]);
            
            objACTIVIDADUNIDAD.OrdenRelativo = Utiles.ConvertToInt32(dr["orden_relativo"]);

            objACTIVIDADUNIDAD.NivelPrerequisitos = Utiles.ConvertToInt32(dr["nivel_prerequisitos"]);

            objACTIVIDADUNIDAD.FechaHora = Convert.ToDateTime(dr["fecha_hora"]);

            objACTIVIDADUNIDAD.FlagActivo = Convert.ToBoolean(dr["flag_activo"]);

            objACTIVIDADUNIDAD.Nivel = Utiles.ConvertToInt16(dr["nivel"]);

        }


         public DataTable SelectUnidadActividad(Int16 CodUnidad, Int16 CodActividad)
         {
             DB db = DatabaseFactory.Instance.GetDatabase();
             IDbDataParameter[] prms;
             prms = db.GetArrayParameter(2);

             prms[0] = db.GetParameter();
             prms[0].Value = CodUnidad;
             prms[0].ParameterName = "@COD_UNIDAD";

             prms[1] = db.GetParameter();
             prms[1].Value = CodActividad;
             prms[1].ParameterName = "@COD_ACTIVIDAD";

             DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_unidad_actividad", prms);

             return dt;
         }

        public void  ActualizaFlagActivo(long CodActividad , long CodUnidad, Boolean flagActivo, long codEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = CodUnidad;
            prms[0].ParameterName = "@COD_UNIDAD";

            prms[1] = db.GetParameter();
            prms[1].Value = CodActividad;
            prms[1].ParameterName = "@COD_ACTIVIDAD";

            prms[2] = db.GetParameter();
            prms[2].Value = flagActivo;
            prms[2].ParameterName = "@flag_activo";

            db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_update_ACTIVIDAD_UNIDAD_flag_activo", prms);

           
        }
        #endregion

	}
}
