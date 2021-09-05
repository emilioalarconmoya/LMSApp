
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
	/// Summary description for DLTUTORList.
	/// </summary>
    public class DLTUTORList : DLGenericBaseList<ETUTOR>
	{
		public DLTUTORList()
		{
            this._proc_select_all = "proc_select_TUTOR_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ETUTOR> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public ETUTOR SelectTutorActividad(long CodActivUsr)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActivUsr;
            prms[0].ParameterName = "@cod_activ_usr";


            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_tutor_actividad", prms);

            ETUTOR obj = new ETUTOR();

            while (dr.Read())
            {
                obj.RutUsuario = Utiles.ConvertToInt64(dr["rut_tutor"]);

                obj.CodActivUsr = Utiles.ConvertToDecimal(dr["cod_activ_usr"]);
            }

            dr.Close();

            return obj;
        }

		#endregion
	}
}
