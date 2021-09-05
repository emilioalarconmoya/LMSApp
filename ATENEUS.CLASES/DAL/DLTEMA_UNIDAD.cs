
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLTEMAUNIDAD.
	/// </summary>
	public class DLTEMAUNIDAD : DLBase
	{
		public DLTEMAUNIDAD()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_TEMA_UNIDAD";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_TEMA_UNIDAD";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_TEMA_UNIDAD";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_TEMA_UNIDAD";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_tema_unidad";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ETEMAUNIDAD objTEMAUNIDAD = obj as ETEMAUNIDAD;

            prms[0] = db.GetParameter();
            prms[0].Value = objTEMAUNIDAD.CodTemaUnidad;
            prms[0].ParameterName = "@cod_tema_unidad";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ETEMAUNIDAD objTEMAUNIDAD = obj as ETEMAUNIDAD;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objTEMAUNIDAD.Nombre;
            prms[1].ParameterName = "@nombre";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ETEMAUNIDAD objTEMAUNIDAD = obj as ETEMAUNIDAD;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objTEMAUNIDAD.CodTemaUnidad;
            prms[0].ParameterName = "@cod_tema_unidad";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objTEMAUNIDAD.Nombre;
            prms[1].ParameterName = "@nombre";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ETEMAUNIDAD objRoot = obj as ETEMAUNIDAD;

            objRoot.CodTemaUnidad = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ETEMAUNIDAD objTEMAUNIDAD = obj as ETEMAUNIDAD;
    
            //Poner las rutinas del Tools que se necesiten
            
            objTEMAUNIDAD.CodTemaUnidad = Utiles.ConvertToInt16(dr["cod_tema_unidad"]);

            objTEMAUNIDAD.Nombre = Utiles.ConvertToString(dr["nombre"]);
            
        }

        #endregion

	}
}
