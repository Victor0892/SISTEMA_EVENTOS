using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SISTEMA_EVENTOS.MODEL.Models;

public partial class GerenciamentoEventosContext : DbContext
{
    public GerenciamentoEventosContext()
    {
    }

    public GerenciamentoEventosContext(DbContextOptions<GerenciamentoEventosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Inscricao> Inscricaos { get; set; }

    public virtual DbSet<Local> Locals { get; set; }

    public virtual DbSet<Organizador> Organizadors { get; set; }

    public virtual DbSet<Participante> Participantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-UL25EN3\\SQLEXPRESS;Database=GerenciamentoEventos;Trusted_Connection=True;trustservercertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Evento__3214EC27E4CB6DA2");

            entity.ToTable("Evento");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LocalId).HasColumnName("Local_ID");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OrganizadorId).HasColumnName("Organizador_ID");

            entity.HasOne(d => d.Local).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.LocalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Local_Evento");

            entity.HasOne(d => d.Organizador).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.OrganizadorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Organizador_Evento");
        });

        modelBuilder.Entity<Inscricao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inscrica__3214EC27A9DDE020");

            entity.ToTable("Inscricao");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DataInscricao).HasColumnName("Data_Inscricao");
            entity.Property(e => e.EventoId).HasColumnName("Evento_ID");
            entity.Property(e => e.ParticipanteId).HasColumnName("Participante_ID");

            entity.HasOne(d => d.Evento).WithMany(p => p.Inscricaos)
                .HasForeignKey(d => d.EventoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Evento_Inscricao");

            entity.HasOne(d => d.Participante).WithMany(p => p.Inscricaos)
                .HasForeignKey(d => d.ParticipanteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Participante_Inscricao");
        });

        modelBuilder.Entity<Local>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Local__3214EC277289D708");

            entity.ToTable("Local");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cidade)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Endereco)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Pais)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Organizador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Organiza__3214EC2723C0F619");

            entity.ToTable("Organizador");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Participante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Particip__3214EC27D9503B51");

            entity.ToTable("Participante");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
