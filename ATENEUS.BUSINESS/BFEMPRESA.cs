using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;
using System.Data;

namespace ATENEUS.BUSINESS
{
    public class BFEMPRESA
    {
        private DLEMPRESA _objDAL;
        private DLEMPRESALIST _objDALList;
        public BFEMPRESA()
        {
            _objDAL = new DLEMPRESA();
            _objDALList = new DLEMPRESALIST();
        }
        //public EEMPRESA GetEMPRESA(Int64 CodEmpresa, string Nombre)
        //{
        //    return new EEMPRESA(CodEmpresa, Nombre);
        //}
        public EEMPRESA GetEMPRESA()
        {
            return new EEMPRESA();
        }
        public DataTable GetEMPRESAAll()
        {
            return _objDALList.SelectEmpresaParametros(-1,"");
        }

        public DataTable GetEmpresaParametros(long Rut, string Nombres)
        {
            return _objDALList.SelectEmpresaParametros(Rut, Nombres);
        }
        public bool UpdateEspacioDisco(Int64 CodEmpresa, long EspacioUtilizado)
        {
            return _objDALList.UpdateEspacioDiscoDAL(CodEmpresa, EspacioUtilizado);
        }

        public EEMPRESA GetEmpresaParametros(Int64 CodEmpresa)
        {
            return _objDALList.SelectEmpresaParametros(CodEmpresa);
        }

        public Int64 InsertEmpresa(EEMPRESA Emp)
        {
            return _objDALList.InsertEmpresaDAL(Emp);
        }

        public bool UpdateEmpresa(EEMPRESA Emp)
        {
            return _objDALList.UpdateEmpresaDAL(Emp);
        }
        public bool ExisteEmpresa(Int64 Rut)
        {
            return _objDALList.ExisteEmpresaDAL(Rut);
        }
    }
}
