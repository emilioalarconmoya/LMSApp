using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATENEUS.CLASES.DAO;
using ATENEUS.COMMON;
using ATENEUS.DATAACCESS;
using System.Data;

namespace ATENEUS.CLASES.DAL
{
    public class DLEMPRESA : DLBase
    {
        public DLEMPRESA()
        {
        }
        protected override string GetDeleteProcedure()
        {
            return "proc_delete_EMPRESA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_EMPRESA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_EMPRESA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_EMPRESA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EUSUARIO objUSUARIO = obj as EUSUARIO;

            prms[0] = db.GetParameter();
            prms[0].Value = objUSUARIO.RutUsuario;
            prms[0].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(13);
            EUSUARIO objUSUARIO = obj as EUSUARIO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objUSUARIO.RutUsuario;
            prms[0].ParameterName = "@RUT_USUARIO";

            prms[1] = db.GetParameter();
            prms[1].Value = objUSUARIO.Nombres;
            prms[1].ParameterName = "@nombres";

            prms[2] = db.GetParameter();
            prms[2].Value = objUSUARIO.Apellidos;
            prms[2].ParameterName = "@apellidos";

            prms[3] = db.GetParameter();
            prms[3].Value = objUSUARIO.PasswdEnc;
            prms[3].ParameterName = "@passwd_enc";

            prms[4] = db.GetParameter();
            prms[4].Value = objUSUARIO.Email;
            prms[4].ParameterName = "@email";

            prms[5] = db.GetParameter();
            prms[5].Value = objUSUARIO.FechaCaducidad;
            prms[5].ParameterName = "@Fecha_caducidad";

            prms[6] = db.GetParameter();
            prms[6].Value = objUSUARIO.FechaCreacion;
            prms[6].ParameterName = "@Fecha_Creacion";

            prms[7] = db.GetParameter();
            prms[7].Value = objUSUARIO.Bloqueado;
            prms[7].ParameterName = "@Bloqueado";

            prms[8] = db.GetParameter();
            prms[8].Value = objUSUARIO.ClaveSence;
            prms[8].ParameterName = "@clave_sence";

            prms[9] = db.GetParameter();
            prms[9].Value = objUSUARIO.Profesion;
            prms[9].ParameterName = "@profesion";

            prms[10] = db.GetParameter();
            prms[10].Value = objUSUARIO.Direccion;
            prms[10].ParameterName = "@direccion";

            prms[11] = db.GetParameter();
            prms[11].Value = objUSUARIO.Comuna;
            prms[11].ParameterName = "@comuna";

            prms[12] = db.GetParameter();
            prms[12].Value = objUSUARIO.CodEmpresa;
            prms[12].ParameterName = "@cod_empresa";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(13);
            EUSUARIO objUSUARIO = obj as EUSUARIO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objUSUARIO.RutUsuario;
            prms[0].ParameterName = "@rut_usuario";

            prms[1] = db.GetParameter();
            prms[1].Value = objUSUARIO.Nombres;
            prms[1].ParameterName = "@nombres";

            prms[2] = db.GetParameter();
            prms[2].Value = objUSUARIO.Apellidos;
            prms[2].ParameterName = "@apellidos";

            prms[3] = db.GetParameter();
            prms[3].Value = objUSUARIO.PasswdEnc;
            prms[3].ParameterName = "@passwd_enc";

            prms[4] = db.GetParameter();
            prms[4].Value = objUSUARIO.Email;
            prms[4].ParameterName = "@email";

            prms[5] = db.GetParameter();
            prms[5].Value = objUSUARIO.FechaCaducidad;
            prms[5].ParameterName = "@Fecha_caducidad";

            prms[6] = db.GetParameter();
            prms[6].Value = objUSUARIO.FechaCreacion;
            prms[6].ParameterName = "@Fecha_Creacion";

            prms[7] = db.GetParameter();
            prms[7].Value = objUSUARIO.Bloqueado;
            prms[7].ParameterName = "@Bloqueado";

            prms[8] = db.GetParameter();
            prms[8].Value = objUSUARIO.ClaveSence;
            prms[8].ParameterName = "@clave_sence";

            prms[9] = db.GetParameter();
            prms[9].Value = objUSUARIO.Profesion;
            prms[9].ParameterName = "@profesion";

            prms[10] = db.GetParameter();
            prms[10].Value = objUSUARIO.Direccion;
            prms[10].ParameterName = "@direccion";

            prms[11] = db.GetParameter();
            prms[11].Value = objUSUARIO.Comuna;
            prms[11].ParameterName = "@comuna";

            prms[12] = db.GetParameter();
            prms[12].Value = objUSUARIO.CodEmpresa;
            prms[12].ParameterName = "@cod_empresa";

            return prms;
        }
        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EEMPRESA objRoot = obj as EEMPRESA;

            objRoot.CodEmpresa = id;
        }



 

        public override void Fill(DomainObject obj, IDataReader dr)
        {
            try
            {
                EEMPRESA objEMPRESA = obj as EEMPRESA;

                //Poner las rutinas del Tools que se necesiten

                objEMPRESA.CodEmpresa = Utiles.ConvertToInt64(dr["COD_EMPRESA"]);

                objEMPRESA.RutEmpresa = Utiles.ConvertToInt64(dr["RUT_EMPRESA"]);
                
                objEMPRESA.NombreFantasia = Utiles.ConvertToString(dr["NOMBRE_FANTASIA"]);
                
                objEMPRESA.RazonSocial = Utiles.ConvertToString(dr["RAZON_SOCIAL"]);
                
                objEMPRESA.NombreContacto = Utiles.ConvertToString(dr["NOMBRE_CONTACTO"]);
                
                objEMPRESA.EmpresaEmail = Utiles.ConvertToString(dr["EMPRESA_EMAIL"]);
                
                objEMPRESA.EmailContacto = Utiles.ConvertToString(dr["EMAIL_CONTACTO"]);
                
                objEMPRESA.Vigente = Utiles.ConvertToBoolean(dr["VIGENTE"]);
                
                objEMPRESA.EspacioDisco = Utiles.ConvertToInt64(dr["ESPACIO_DISCO_MB"]);

            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}