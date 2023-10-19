﻿// <auto-generated />
using System;
using DentistaApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DentistaApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("DentistaApi.Models.Consulta", b =>
                {
                    b.Property<string>("ConsultaId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClienteId")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("DataConsulta")
                        .HasColumnType("TEXT");

                    b.Property<string>("DentistaId")
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("HoraConsulta")
                        .HasColumnType("TEXT");

                    b.Property<string>("PagamentoId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProcedimentoConsulta")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("TempoPrevisto")
                        .HasColumnType("TEXT");

                    b.HasKey("ConsultaId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("DentistaId");

                    b.HasIndex("PagamentoId");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("DentistaApi.Models.Especialidade", b =>
                {
                    b.Property<string>("EspecialidadeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("ValorBase")
                        .HasColumnType("REAL");

                    b.HasKey("EspecialidadeId");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("DentistaApi.Models.Pagamento", b =>
                {
                    b.Property<string>("PagamentoId")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("DataDoPagamento")
                        .HasColumnType("TEXT");

                    b.Property<string>("FormaDePagamento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Pago")
                        .HasColumnType("INTEGER");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("REAL");

                    b.HasKey("PagamentoId");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("DentistaApi.Models.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DentistaApi.Models.Dentista", b =>
                {
                    b.HasBaseType("DentistaApi.Models.Usuario");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("EspecialidadeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasIndex("EspecialidadeId");

                    b.HasDiscriminator().HasValue("Dentista");
                });

            modelBuilder.Entity("DentistaApi.Models.Consulta", b =>
                {
                    b.HasOne("DentistaApi.Models.Usuario", "Cliente")
                        .WithMany("Consultas")
                        .HasForeignKey("ClienteId");

                    b.HasOne("DentistaApi.Models.Dentista", "Dentista")
                        .WithMany()
                        .HasForeignKey("DentistaId");

                    b.HasOne("DentistaApi.Models.Pagamento", "Pagamento")
                        .WithMany()
                        .HasForeignKey("PagamentoId");

                    b.Navigation("Cliente");

                    b.Navigation("Dentista");

                    b.Navigation("Pagamento");
                });

            modelBuilder.Entity("DentistaApi.Models.Dentista", b =>
                {
                    b.HasOne("DentistaApi.Models.Especialidade", "Especialidade")
                        .WithMany()
                        .HasForeignKey("EspecialidadeId");

                    b.Navigation("Especialidade");
                });

            modelBuilder.Entity("DentistaApi.Models.Usuario", b =>
                {
                    b.Navigation("Consultas");
                });
#pragma warning restore 612, 618
        }
    }
}
