
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
	/// Summary description for DLMENSAJEList.
	/// </summary>
    public class DLMENSAJEList : DLGenericBaseList<EMENSAJE>
	{
		public DLMENSAJEList()
		{
            this._proc_select_all = "proc_select_MENSAJE_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EMENSAJE> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public DataTable SelectMensajesTutor(long CodActividad, long RutOrigen, long RutDestino)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = CodActividad;
            prms[0].ParameterName = "@cod_actividad";

            prms[1] = db.GetParameter();
            prms[1].Value = RutOrigen;
            prms[1].ParameterName = "@rut_origen";

            prms[2] = db.GetParameter();
            prms[2].Value = RutDestino;
            prms[2].ParameterName = "@rut_destino";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_mensajes_tutor", prms);

            return dt;
        }

		#endregion
	}
}
