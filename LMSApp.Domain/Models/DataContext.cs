namespace LMSApp.Domain.Models
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
    }
}
