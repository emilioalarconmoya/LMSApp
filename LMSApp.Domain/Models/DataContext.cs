﻿namespace LMSApp.Domain.Models
{
    using System.Data.Entity;
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<LMSApp.Common.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<LMSApp.Common.Models.ActividadVigente> ActividadVigentes { get; set; }

        public System.Data.Entity.DbSet<LMSApp.Common.Models.HistorialAlumno> HistorialAlumnoes { get; set; }

        public System.Data.Entity.DbSet<LMSApp.Common.UnidadesActividad> UnidadesActividads { get; set; }

        public System.Data.Entity.DbSet<LMSApp.Common.Models.Pregunta> Preguntas { get; set; }

        public System.Data.Entity.DbSet<LMSApp.Common.Models.PreguntaUnidad> PreguntaUnidads { get; set; }

        public System.Data.Entity.DbSet<LMSApp.Common.Models.Alternativa> Alternativas { get; set; }

        public System.Data.Entity.DbSet<LMSApp.Common.Models.RespuestaCorrecta> RespuestaCorrectas { get; set; }

        public System.Data.Entity.DbSet<LMSApp.Common.Models.Evaluacion> Evaluacions { get; set; }
    }
}
