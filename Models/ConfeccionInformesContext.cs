using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConfeccionInformesMVC.Models;

public partial class ConfeccionInformesContext : DbContext
{
    public ConfeccionInformesContext()
    {
    }

    public ConfeccionInformesContext(DbContextOptions<ConfeccionInformesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Alumno__3214EC07F8B38EA6");

            entity.ToTable("Alumno");

            entity.HasIndex(e => e.Email, "UQ__Alumno__A9D1053442BC79FB").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Matricula).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.Sexo).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
