using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.CLASES.DAL
{
    public class DLCATALOGOList : DLGenericBaseList<ECATALOGO>
    {
        public DLCATALOGOList()
        {
            this._proc_select_all = "proc_select_CATALOGO_all";
        }

        #region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ECATALOGO> SelectAll(Int64 codEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = codEmpresa;
            prms[0].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, prms);

            return GetCollection(dr);
        }

        public List<ECATALOGO> SelectBuscadorCatalogoParametros(string Nombre, int estado, Int64 codEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = Utiles.SubStringSQL(Nombre);
            prms[0].ParameterName = "@Nombre";

            prms[1] = db.GetParameter();
            prms[1].Value = estado;
            prms[1].ParameterName = "@codestado";

            prms[2] = db.GetParameter();
            prms[2].Value = codEmpresa;
            prms[2].ParameterName = "@cod_empresa";


            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_buscador_CATALOGOs", prms);


            List<ECATALOGO> lst = new List<ECATALOGO>();

            while (dr.Read())
            {
                ECATALOGO objTIPO = new ECATALOGO();

                objTIPO.Codcatalogo = Utiles.ConvertToInt16(dr["COD_CATALOGO"]);

                objTIPO.Nombre = Utiles.ConvertToString(dr["NOMBRE_CATALOGO"]);

                objTIPO.FlagActivo = Utiles.ConvertToBoolean(dr["flag_activo"]);

                objTIPO.CodEmpresa = Utiles.ConvertToInt16(dr["cod_empresa"]);

                lst.Add(objTIPO);
            }
            dr.Close();
            return lst;
        }

        #endregion
    }
}