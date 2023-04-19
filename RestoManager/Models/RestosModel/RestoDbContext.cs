using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;

namespace RestoManager.Models.RestosModel
{
    public class RestoDbContext : DbContext
    {
        public RestoDbContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Proprietaire> PropBuilder=modelBuilder.Entity<Proprietaire>();
            PropBuilder.ToTable("TPropritaire","resto");
            PropBuilder.HasKey(p=>p.Numero);
            PropBuilder.Property(p => p.Name)
                .HasColumnName("NomProp")
                .HasMaxLength(20)
                .IsRequired();
            PropBuilder.Property(p => p.Email)
                .HasColumnName("EmailProp")
                .HasMaxLength(50)
                .IsRequired();
            PropBuilder.Property(p => p.Gsm)
                .HasColumnName("GsmProp")
                .HasMaxLength(8)
                .IsRequired();


            EntityTypeBuilder<Restaurant> ResBuilder=modelBuilder.Entity<Restaurant>();
            ResBuilder.ToTable("TRestaurant", "resto");
            ResBuilder.HasKey(r => r.CodeResto);
            ResBuilder.Property(r => r.NomRest)
                .HasColumnName("NomResto")
                .HasMaxLength(20)
                .IsRequired();
            ResBuilder.Property(r => r.Specialite)
                .HasColumnName("SpecResto")
                .HasMaxLength(20)
                .IsRequired()
                .HasDefaultValue("Tunisienne");
            ResBuilder.Property(r => r.Ville)
               .HasColumnName("VilleResto")
               .HasMaxLength(20)
               .IsRequired();
            ResBuilder.Property(r=>r.Tel)
                .HasColumnName("TelResto")
                .HasMaxLength(8)
                .IsRequired();


            PropBuilder.HasMany(p => p.LesResto)
                .WithOne(r => r.LeProprio)
                .HasForeignKey(r => r.NumProp)
                .HasConstraintName("Relation_Proprio_Restos")
                .IsRequired();

            EntityTypeBuilder<Avis> ABuilder = modelBuilder.Entity<Avis>();

            ABuilder.ToTable("TAvis", "admin");
            ABuilder.HasKey(a => a.CodeAvis);
            ABuilder.Property(a=> a.NomPresonne)
               .HasMaxLength(30)
               .IsRequired();
            ABuilder.Property(a => a.Note)
               
               .IsRequired();

            ABuilder.Property(a => a.Commentaire)
               .HasMaxLength(256);

            ResBuilder.HasMany(a=>a.LesAvis)
                .WithOne(r=>r.LeResto)
                .HasForeignKey(a=>a.NumResto)
                .HasConstraintName("Relation_Resto_Avis")
                .IsRequired();  
               









        }
        public DbSet<Restaurant> Restaurants { get; set;}

        public DbSet<Proprietaire> Proprietaires { get;set;}

        public DbSet<Avis> Avis { get; set;}    
    }
}
