﻿using Dominio.Entidades;
using Dominio.Interfaces;
using Infraestructura.Data;
using Infraestructura.Repositorio;
//using System.Data.Entity.Validation;

namespace Infraestructura.UnidadDeTrabajo
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        private readonly DataContext _context;

        public UnidadDeTrabajo(DataContext context)
        {
            _context = context;
        }


        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Disposed()
        {
            _context.Dispose();
        }


        // ====================================================================================================================================== //
        public IRepositorio<Carrera> _carreraRepositorio;

        public IRepositorio<Carrera> CarreraRepositorio => _carreraRepositorio ?? (_carreraRepositorio = new Repositorio<Carrera>(_context));

        // ====================================================================================================================================== //

        public IAlumnoRepositorio _alumnoRepositorio;

        public IAlumnoRepositorio AlumnoRepositorio => _alumnoRepositorio ?? (_alumnoRepositorio = new AlumnoRepositorio(_context));

        // ====================================================================================================================================== //
        
        public IRepositorio<AlumnoCarrera> _alumnoCarreraRepositorio;

        public IRepositorio<AlumnoCarrera> AlumnoCarreraRepositorio => _alumnoCarreraRepositorio ?? (_alumnoCarreraRepositorio = new Repositorio<AlumnoCarrera>(_context));

        // ====================================================================================================================================== //

        public IEmpleadoRepositorio _empleadoRepositorio;

        public IEmpleadoRepositorio EmpleadoRepositorio => _empleadoRepositorio ?? (_empleadoRepositorio = new EmpleadoRepositorio(_context));

        // ====================================================================================================================================== //

        public IRepositorio<Pago> _pagoRepositorio;

        public IRepositorio<Pago> PagoRepositorio => _pagoRepositorio ?? (_pagoRepositorio = new Repositorio<Pago>(_context));

        // ====================================================================================================================================== //

        public IRepositorio<Cuota> _cuotaRepositorio;

        public IRepositorio<Cuota> CuotaRepositorio => _cuotaRepositorio ?? (_cuotaRepositorio = new Repositorio<Cuota>(_context));

        // ====================================================================================================================================== //

        public IRepositorio<PrecioCuota> _precioCuotaRepositorio;

        public IRepositorio<PrecioCuota>PrecioCuotaRepositorio => _precioCuotaRepositorio ?? (_precioCuotaRepositorio = new Repositorio<PrecioCuota>(_context));

        // ====================================================================================================================================== //

        public IRepositorio<Usuario> _usuarioRepositorio;

        public IRepositorio<Usuario> UsuarioRepositorio => _usuarioRepositorio ?? (_usuarioRepositorio = new Repositorio<Usuario>(_context));

    }
}

