﻿
using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.CLASES.DAL
{
    public class DLTIPONOTIFICACIONList : DLGenericBaseList<ETIPONOTIFICACION>
    {
        public DLTIPONOTIFICACIONList()
        {
            this._proc_select_all = "proc_select_TIPO_NOTIFICACION_all";
        }

        #region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ETIPONOTIFICACION> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        #endregion
    }
}
