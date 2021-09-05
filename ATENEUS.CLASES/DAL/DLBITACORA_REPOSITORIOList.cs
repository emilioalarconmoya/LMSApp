
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
	/// Summary description for DLBITACORAREPOSITORIOList.
	/// </summary>
    public class DLBITACORAREPOSITORIOList : DLGenericBaseList<EBITACORAREPOSITORIO>
	{
		public DLBITACORAREPOSITORIOList()
		{
            this._proc_select_all = "proc_select_BITACORA_REPOSITORIO_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EBITACORAREPOSITORIO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

		#endregion
	}
}
