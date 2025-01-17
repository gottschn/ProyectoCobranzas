﻿using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración para realizar las eliminaciones de forma RESTRICT

            foreach(var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
            
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));


                foreach (var property in properties)
                {
                    modelBuilder.Entity(entityType.Name).Property(property.Name).HasColumnType("decimal(18,2)");
                }
            }

        }

        DbSet<Carrera> Carreras { get; set; }
        DbSet<Persona> Personas { get; set; }
        DbSet<Empleado> Empleados { get; set; }
        DbSet<Alumno> Alumnos { get; set; }
        DbSet<Cuota> Cuotas { get; set; }
        DbSet<Pago> Pagos { get; set; }
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<PrecioCuota> PrecioCuotas { get; set; }
        DbSet<Proceso> Procesos { get; set; }

    }
}