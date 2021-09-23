namespace LMSApp.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Evaluacion
    {
        [Key]
        public int Codunidad { get; set; }
        public int CodPregunta { get; set; }
        public int CodActividadUsuario { get; set; }
        public DateTime FechaHora { get; set; }
        public string TextoRespuesta { get; set; }
        public int Puntaje { get; set; }
        public string Comentarios { get; set; }
        public bool EstaIncluida { get; set; }
        public int NumeroIntentos { get; set; }
        public bool AvisaTermino { get; set; }
        public int CodEmpresa { get; set; }

    }
}
