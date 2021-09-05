
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
	/// Summary description for DLFOROList.
	/// </summary>
    public class DLCATALOGOACTIVIDADList : DLGenericBaseList<ECATALOGOACTIVIDAD>
	{
		public DLCATALOGOACTIVIDADList()
		{
            this._proc_select_all = "proc_select_CATALOGO_ACTIVIDAD_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ECATALOGOACTIVIDAD> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        //public DataTable SelectForoActividad(Int32 CodActividad)
        //{
        //    DB db = DatabaseFactory.Instance.GetDatabase();
        //    IDbDataParameter[] prms;
        //    prms = db.GetArrayParameter(1);

        //    prms[0] = db.GetParameter();
        //    prms[0].Value = CodActividad;
        //    prms[0].ParameterName = "@CodActividad";

        //    DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_foro_actividad", prms);

        //    return dt;
        //}

        public List<ECATALOGOACTIVIDAD> SelectBuscadorCATALOGO(String Nombre, Int32 CodActividad, Int16 codEstado, Int32 codCATALOGO)
        {   
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;


            IDataReader dr;

            prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = Utiles.SubStringSQL(Nombre);
            prms[0].ParameterName = "@Nombre";

            prms[1] = db.GetParameter();
            prms[1].Value = CodActividad;
            prms[1].ParameterName = "@CodActividad";

            prms[2] = db.GetParameter();
            prms[2].Value = codEstado;
            prms[2].ParameterName = "@cod_estado";

            prms[3] = db.GetParameter();
            prms[3].Value = codCATALOGO;
            prms[3].ParameterName = "@cod_CATALOGO";


            dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_buscador_CATALOGOs_actividad", prms);

            return GetCollection(dr);
        }

            //public DataTable SelectTemasForo(int IdForo)
            //{
            //    DB db = DatabaseFactory.Instance.GetDatabase();
            //    IDbDataParameter[] prms;
            //    prms = db.GetArrayParameter(1);

            //    prms[0] = db.GetParameter();
            //    prms[0].Value = IdForo;
            //    prms[0].ParameterName = "@IdForo";

            //    DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_temas_foro", prms);

            //    return dt;
            //}

            //public DataTable SelectRespuestasForo(int IdHead)
            //{
            //    DB db = DatabaseFactory.Instance.GetDatabase();
            //    IDbDataParameter[] prms;
            //    prms = db.GetArrayParameter(1);

            //    prms[0] = db.GetParameter();
            //    prms[0].Value = IdHead;
            //    prms[0].ParameterName = "@IdHead";

            //    DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_respuesta_foro", prms);

            //    return dt;
            //}

            //public Boolean ExisteForoActividad(Int32 CodActividad)
            //{
            //    Boolean blnResultado = false;

            //    DB db = DatabaseFactory.Instance.GetDatabase();
            //    IDbDataParameter[] prms;
            //    prms = db.GetArrayParameter(1);

            //    prms[0] = db.GetParameter();
            //    prms[0].Value = CodActividad;
            //    prms[0].ParameterName = "@COD_ACTIVIDAD";

            //    DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_EXISTE_FORO_ACTIVIDAD", prms);

            //    if (Utiles.ConvertToInt16(dt.Rows[0][0]) > 0)
            //    {
            //        blnResultado = true;
            //    }
            //    return blnResultado;
            //}

            //public Boolean ExisteForoUnidad(Int32 CodUnidad)
            //{
            //    Boolean blnResultado = false;

            //    DB db = DatabaseFactory.Instance.GetDatabase();
            //    IDbDataParameter[] prms;
            //    prms = db.GetArrayParameter(1);

            //    prms[0] = db.GetParameter();
            //    prms[0].Value = CodUnidad;
            //    prms[0].ParameterName = "@COD_UNIDAD";

            //    DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_EXISTE_FORO_UNIDAD", prms);

            //    if (Utiles.ConvertToInt16(dt.Rows[0][0]) > 0)
            //    {
            //        blnResultado = true;
            //    }
            //    return blnResultado;
            //}

            //public Int16 SerialForo()
            //{
            //    Int16 intResultado = 0;

            //    DB db = DatabaseFactory.Instance.GetDatabase();

            //    DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_SERIAL_FORO", null);

            //    intResultado = Utiles.ConvertToInt16(dt.Rows[0][0]);

            //    return intResultado;
            //}

            #endregion
        }
}
