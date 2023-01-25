﻿// <auto-generated />
using System;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructura.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230124203112_RestructureDB04-0006")]
    partial class RestructureDB040006
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.Property<int>("EstadoCuota")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("MontoAbonado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<long>("PrecioCuotaId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AlumnoId");

                    b.HasIndex("PrecioCuotaId");

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

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CuotaId");

                    b.ToTable("Pago");
                });

            modelBuilder.Entity("Dominio.Entidades.Persona", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.HasKey("Id");

                    b.ToTable("Persona");

                    b.UseTptMappingStrategy();
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

            modelBuilder.Entity("Dominio.Entidades.Proceso", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntidadMovimiento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstaEliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Proceso");
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

                    b.Property<long>("PersonaId")
                        .HasColumnType("bigint");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Dominio.Entidades.Alumno", b =>
                {
                    b.HasBaseType("Dominio.Entidades.Persona");

                    b.Property<long>("CarreraId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<int>("Legajo")
                        .HasColumnType("int");

                    b.HasIndex("CarreraId");

                    b.ToTable("Persona_Alumno");
                });

            modelBuilder.Entity("Dominio.Entidades.Empleado", b =>
                {
                    b.HasBaseType("Dominio.Entidades.Persona");

                    b.Property<string>("AreaTrabajo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Persona_Empleado");
                });

            modelBuilder.Entity("Dominio.Entidades.Cuota", b =>
                {
                    b.HasOne("Dominio.Entidades.Alumno", "Alumno")
                        .WithMany("Cuotas")
                        .HasForeignKey("AlumnoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.PrecioCuota", "PrecioCuota")
                        .WithMany("Cuotas")
                        .HasForeignKey("PrecioCuotaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("PrecioCuota");
                });

            modelBuilder.Entity("Dominio.Entidades.Pago", b =>
                {
                    b.HasOne("Dominio.Entidades.Cuota", "Cuota")
                        .WithMany("Pagos")
                        .HasForeignKey("CuotaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cuota");
                });

            modelBuilder.Entity("Dominio.Entidades.PrecioCuota", b =>
                {
                    b.HasOne("Dominio.Entidades.Carrera", "Carrera")
                        .WithMany()
                        .HasForeignKey("CarreraId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Carrera");
                });

            modelBuilder.Entity("Dominio.Entidades.Proceso", b =>
                {
                    b.HasOne("Dominio.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Dominio.Entidades.Usuario", b =>
                {
                    b.HasOne("Dominio.Entidades.Persona", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Dominio.Entidades.Alumno", b =>
                {
                    b.HasOne("Dominio.Entidades.Carrera", "Carrera")
                        .WithMany()
                        .HasForeignKey("CarreraId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Persona", null)
                        .WithOne()
                        .HasForeignKey("Dominio.Entidades.Alumno", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrera");
                });

            modelBuilder.Entity("Dominio.Entidades.Empleado", b =>
                {
                    b.HasOne("Dominio.Entidades.Persona", null)
                        .WithOne()
                        .HasForeignKey("Dominio.Entidades.Empleado", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Entidades.Cuota", b =>
                {
                    b.Navigation("Pagos");
                });

            modelBuilder.Entity("Dominio.Entidades.PrecioCuota", b =>
                {
                    b.Navigation("Cuotas");
                });

            modelBuilder.Entity("Dominio.Entidades.Alumno", b =>
                {
                    b.Navigation("Cuotas");
                });
#pragma warning restore 612, 618
        }
    }
}
