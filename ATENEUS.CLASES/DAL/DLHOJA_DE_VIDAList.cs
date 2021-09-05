
using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLHOJADEVIDAList.
	/// </summary>
    public class DLHOJADEVIDAList : DLGenericBaseList<EHOJADEVIDA>
	{
		public DLHOJADEVIDAList()
		{
            this._proc_select_all = "proc_select_HOJA_DE_VIDA_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EHOJADEVIDA> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

		#endregion
	}
}
