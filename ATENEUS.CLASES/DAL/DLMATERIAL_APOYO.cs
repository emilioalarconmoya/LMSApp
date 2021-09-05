
using System;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLMATERIALAPOYO.
	/// </summary>
	public class DLMATERIALAPOYO : DLBase
	{
		public DLMATERIALAPOYO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_MATERIAL_APOYO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_MATERIAL_APOYO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_MATERIAL_APOYO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_MATERIAL_APOYO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_material";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EMATERIALAPOYO objMATERIALAPOYO = obj as EMATERIALAPOYO;

            prms[0] = db.GetParameter();
            prms[0].Value = objMATERIALAPOYO.CodMaterial;
            prms[0].ParameterName = "@cod_material";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(4);
            EMATERIALAPOYO objMATERIALAPOYO = obj as EMATERIALAPOYO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objMATERIALAPOYO.Descripcion;
            prms[0].ParameterName = "@descripcion";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objMATERIALAPOYO.CodActividad;
            prms[1].ParameterName = "@cod_actividad";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objMATERIALAPOYO.Archivo;
            prms[2].ParameterName = "@archivo";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objMATERIALAPOYO.Nombre;
            prms[3].ParameterName = "@nombre";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            EMATERIALAPOYO objMATERIALAPOYO = obj as EMATERIALAPOYO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objMATERIALAPOYO.CodMaterial;
            prms[0].ParameterName = "@cod_material";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objMATERIALAPOYO.CodActividad;
            prms[1].ParameterName = "@cod_actividad";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objMATERIALAPOYO.Archivo;
            prms[2].ParameterName = "@archivo";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objMATERIALAPOYO.Nombre;
            prms[3].ParameterName = "@nombre";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objMATERIALAPOYO.Descripcion;
            prms[4].ParameterName = "@descripcion";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EMATERIALAPOYO objRoot = obj as EMATERIALAPOYO;

            objRoot.CodMaterial = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EMATERIALAPOYO objMATERIALAPOYO = obj as EMATERIALAPOYO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objMATERIALAPOYO.CodMaterial = Utiles.ConvertToDecimal(dr["cod_material"]);
            
            objMATERIALAPOYO.CodActividad = Utiles.ConvertToInt16(dr["cod_actividad"]);
            
            objMATERIALAPOYO.Archivo = Utiles.ConvertToString(dr["archivo"]);
            
            objMATERIALAPOYO.Nombre = Utiles.ConvertToString(dr["nombre"]);

            objMATERIALAPOYO.Descripcion = Utiles.ConvertToString(dr["descripcion"]);
            
        }

        #endregion

	}
}
