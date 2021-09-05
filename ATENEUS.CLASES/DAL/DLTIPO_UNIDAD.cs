
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLTIPOUNIDAD.
	/// </summary>
	public class DLTIPOUNIDAD : DLBase
	{
		public DLTIPOUNIDAD()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_TIPO_UNIDAD";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_TIPO_UNIDAD";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_TIPO_UNIDAD";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_TIPO_UNIDAD";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_tipo_unidad";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ETIPOUNIDAD objTIPOUNIDAD = obj as ETIPOUNIDAD;

            prms[0] = db.GetParameter();
            prms[0].Value = objTIPOUNIDAD.CodTipoUnidad;
            prms[0].ParameterName = "@cod_tipo_unidad";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ETIPOUNIDAD objTIPOUNIDAD = obj as ETIPOUNIDAD;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objTIPOUNIDAD.Nombre;
            prms[1].ParameterName = "@nombre";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ETIPOUNIDAD objTIPOUNIDAD = obj as ETIPOUNIDAD;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objTIPOUNIDAD.CodTipoUnidad;
            prms[0].ParameterName = "@cod_tipo_unidad";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objTIPOUNIDAD.Nombre;
            prms[1].ParameterName = "@nombre";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ETIPOUNIDAD objRoot = obj as ETIPOUNIDAD;

            objRoot.CodTipoUnidad = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ETIPOUNIDAD objTIPOUNIDAD = obj as ETIPOUNIDAD;
    
            //Poner las rutinas del Tools que se necesiten
            
            objTIPOUNIDAD.CodTipoUnidad = Utiles.ConvertToInt16(dr["cod_tipo_unidad"]);
            
            objTIPOUNIDAD.Nombre = Utiles.ConvertToString(dr["nombre"]);
            
        }

        #endregion

	}
}
