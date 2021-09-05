
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLTIPOACTIVIDAD.
	/// </summary>
	public class DLTIPOACTIVIDAD : DLBase
	{
		public DLTIPOACTIVIDAD()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_TIPO_ACTIVIDAD";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_TIPO_ACTIVIDAD";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_TIPO_ACTIVIDAD";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_TIPO_ACTIVIDAD";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_tipo";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ETIPOACTIVIDAD objTIPOACTIVIDAD = obj as ETIPOACTIVIDAD;

            prms[0] = db.GetParameter();
            prms[0].Value = objTIPOACTIVIDAD.CodTipo;
            prms[0].ParameterName = "@cod_tipo";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ETIPOACTIVIDAD objTIPOACTIVIDAD = obj as ETIPOACTIVIDAD;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objTIPOACTIVIDAD.Nombre;
            prms[1].ParameterName = "@nombre";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ETIPOACTIVIDAD objTIPOACTIVIDAD = obj as ETIPOACTIVIDAD;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objTIPOACTIVIDAD.CodTipo;
            prms[0].ParameterName = "@cod_tipo";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objTIPOACTIVIDAD.Nombre;
            prms[1].ParameterName = "@nombre";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ETIPOACTIVIDAD objRoot = obj as ETIPOACTIVIDAD;

            objRoot.CodTipo = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ETIPOACTIVIDAD objTIPOACTIVIDAD = obj as ETIPOACTIVIDAD;
    
            //Poner las rutinas del Tools que se necesiten
            
            objTIPOACTIVIDAD.CodTipo = Utiles.ConvertToInt16(dr["cod_tipo"]);
            
            objTIPOACTIVIDAD.Nombre = Utiles.ConvertToString(dr["nombre"]);
            
        }

        #endregion

	}
}
