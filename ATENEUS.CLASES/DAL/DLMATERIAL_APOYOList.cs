
using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;
//using Moebius.ErrorManagement;
//using ATENEUS.BUSINESS.Collections;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLMATERIALAPOYOList.
	/// </summary>
    public class DLMATERIALAPOYOList : DLGenericBaseList<EMATERIALAPOYO>
	{
		public DLMATERIALAPOYOList()
		{
            this._proc_select_all = "proc_select_MATERIAL_APOYO_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EMATERIALAPOYO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public List<EMATERIALAPOYO> SelectMaterialApoyoActividad(Int16 CodActividad)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@COD_ACTIVIDAD";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_material_apoyo_actividad", prms);


            List<EMATERIALAPOYO> lst = new List<EMATERIALAPOYO>();

            while (dr.Read())
            {
                EMATERIALAPOYO objMaterialApoyo = new EMATERIALAPOYO();

                objMaterialApoyo.CodActividad = Utiles.ConvertToInt16(dr["cod_actividad"]);

                objMaterialApoyo.CodMaterial = Utiles.ConvertToInt16(dr["cod_material"]);

                objMaterialApoyo.Archivo = Utiles.ConvertToString(dr["archivo"]);

                objMaterialApoyo.Descripcion = Utiles.ConvertToString(dr["descripcion"]);

                objMaterialApoyo.Nombre = Utiles.ConvertToString(dr["nombre"]);

                lst.Add(objMaterialApoyo);
            }
            dr.Close();
            return lst;
        }

		#endregion
	}
}
