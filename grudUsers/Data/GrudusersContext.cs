using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using grudUsers.Models;

namespace grudUsers.Data;

public partial class GrudusersContext : DbContext
{
    public GrudusersContext()
    {
    }

    public GrudusersContext(DbContextOptions<GrudusersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=carlosmay;Database=grudusers;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__usuarios__3717C982FF94A9DC");

            entity.ToTable("usuarios");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
