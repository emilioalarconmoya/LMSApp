
namespace LMSApp.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Usuario
    {

        [Key]
        public int RutUsuario { get; set; }
       
        public int CodEmpresa { get; set; }
       
        public string Nombres { get; set; }
       
        public string Apellidos { get; set; }
        
        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime FechaCaducidad { get; set; }

        public DateTime FechaCreacion { get; set; }
       
        public Boolean Bloqueado { get; set; }

        public string ClaveSence { get; set; }

        public string Profesion { get; set; }

        public string Direccion { get; set; }

        public string Comuna { get; set; }
       
        public string Dni { get; set; }

        public string Fono { get; set; }
    }

}
