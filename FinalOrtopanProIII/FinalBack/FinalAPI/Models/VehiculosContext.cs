using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FinalAPI.Models
{
    public partial class VehiculosContext : DbContext
    {
        public VehiculosContext()
        {
        }

        public VehiculosContext(DbContextOptions<VehiculosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Tipo> Tipos { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseNpgsql("User ID=finalProg3; Password=finalProg3-2; Server=138.99.7.66; Port=5432; Database=Vehiculos; Integrated Security=true; Pooling=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.ToTable("marcas");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Marca1)
                    .IsRequired()
                    .HasColumnName("Marca");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.ToTable("tipos");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Nombre).IsRequired();
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.ToTable("vehiculos");

                entity.HasIndex(e => e.IdMarca, "fki_fk_marca");

                entity.HasIndex(e => e.IdTipo, "fki_fk_tipo");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Color).IsRequired();

                entity.Property(e => e.Modelo).IsRequired();

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("fk_marca");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tipo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
