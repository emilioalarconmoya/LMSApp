
using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;
using System.Configuration;
//using Moebius.ErrorManagement;
//using ATENEUS.BUSINESS.Collections;

namespace ATENEUS.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPREGUNTAList.
	/// </summary>
    public class DLPREGUNTAList : DLGenericBaseList<EPREGUNTA>
	{
		public DLPREGUNTAList()
		{
            this._proc_select_all = "proc_select_PREGUNTA_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EPREGUNTA> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public DataSet SelectPreguntasByExcel(string newFile)
        {
            string connectionString = DbProviderHelper.GetExcelConn(newFile);
            var ds = new DataSet();
            using (var conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                OleDbDataAdapter dadp = new OleDbDataAdapter("SELECT * FROM [Hoja1$]", conn);
                dadp.TableMappings.Add("tbl", "Table");
                dadp.Fill(ds);
            }
            return ds;
        }

		#endregion
	}
}
