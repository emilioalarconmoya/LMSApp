
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLESTADOACTIVIDAD.
	/// </summary>
	public class DLESTADOACTIVIDAD : DLBase
	{
		public DLESTADOACTIVIDAD()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_ESTADO_ACTIVIDAD";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_ESTADO_ACTIVIDAD";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_ESTADO_ACTIVIDAD";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_ESTADO_ACTIVIDAD";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_estado";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EESTADOACTIVIDAD objESTADOACTIVIDAD = obj as EESTADOACTIVIDAD;

            prms[0] = db.GetParameter();
            prms[0].Value = objESTADOACTIVIDAD.CodEstado;
            prms[0].ParameterName = "@cod_estado";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EESTADOACTIVIDAD objESTADOACTIVIDAD = obj as EESTADOACTIVIDAD;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objESTADOACTIVIDAD.Nombre;
            prms[1].ParameterName = "@nombre";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EESTADOACTIVIDAD objESTADOACTIVIDAD = obj as EESTADOACTIVIDAD;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objESTADOACTIVIDAD.CodEstado;
            prms[0].ParameterName = "@cod_estado";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objESTADOACTIVIDAD.Nombre;
            prms[1].ParameterName = "@nombre";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EESTADOACTIVIDAD objRoot = obj as EESTADOACTIVIDAD;

            objRoot.CodEstado = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EESTADOACTIVIDAD objESTADOACTIVIDAD = obj as EESTADOACTIVIDAD;
    
            //Poner las rutinas del Tools que se necesiten
            
            objESTADOACTIVIDAD.CodEstado = Utiles.ConvertToInt16(dr["cod_estado"]);
            
            objESTADOACTIVIDAD.Nombre = Utiles.ConvertToString(dr["nombre"]);
            
        }

        #endregion

	}
}
