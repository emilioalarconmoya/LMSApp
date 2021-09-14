namespace LMSApp.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Alternativa
    {
        [Key]
        public int CodAlternativa { get; set; }
        public int CodPregunta { get; set; }
        public String TextoAlternativa { get; set; }
        public bool EsCorrecta { get; set; }
        public string TextoComentario { get; set; }
        public int PuntajeMax { get; set; }
    }
}
