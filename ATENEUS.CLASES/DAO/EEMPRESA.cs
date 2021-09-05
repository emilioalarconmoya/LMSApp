using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATENEUS.CLASES.DAL;
using ATENEUS.COMMON;
namespace ATENEUS.CLASES.DAO
{
    public class EEMPRESA : DomainObject
    {
        private System.String _rut_completo = String.Empty;

        private System.Int64 _cod_empresa = 0;

        private System.Int64 _rut_empresa = 0;

        private System.String _nombre_fantasia = String.Empty;

        private System.String _razon_social = String.Empty;

        private System.String _nombre_contacto = String.Empty;

        private System.String _empresa_email = String.Empty;

        private System.String _email_contacto = String.Empty;

        private System.Boolean _vigente = false;      

        private System.Int64 _espacio_disco = 0;

        private System.String _host = String.Empty;

        private System.Int64 _port = 0;

        private System.String _user = String.Empty;

        private System.String _pass = String.Empty;


        public EEMPRESA() : base()
        {
        }
        public EEMPRESA(Int64 CodEmpresa) : base(CodEmpresa)
        {
        }

        public System.String Host
        {
            get { return _host; }
            set { _host = value; }
        }
        public System.Int64 Port
        {
            get { return _port; }
            set { _port = value; }
        }
        public System.String User
        {
            get { return _user; }
            set { _user = value; }
        }
        public System.String Pass
        {
            get { return _pass; }
            set { _pass = value; }
        }


        public System.Int64 CodEmpresa
        {
            get { return _cod_empresa; }
            set { _cod_empresa = value; }
        }
        public System.String RutCompleto
        {
            get { return Utiles.RutLngAUsr(_rut_empresa); }
            set { _rut_completo = value; }
        }
        public System.Int64 RutEmpresa
        {
            get { return _rut_empresa; }
            set { _rut_empresa = value; }
        }

        public System.String NombreFantasia
        {
            get { return _nombre_fantasia; }
            set { _nombre_fantasia = value; }
        }

        public System.String RazonSocial
        {
            get { return _razon_social; }
            set { _razon_social = value; }
        }

        public System.String NombreContacto
        {
            get { return _nombre_contacto; }
            set { _nombre_contacto = value; }
        }

        public System.String EmpresaEmail
        {
            get { return _empresa_email; }
            set { _empresa_email = value; }
        }

        public System.String EmailContacto
        {
            get { return _email_contacto; }
            set { _email_contacto = value; }
        }

        public System.Boolean Vigente
        {
            get { return _vigente; }
            set { _vigente = value; }
        }

        public System.Int64 EspacioDisco
        {
            get { return _espacio_disco; }
            set { _espacio_disco = value; }
        }

        protected override DLBase GetMapper()
        {
            return new DLUSUARIO();
        }
    }
}
