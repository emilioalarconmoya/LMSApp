namespace LMSApp.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class DatoUltimoLogConexion
    {
        [Key]
        public int TiempoRestanteSegundo { get; set; }
        public int PasoUltimaVisita { get; set; }
        public DateTime Inicio { get; set; }
        public bool FlagTerminada { get; set; }
        public bool Cerrada { get; set; }
    }
}
