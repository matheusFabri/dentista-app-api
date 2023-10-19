namespace DentistaApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuario {get; set;}
    }
}