namespace LMSApp.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Pregunta
    {
        [Key]
        public int CodPregunta { get; set; }
        public int CodTipoPregunta { get; set; }
        public string Texto { get; set; }
        public int CodCorrecta { get; set; }
        public List<Alternativa> Alternativa { get; set; }

        
    }
}
