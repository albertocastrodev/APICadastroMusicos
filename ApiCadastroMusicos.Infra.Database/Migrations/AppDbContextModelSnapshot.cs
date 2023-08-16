﻿// <auto-generated />
using System;
using ApiCadastroMusico.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiCadastroMusicos.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApiCadastroMusico.Entites.DadosMusicais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("LeituraDeCifra")
                        .HasColumnType("bit");

                    b.Property<bool>("LeituraDePartitura")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("DadosMusicais");
                });

            modelBuilder.Entity("ApiCadastroMusico.Entites.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("ApiCadastroMusico.Entites.GrupoMusical", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DadosMusicaisId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantidadeIntegrantes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DadosMusicaisId");

                    b.ToTable("GrupoMusicais");
                });

            modelBuilder.Entity("ApiCadastroMusico.Entites.Instrumento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DadosMusicaisId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoInstrumentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DadosMusicaisId");

                    b.HasIndex("TipoInstrumentoId");

                    b.ToTable("Instrumentos");
                });

            modelBuilder.Entity("ApiCadastroMusico.Entites.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DadosMusicaisId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int>("EnderecoId1")
                        .HasColumnType("int");

                    b.Property<string>("Idade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SobreNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DadosMusicaisId");

                    b.HasIndex("EnderecoId1");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("ApiCadastroMusico.Entites.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DDD")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("ApiCadastroMusico.Entites.TipoInstrumento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoDeInstrumentos");
                });

            modelBuilder.Entity("ApiCadastroMusico.Entites.GrupoMusical", b =>
                {
                    b.HasOne("ApiCadastroMusico.Entites.DadosMusicais", "DadosMusicais")
                        .WithMany("GrupoMusicais")
                        .HasForeignKey("DadosMusicaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DadosMusicais");
                });

            modelBuilder.Entity("ApiCadastroMusico.Entites.Instrumento", b =>
                {
                    b.HasOne("ApiCadastroMusico.Entites.DadosMusicais", "DadosMusicais")
                        .WithMany("Instrumentos")
                        .HasForeignKey("DadosMusicaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiCadastroMusico.Entites.TipoInstrumento", "TipoInstrumento")
                        .WithMany()
                        .HasForeignKey("TipoInstrumentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DadosMusicais");

                    b.Navigation("TipoInstrumento");
                });

            modelBuilder.Entity("ApiCadastroMusico.Entites.Pessoa", b =>
                {
                    b.HasOne("ApiCadastroMusico.Entites.DadosMusicais", "DadosMusicais")
                        .WithMany()
                        .HasForeignKey("DadosMusicaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiCadastroMusico.Entites.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DadosMusicais");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("ApiCadastroMusico.Entites.Telefone", b =>
                {
                    b.HasOne("ApiCadastroMusico.Entites.Pessoa", "Pessoa")
                        .WithMany("Telefones")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("ApiCadastroMusico.Entites.DadosMusicais", b =>
                {
                    b.Navigation("GrupoMusicais");

                    b.Navigation("Instrumentos");
                });

            modelBuilder.Entity("ApiCadastroMusico.Entites.Pessoa", b =>
                {
                    b.Navigation("Telefones");
                });
#pragma warning restore 612, 618
        }
    }
}
