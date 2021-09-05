using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;


namespace ATENEUS.COMMON
{
    public class Mail
    {
        private string[] _destinatarios;
        private string[] _destinatariosCopia;
        private string _asunto = String.Empty;
        private string _cuerpo = String.Empty;
        private Boolean _bodyHtml = false;
        private string _mailSalida = ConfigurationManager.AppSettings["UsuarioCorreo"];
        private string _passMailSalida = ConfigurationManager.AppSettings["PassCorreo"];
        private string _host = ConfigurationManager.AppSettings["host"]; 

        public string[] Destinatarios
        {
            get { return _destinatarios; }
            set { _destinatarios = value; }
        }

        public string[] DestinatariosCopia
        {
            get { return _destinatariosCopia; }
            set { _destinatariosCopia = value; }
        }

        public string Asunto
        {
            get { return _asunto; }
            set { _asunto = value; }
        }

        public string Cuerpo
        {
            get { return _cuerpo; }
            set { _cuerpo = value; }
        }

        public Boolean BodyHtml
        {
            get { return _bodyHtml; }
            set { _bodyHtml = value; }
        }


        public void EnviarCorreo()
        {
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            for (int i = 0; i <= _destinatarios.Length - 1; i++ )
            {
                mmsg.To.Add(_destinatarios[i]);
            }
                

            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = _asunto;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            if (!(_destinatariosCopia == null))
            {
                for (int i = 0; i <= _destinatariosCopia.Length - 1; i++)
                {
                    mmsg.Bcc.Add(_destinatariosCopia[i]); //Opcional
                }
            }
            

            //Cuerpo del Mensaje
            mmsg.Body = _cuerpo;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = _bodyHtml; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            EncryptionSoleduc.EncryptionSoleduc objEncrip = new EncryptionSoleduc.EncryptionSoleduc();
            mmsg.From = new System.Net.Mail.MailAddress(objEncrip.DecryptINI(_mailSalida));


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential(objEncrip.DecryptINI(_mailSalida), objEncrip.DecryptINI(_passMailSalida));

            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
            cliente.Port = 587;
            cliente.EnableSsl = false;
            cliente.Host = _host;  // "smtp.gmail.com"; //"mail.servidordominio.com";


            /*-------------------------ENVIO DE CORREO----------------------*/

            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
            }
        }
    }
}
