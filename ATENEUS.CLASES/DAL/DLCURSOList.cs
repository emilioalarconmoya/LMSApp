using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.CLASES.DAL
{
    public class DLCURSOList : DLGenericBaseList<ECURSO>
    {
        public DLCURSOList()
        {
            this._proc_select_all = "proc_select_curso_all";
        }

        #region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ECURSO> SelectAll(Int64 CodEmpresa)
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

        public List<ECURSO> SelectCursosParametros(string Nombre, int codTipo, Int64 CodEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = Utiles.SubStringSQL(Nombre);
            prms[0].ParameterName = "@Nombre";

            prms[1] = db.GetParameter();
            prms[1].Value = codTipo;
            prms[1].ParameterName = "@codTipo";
			
			prms[2] = db.GetParameter();
            prms[2].Value = CodEmpresa; 
            prms[2].ParameterName = "@cod_empresa";


            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_buscador_curso", prms);


            List<ECURSO> lst = new List<ECURSO>();

            while (dr.Read())
            {
                ECURSO objcurso = new ECURSO();

                objcurso.CodCurso = Utiles.ConvertToInt16(dr["cod_curso"]);

                objcurso.NombreCurso = Utiles.ConvertToString(dr["nombre_curso"]);

                objcurso.CodTipoCurso = Utiles.ConvertToInt16(dr["COD_TIPO_CURSO"]);

                objcurso.NombreTipoCurso = Utiles.ConvertToString(dr["NOMBRE_TIPO_CURSO"]);
				
				objcurso.CodEmpresa = Utiles.ConvertToInt64(dr["COD_EMPRESA"]);


                lst.Add(objcurso);
            }
            dr.Close();
            return lst;
        }

        public string GetNombreCurso(Int64 CodMalla, Int64 CodEmpresa)
        {
            string strNombre = "";
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms;
            prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodMalla;
            prms[0].ParameterName = "@COD_CURSO";
			
			prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa; 
            prms[1].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_NOMBRE_CURSO", prms);
            while (dr.Read())
            {
                strNombre = Utiles.ConvertToString(dr["NOMBRE_CURSO"]);
            }
            dr.Close();
            return strNombre;
        }

        #endregion
    }
}
