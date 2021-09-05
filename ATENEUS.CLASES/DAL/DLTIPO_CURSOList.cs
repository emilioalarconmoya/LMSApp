using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.CLASES.DAL
{
    public class DLTIPOCURSOList : DLGenericBaseList<ETIPOCURSO>
    {
        public DLTIPOCURSOList()
        {
            this._proc_select_all = "proc_select_TIPO_CURSO_all";
        }

        #region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ETIPOCURSO> SelectAll(Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodEmpresa;
            prms[0].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, prms);

            return GetCollection(dr);
        }

        public List<ETIPOCURSO> SelectTipoCursoParametros(string Nombre, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = Utiles.SubStringSQL(Nombre);
            prms[0].ParameterName = "@Nombre";
			
			prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa; 
            prms[1].ParameterName = "@cod_empresa";


            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_buscador_tipo_curso", prms);


            List<ETIPOCURSO> lst = new List<ETIPOCURSO>();

            while (dr.Read())
            {
                ETIPOCURSO objTIPO = new ETIPOCURSO();

                objTIPO.CodTipoCurso= Utiles.ConvertToInt16(dr["COD_TIPO_CURSO"]);

                objTIPO.NombreCurso = Utiles.ConvertToString(dr["NOMBRE_CURSO"]);

                objTIPO.Observacion = Utiles.ConvertToString(dr["OBSERVACION"]); 
				
				objTIPO.CodEmpresa = Utiles.ConvertToInt64(dr["cod_empresa"]); 

                lst.Add(objTIPO);
            }
            dr.Close();
            return lst;
        }

        #endregion
    }
}