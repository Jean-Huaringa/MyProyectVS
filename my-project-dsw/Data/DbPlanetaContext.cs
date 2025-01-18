using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using my_project_dsw.Models;

namespace my_project_dsw.Data;

public partial class DbPlanetaContext : DbContext
{
    public DbPlanetaContext()
    {
    }

    public DbPlanetaContext(DbContextOptions<DbPlanetaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAsiento> TbAsientos { get; set; }

    public virtual DbSet<TbBu> TbBus { get; set; }

    public virtual DbSet<TbEstacion> TbEstacions { get; set; }

    public virtual DbSet<TbPago> TbPagos { get; set; }

    public virtual DbSet<TbRutum> TbRuta { get; set; }

    public virtual DbSet<TbTrabajador> TbTrabajadors { get; set; }

    public virtual DbSet<TbTransaccion> TbTransaccions { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAsiento>(entity =>
        {
            entity.HasKey(e => new { e.BusId, e.AtoColumna, e.AtoLetra }).HasName("PK__tb_asien__CF9A0B472B326420");

            entity.Property(e => e.AtoLetra).IsFixedLength();
            entity.Property(e => e.AtoEstado).HasDefaultValue(true);

            entity.HasOne(d => d.Bus).WithMany(p => p.TbAsientos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_asiento_bus");
        });

        modelBuilder.Entity<TbBu>(entity =>
        {
            entity.HasKey(e => e.BusId).HasName("PK__tb_bus__6ACEF8EDFAA418AE");

            entity.Property(e => e.BusEstado).HasDefaultValue(true);
        });

        modelBuilder.Entity<TbEstacion>(entity =>
        {
            entity.HasKey(e => e.StnId).HasName("PK__tb_estac__0344E3370561FA66");
        });

        modelBuilder.Entity<TbPago>(entity =>
        {
            entity.HasKey(e => e.PgoId).HasName("PK__tb_pago__FA21A8CEABEFF90E");

            entity.Property(e => e.PgoEstado).HasDefaultValue("proceso");
            entity.Property(e => e.PgoFecha).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Usr).WithMany(p => p.TbPagos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_pago_usuario");
        });

        modelBuilder.Entity<TbRutum>(entity =>
        {
            entity.HasKey(e => e.RtaId).HasName("PK__tb_ruta__021BAD7CB9D17E65");

            entity.Property(e => e.RtaEstado).HasDefaultValue(true);

            entity.HasOne(d => d.Bus).WithMany(p => p.TbRuta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_ruta_bus");

            entity.HasOne(d => d.Destino).WithMany(p => p.TbRutumDestinos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_ruta_destino");

            entity.HasOne(d => d.Origen).WithMany(p => p.TbRutumOrigens)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_ruta_origen");

            entity.HasOne(d => d.Tbj).WithMany(p => p.TbRuta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_ruta_trabajador");
        });

        modelBuilder.Entity<TbTrabajador>(entity =>
        {
            entity.HasKey(e => e.TbjId).HasName("PK__tb_traba__10F7DEC827C79A20");

            entity.Property(e => e.TbjId).ValueGeneratedNever();
            entity.Property(e => e.TbjEstado).HasDefaultValue(true);
            entity.Property(e => e.UsrFechaRegistro).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Tbj).WithOne(p => p.TbTrabajador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_trabajador_usuario");
        });

        modelBuilder.Entity<TbTransaccion>(entity =>
        {
            entity.HasKey(e => e.TrnId).HasName("PK__tb_trans__3E33D7DF5C1CF923");

            entity.Property(e => e.AtoLetra).IsFixedLength();

            entity.HasOne(d => d.Pgo).WithMany(p => p.TbTransaccions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_transaccion_pago");

            entity.HasOne(d => d.Rta).WithMany(p => p.TbTransaccions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_transaccion_ruta");

            entity.HasOne(d => d.TbAsiento).WithMany(p => p.TbTransaccions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_transaccion_asiento");
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.HasKey(e => e.UsrId).HasName("PK__tb_usuar__60621ABCB88FBBBC");

            entity.Property(e => e.UsrFechaRegistro).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UsrState).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
