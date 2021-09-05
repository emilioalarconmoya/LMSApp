using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;
namespace ATENEUS.CLASES.DAL
{
    public class DLTIPOSALAVIRTUALList : DLGenericBaseList<ETIPOSALAVIRTUAL>
    {
        public DLTIPOSALAVIRTUALList()
        {
            this._proc_select_all = "proc_select_TIPO_SALA_VIRTUAL_all";
        }

        #region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ETIPOSALAVIRTUAL> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        #endregion
    }
}
