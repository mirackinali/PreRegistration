using Microsoft.EntityFrameworkCore;

namespace KullaniciGiris.Models
{
    public class PreRegistrationDbContext : DbContext
    {
        public PreRegistrationDbContext(DbContextOptions<PreRegistrationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PreRegistration> PreRegistrations { get; set; } // Veritabanı tablosu
    }
}
