namespace LMSApp.Backend.Models
{
    using LMSApp.Domain.Models;

    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<LMSApp.Common.Models.Usuario> Usuarios { get; set; }
    }
}