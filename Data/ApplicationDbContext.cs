using KullaniciGiris.Models;
using Microsoft.EntityFrameworkCore;

namespace KullaniciGiris.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) // Bu, DbContextOptions'ı sınıfın yapıcısına iletir.
        {

        }

        public DbSet<PreRegistration> PreRegistrations { get; set; }

        // Yeni eklenen DbSet özelliği
        public DbSet<Lokasyon> Lokasyonlar { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Kendine referans foreign key yapılandırması (Fluent API ile)
            builder.Entity<Lokasyon>()
                .HasOne(l => l.UstLokasyon)
                .WithMany(l => l.AltLokasyonlar)
                .HasForeignKey(l => l.UstID)
                .OnDelete(DeleteBehavior.Restrict); // Silme davranışını ayarlayabilirsiniz
        }
    }
}