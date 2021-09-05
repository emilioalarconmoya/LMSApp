
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;
using System.Data;

namespace ATENEUS.BUSINESS
{
    public class BFSESSIONUSUARIO
    {
        private DLSESSIONUSUARIO _objDAL;

        public BFSESSIONUSUARIO()
		{
            _objDAL = new DLSESSIONUSUARIO();
		}

		public ESESSIONUSUARIO GetSESSIONUSUARIO()
		{
            return new ESESSIONUSUARIO();
		}

        public ESESSIONUSUARIO GetSESSIONUSUARIO(long id)
		{
            return new ESESSIONUSUARIO(id);
		}

        public ESESSIONUSUARIO GetSESSIONUSUARIO(long Rut, string Passwd, string Email)
        {
            ESESSIONUSUARIO objUSUARIO = _objDAL.SelectSessionUsuario(Rut, Passwd, Email);
            if (objUSUARIO.RutUsuario != 0)
            {
                BFParamGen objBFParamGen = new BFParamGen();
            EParamGen objParamGen = objBFParamGen.GetParamGenAll(objUSUARIO.CodEmpresa)[0];
            objUSUARIO.EmailMesaAyuda = Utiles.ConvertToString(objParamGen.EmailMesaAyuda);
            objUSUARIO.VersionPlataforma = Utiles.ConvertToString(objParamGen.Version);
            objUSUARIO.ChatHabilitad = Utiles.ConvertToBoolean(objParamGen.ChatAbierto);
            objUSUARIO.DiasEsperaActividad = Utiles.ConvertToInt16(objParamGen.DiasEsperaActividad);
            objUSUARIO.SkinPlataforma = Utiles.ConvertToString(objParamGen.SkinPlataforma);
            objUSUARIO.MostrarMenuConf = Utiles.ConvertToBoolean(objParamGen.MostrarMenuConf);
            objUSUARIO.CursoAbierto = Utiles.ConvertToBoolean(objParamGen.CursoAbierto);
            objUSUARIO.MostrarMalla = Utiles.ConvertToBoolean(objParamGen.MostrarMalla);
            objUSUARIO.HoraZona = Utiles.ConvertToInt32(objParamGen.HoraZona);
            objUSUARIO.MostrarPuntos = Utiles.ConvertToBoolean(objParamGen.MostrarPuntos);
            objUSUARIO.MostrarPortal = Utiles.ConvertToBoolean(objParamGen.MostrarPortal);

            }

            return objUSUARIO;

        }

        public ESESSIONUSUARIO GetSESSIONUSUARIONONSECURE(long Rut)
        {
            ESESSIONUSUARIO objUSUARIO = _objDAL.SelectSessionUsuarioNonSecure(Rut);
            BFParamGen objBFParamGen = new BFParamGen();
            EParamGen objParamGen = objBFParamGen.GetParamGenAll(objUSUARIO.CodEmpresa)[0];
            objUSUARIO.EmailMesaAyuda = Utiles.ConvertToString(objParamGen.EmailMesaAyuda);
            objUSUARIO.VersionPlataforma = Utiles.ConvertToString(objParamGen.Version);
            objUSUARIO.ChatHabilitad = Utiles.ConvertToBoolean(objParamGen.ChatAbierto);
            objUSUARIO.DiasEsperaActividad = Utiles.ConvertToInt16(objParamGen.DiasEsperaActividad);
            objUSUARIO.SkinPlataforma = Utiles.ConvertToString(objParamGen.SkinPlataforma);
            objUSUARIO.MostrarMenuConf = Utiles.ConvertToBoolean(objParamGen.MostrarMenuConf);
            objUSUARIO.CursoAbierto = Utiles.ConvertToBoolean(objParamGen.CursoAbierto);
            objUSUARIO.MostrarMalla = Utiles.ConvertToBoolean(objParamGen.MostrarMalla);
            objUSUARIO.HoraZona = Utiles.ConvertToInt32(objParamGen.HoraZona);
            objUSUARIO.MostrarPuntos = Utiles.ConvertToBoolean(objParamGen.MostrarPuntos);
            objUSUARIO.MostrarPortal = Utiles.ConvertToBoolean(objParamGen.MostrarPortal);

            return objUSUARIO;
        }

        public ESESSIONUSUARIO GetSESSIONUSUARIONONSECURE(String Email)
        {
            ESESSIONUSUARIO objUSUARIO = _objDAL.SelectSessionUsuarioNonSecure(Email);
            BFParamGen objBFParamGen = new BFParamGen();
            EParamGen objParamGen = objBFParamGen.GetParamGenAll(objUSUARIO.CodEmpresa)[0];
            objUSUARIO.EmailMesaAyuda = Utiles.ConvertToString(objParamGen.EmailMesaAyuda);
            objUSUARIO.VersionPlataforma = Utiles.ConvertToString(objParamGen.Version);
            objUSUARIO.ChatHabilitad = Utiles.ConvertToBoolean(objParamGen.ChatAbierto);
            objUSUARIO.DiasEsperaActividad = Utiles.ConvertToInt16(objParamGen.DiasEsperaActividad);
            objUSUARIO.SkinPlataforma = Utiles.ConvertToString(objParamGen.SkinPlataforma);
            objUSUARIO.MostrarMenuConf = Utiles.ConvertToBoolean(objParamGen.MostrarMenuConf);
            objUSUARIO.CursoAbierto = Utiles.ConvertToBoolean(objParamGen.CursoAbierto);
            objUSUARIO.MostrarMalla = Utiles.ConvertToBoolean(objParamGen.MostrarMalla);
            objUSUARIO.HoraZona = Utiles.ConvertToInt32(objParamGen.HoraZona);
            objUSUARIO.MostrarPuntos = Utiles.ConvertToBoolean(objParamGen.MostrarPuntos);
            objUSUARIO.MostrarPortal = Utiles.ConvertToBoolean(objParamGen.MostrarPortal);

            return objUSUARIO;
        }

        public ESESSIONUSUARIO GetSESSIONUSUARIONONEMPSECURE(string NombreEmpresa)
        {
            ESESSIONUSUARIO objUSUARIO = _objDAL.SelectSessionUsuarioNonEmpSecure(NombreEmpresa);
            if(objUSUARIO.RutUsuario>0)
            {
                BFParamGen objBFParamGen = new BFParamGen();
                EParamGen objParamGen = objBFParamGen.GetParamGenAll(objUSUARIO.CodEmpresa)[0];
                objUSUARIO.EmailMesaAyuda = Utiles.ConvertToString(objParamGen.EmailMesaAyuda);
                objUSUARIO.VersionPlataforma = Utiles.ConvertToString(objParamGen.Version);
                objUSUARIO.ChatHabilitad = Utiles.ConvertToBoolean(objParamGen.ChatAbierto);
                objUSUARIO.DiasEsperaActividad = Utiles.ConvertToInt16(objParamGen.DiasEsperaActividad);
                objUSUARIO.SkinPlataforma = Utiles.ConvertToString(objParamGen.SkinPlataforma);
                objUSUARIO.MostrarMenuConf = Utiles.ConvertToBoolean(objParamGen.MostrarMenuConf);
                objUSUARIO.MostrarCambioPass = Utiles.ConvertToBoolean(objParamGen.MostrarCambioPass);
                objUSUARIO.TipoLogin = Utiles.ConvertToInt32(objParamGen.TipoLogin);
            }
            

            return objUSUARIO;
        }
		
		public DataTable UsuarioConDNI(string dni)
        {
            return _objDAL.SelectUsuariosPorDNI(dni);
        }

        public Boolean TieneCatalogo(long rut)
        {
            return _objDAL.SelectTieneCatalogo(rut);
        }

    }
}

