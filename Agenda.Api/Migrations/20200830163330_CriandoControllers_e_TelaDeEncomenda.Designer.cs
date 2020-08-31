﻿// <auto-generated />
using System;
using Agenda;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Agenda.Migrations
{
    [DbContext(typeof(AgendaDbContext))]
    [Migration("20200830163330_CriandoControllers_e_TelaDeEncomenda")]
    partial class CriandoControllers_e_TelaDeEncomenda
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Agenda.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Celular")
                        .HasColumnType("int")
                        .HasMaxLength(13);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("Telefone")
                        .HasColumnType("int")
                        .HasMaxLength(12);

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Agenda.Models.Doce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdTpDoce")
                        .HasColumnType("int");

                    b.Property<double>("Preco")
                        .HasColumnType("float")
                        .HasMaxLength(10);

                    b.Property<string>("Sabor")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("TpDoceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TpDoceId");

                    b.ToTable("Doces");
                });

            modelBuilder.Entity("Agenda.Models.Encomenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int?>("DoceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Entrega")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdDoce")
                        .HasColumnType("int");

                    b.Property<double>("Preco")
                        .HasColumnType("float")
                        .HasMaxLength(10);

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("DoceId");

                    b.ToTable("Encomendas");
                });

            modelBuilder.Entity("Agenda.Models.TpDoce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeProduto")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("TpDoces");
                });

            modelBuilder.Entity("Agenda.Models.Doce", b =>
                {
                    b.HasOne("Agenda.Models.TpDoce", "TpDoce")
                        .WithMany()
                        .HasForeignKey("TpDoceId");
                });

            modelBuilder.Entity("Agenda.Models.Encomenda", b =>
                {
                    b.HasOne("Agenda.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("Agenda.Models.Doce", "Doce")
                        .WithMany()
                        .HasForeignKey("DoceId");
                });
#pragma warning restore 612, 618
        }
    }
}