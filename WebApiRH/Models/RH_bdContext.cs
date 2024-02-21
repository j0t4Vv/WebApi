using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiRH.Models
{
    public partial class RH_bdContext : DbContext
    {
        public RH_bdContext()
        {
        }

        public RH_bdContext(DbContextOptions<RH_bdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Beneficio> Beneficios { get; set; } = null!;
        public virtual DbSet<Cargo> Cargos { get; set; } = null!;
        public virtual DbSet<Departamento> Departamentos { get; set; } = null!;
        public virtual DbSet<Funcionario> Funcionarios { get; set; } = null!;
        public virtual DbSet<Gerente> Gerentes { get; set; } = null!;
        public virtual DbSet<Historico> Historicos { get; set; } = null!;
        public virtual DbSet<Salario> Salarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=PC03LAB2537\\SENAI; Initial Catalog=RH_bd; User Id=sa; Password=senai.123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beneficio>(entity =>
            {
                entity.HasKey(e => e.IdBeneficio)
                    .HasName("PK__Benefici__E83C0831A02EC072");

                entity.Property(e => e.IdBeneficio).HasColumnName("id_beneficio");

                entity.Property(e => e.Custo)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("custo");

                entity.Property(e => e.IdFuncionario).HasColumnName("id_funcionario");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.Beneficios)
                    .HasForeignKey(d => d.IdFuncionario)
                    .HasConstraintName("FK__Beneficio__id_fu__46E78A0C");
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.IdCargo)
                    .HasName("PK__Cargos__D3C09EC5B6516269");

                entity.Property(e => e.IdCargo).HasColumnName("id_cargo");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento)
                    .HasName("PK__Departam__64F37A1655E6BCBC");

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.Property(e => e.IdGerente).HasColumnName("id_gerente");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.HasOne(d => d.IdGerenteNavigation)
                    .WithMany(p => p.Departamentos)
                    .HasForeignKey(d => d.IdGerente)
                    .HasConstraintName("FK__Departame__id_ge__3C69FB99");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.IdFuncionario)
                    .HasName("PK__Funciona__6FBD69C4D5A87E26");

                entity.Property(e => e.IdFuncionario).HasColumnName("id_funcionario");

                entity.Property(e => e.DataContratacao)
                    .HasColumnType("date")
                    .HasColumnName("data_contratacao");

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("date")
                    .HasColumnName("data_nascimento");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Endereco)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.IdCargo).HasColumnName("id_cargo");

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.Property(e => e.IdGerente).HasColumnName("id_gerente");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Sobrenome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sobrenome");

                entity.Property(e => e.Telefone).HasColumnName("telefone");

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.IdCargo)
                    .HasConstraintName("FK__Funcionar__id_ca__38996AB5");

                entity.HasOne(d => d.IdGerenteNavigation)
                    .WithMany(p => p.InverseIdGerenteNavigation)
                    .HasForeignKey(d => d.IdGerente)
                    .HasConstraintName("FK__Funcionar__id_ge__398D8EEE");
            });

            modelBuilder.Entity<Gerente>(entity =>
            {
                entity.HasKey(e => e.IdGerente)
                    .HasName("PK__Gerentes__0A301510F1DD62CD");

                entity.Property(e => e.IdGerente).HasColumnName("id_gerente");

                entity.Property(e => e.IdCargo).HasColumnName("id_cargo");

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Sobrenome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sobrenome");

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.Gerentes)
                    .HasForeignKey(d => d.IdCargo)
                    .HasConstraintName("FK__Gerentes__id_car__3F466844");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Gerentes)
                    .HasForeignKey(d => d.IdDepartamento)
                    .HasConstraintName("FK__Gerentes__id_dep__403A8C7D");
            });

            modelBuilder.Entity<Historico>(entity =>
            {
                entity.HasKey(e => e.IdHistorico)
                    .HasName("PK__Historic__76E62AC3C8F26627");

                entity.Property(e => e.IdHistorico).HasColumnName("id_historico");

                entity.Property(e => e.DataInicio)
                    .HasColumnType("date")
                    .HasColumnName("data_inicio");

                entity.Property(e => e.DataTermino)
                    .HasColumnType("date")
                    .HasColumnName("data_termino");

                entity.Property(e => e.IdCargo).HasColumnName("id_cargo");

                entity.Property(e => e.IdFuncionario).HasColumnName("id_funcionario");

                entity.Property(e => e.MotivoSaida)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("motivo_saida");

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.Historicos)
                    .HasForeignKey(d => d.IdCargo)
                    .HasConstraintName("FK__Historico__id_ca__440B1D61");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.Historicos)
                    .HasForeignKey(d => d.IdFuncionario)
                    .HasConstraintName("FK__Historico__id_fu__4316F928");
            });

            modelBuilder.Entity<Salario>(entity =>
            {
                entity.HasKey(e => e.IdSalario)
                    .HasName("PK__Salarios__3F2037D48320F9B1");

                entity.Property(e => e.IdSalario).HasColumnName("id_salario");

                entity.Property(e => e.DataInicio)
                    .HasColumnType("date")
                    .HasColumnName("data_inicio");

                entity.Property(e => e.DataTermino)
                    .HasColumnType("date")
                    .HasColumnName("data_termino");

                entity.Property(e => e.IdFuncionario).HasColumnName("id_funcionario");

                entity.Property(e => e.Salario1)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("salario");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.Salarios)
                    .HasForeignKey(d => d.IdFuncionario)
                    .HasConstraintName("FK__Salarios__id_fun__49C3F6B7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
