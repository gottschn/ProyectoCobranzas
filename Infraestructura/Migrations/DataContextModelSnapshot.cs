﻿// <auto-generated />
using System;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructura.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dominio.Entidades.Alumno", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CarreraId")
                        .HasColumnType("bigint");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstaEliminado")
                        .HasColumnType("bit");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CarreraId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Alumno");
                });

            modelBuilder.Entity("Dominio.Entidades.Carrera", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<decimal>("CantidadCuotas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstaEliminado")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Carrera");
                });

            modelBuilder.Entity("Dominio.Entidades.Cuota", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AlumnoId")
                        .HasColumnType("bigint");

                    b.Property<bool>("EstaEliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlumnoId");

                    b.ToTable("Cuota");
                });

            modelBuilder.Entity("Dominio.Entidades.Pago", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CuotaId")
                        .HasColumnType("bigint");

                    b.Property<bool>("EstaEliminado")
                        .HasColumnType("bit");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CuotaId");

                    b.ToTable("Pago");
                });

            modelBuilder.Entity("Dominio.Entidades.PrecioCuota", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CarreraId")
                        .HasColumnType("bigint");

                    b.Property<bool>("EstaEliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CarreraId");

                    b.ToTable("PrecioCuota");
                });

            modelBuilder.Entity("Dominio.Entidades.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("EstaEliminado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Dominio.Entidades.Alumno", b =>
                {
                    b.HasOne("Dominio.Entidades.Carrera", "Carrera")
                        .WithMany()
                        .HasForeignKey("CarreraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrera");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Dominio.Entidades.Cuota", b =>
                {
                    b.HasOne("Dominio.Entidades.Alumno", "Alumno")
                        .WithMany("Cuotas")
                        .HasForeignKey("AlumnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumno");
                });

            modelBuilder.Entity("Dominio.Entidades.Pago", b =>
                {
                    b.HasOne("Dominio.Entidades.Cuota", "Cuota")
                        .WithMany("Pagos")
                        .HasForeignKey("CuotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuota");
                });

            modelBuilder.Entity("Dominio.Entidades.PrecioCuota", b =>
                {
                    b.HasOne("Dominio.Entidades.Carrera", "Carrera")
                        .WithMany()
                        .HasForeignKey("CarreraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrera");
                });

            modelBuilder.Entity("Dominio.Entidades.Alumno", b =>
                {
                    b.Navigation("Cuotas");
                });

            modelBuilder.Entity("Dominio.Entidades.Cuota", b =>
                {
                    b.Navigation("Pagos");
                });
#pragma warning restore 612, 618
        }
    }
}
