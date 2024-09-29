using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace peryautWebApi.Models;

public partial class PersonasyautosContext : DbContext
{
    public PersonasyautosContext()
    {
    }

    public PersonasyautosContext(DbContextOptions<PersonasyautosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auto> Autos { get; set; }

    public virtual DbSet<DueniosConAuto> DueniosConAutos { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=peyauDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auto>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Año).HasMaxLength(4);
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.IdMarca).HasColumnName("Id_Marca");
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Autos)
                .HasForeignKey(d => d.IdMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Autos_Marcas");
        });

        modelBuilder.Entity<DueniosConAuto>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.IdAuto).HasColumnName("Id_Auto");
            entity.Property(e => e.IdDuenio).HasColumnName("Id_Duenio");

            entity.HasOne(d => d.IdAutoNavigation).WithMany(p => p.DueniosConAutos)
                .HasForeignKey(d => d.IdAuto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DueniosConAutos_Autos");

            entity.HasOne(d => d.IdDuenioNavigation).WithMany(p => p.DueniosConAutos)
                .HasForeignKey(d => d.IdDuenio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DueniosConAutos_Personas");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Marca1)
                .HasMaxLength(100)
                .HasColumnName("Marca");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Pais).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
