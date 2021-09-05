using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.CLASES.DAL
{
    public class DLMATERIALAPOYOTUTORList : DLGenericBaseList<EMATERIALAPOYOTUTOR>
    {
        public DLMATERIALAPOYOTUTORList()
        {
            this._proc_select_all = "proc_select_MATERIAL_APOYO_TUTOR_all";
        }

        #region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EMATERIALAPOYOTUTOR> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public List<EMATERIALAPOYOTUTOR> SelectMaterialApoyoActividad(Int16 CodActividad, long codempresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@COD_ACTIVIDAD";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_material_apoyo_actividad_tutor", prms);


            List<EMATERIALAPOYOTUTOR> lst = new List<EMATERIALAPOYOTUTOR>();

            while (dr.Read())
            {
                EMATERIALAPOYOTUTOR objMaterialApoyo = new EMATERIALAPOYOTUTOR();

                objMaterialApoyo.CodActividadTutor = Utiles.ConvertToInt32(dr["cod_actividad_tutor"]);

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
