﻿using Dominio.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Carrera")]
    [MetadataType(typeof(ICarrera))]
    public class Carrera : EntidadBase
    {
        public string Descripcion { get; set; }

        public decimal CantidadCuotas { get; set; }

        // Propiedades de Navegacion

        public ICollection<AlumnoCarrera> AlumnoCarreras { get; set; }
    }
}
