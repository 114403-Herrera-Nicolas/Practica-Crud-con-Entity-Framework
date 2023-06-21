using System;
using System.Collections.Generic;
using ClubNautico.Models;
using Microsoft.EntityFrameworkCore;


namespace ClubNautico.Data;

public partial class ClubNauticoContext : DbContext
{
    public ClubNauticoContext()
    {
    }

    public ClubNauticoContext(DbContextOptions<ClubNauticoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Barco> Barcos { get; set; }

    public virtual DbSet<Socio> Socios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Barco>(entity =>
        {
            entity.HasKey(e => e.IdSocio).HasName("barcos_pkey");

            entity.ToTable("barcos");

            entity.Property(e => e.IdSocio)
                .ValueGeneratedNever()
                .HasColumnName("id_socio");
            entity.Property(e => e.Cuota).HasColumnName("cuota");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasColumnType("character varying")
                .HasColumnName("nombre");
            entity.Property(e => e.NumAmarre).HasColumnName("num_amarre");
            entity.Property(e => e.NumMatricula).HasColumnName("num_matricula");

            entity.HasOne(d => d.IdSocioNavigation).WithOne(p => p.Barco)
                .HasForeignKey<Barco>(d => d.IdSocio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_socio_barco");
        });

        modelBuilder.Entity<Socio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("socios_pkey");

            entity.ToTable("socios");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .HasColumnName("apellido");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
