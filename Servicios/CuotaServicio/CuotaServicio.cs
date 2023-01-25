﻿using Dominio.Entidades;
using Dominio.Interfaces;
using IServicios.Base.Base_DTO;
using IServicios.Cuota;
using IServicios.Cuota.CuotaDTO;
using IServicios.Persona.DTO_s;
using IServicios.PrecioCuota.PrecioCuotaDTO;
using Servicios.Base;
using System.Linq.Expressions;

namespace Servicios.CuotaServicio
{
    public class CuotaServicio : ICuotaServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        public CuotaServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Eliminar(long id)
        {
            await _unidadDeTrabajo.CuotaRepositorio.Eliminar(id);
            _unidadDeTrabajo.Commit();
        }

        public async Task<long> Crear(BaseDTO dtoEntidad)
        {
            var dto = (CuotaDTO)dtoEntidad;

            DateTime fecha = DateTime.Now;

            var entidad = new Cuota
            {
                Numero = dto.Numero,
                MontoAbonado = 0,
                Fecha = fecha,
                EstadoCuota = dto.EstadoCuota,
                PrecioCuotaId = dto.PrecioCuotaId,
                AlumnoId = dto.AlumnoId,
                EstaEliminado = false,
            };

            await _unidadDeTrabajo.CuotaRepositorio.Crear(entidad);

            _unidadDeTrabajo.Commit();

            return entidad.Id;
        }


        public async Task Modificar(BaseDTO dtoEntidad)
        {
            var dto = (CuotaDTO)dtoEntidad;

            var entidad = await _unidadDeTrabajo.CuotaRepositorio.Obtener(dto.Id);

            if (entidad == null) throw new Exception("No se encotró la cuota que quiere modificar");

            entidad.Id = dto.Id;
            entidad.Numero = dto.Numero;
            entidad.EstadoCuota = dto.EstadoCuota;
            entidad.PrecioCuotaId = dto.PrecioCuotaId;
            entidad.AlumnoId = dto.AlumnoId;


            await _unidadDeTrabajo.CuotaRepositorio.Modificar(entidad);

            _unidadDeTrabajo.Commit();
        }

        public async Task<BaseDTO> Obtener(long id)
        {
            var entidad = await _unidadDeTrabajo.CuotaRepositorio.Obtener(id, "PrecioCuota.Carrera, Alumno.Carrera");

            if (entidad == null) throw new Exception("No se encotró la cuota que esta buscando");

            return new CuotaDTO
            {
                Id = entidad.Id,
                Numero = entidad.Numero,
                MontoAbonado = entidad.MontoAbonado,
                Fecha = entidad.Fecha,
                EstadoCuota = entidad.EstadoCuota,
                PrecioCuotaId = entidad.PrecioCuotaId,
                PrecioCuota = new PrecioCuotaDTO {
                    Id = entidad.PrecioCuota.Id,
                    Monto = entidad.PrecioCuota.Monto,
                    Fecha = entidad.PrecioCuota.Fecha,
                    CarreraId = entidad.PrecioCuota.CarreraId,
                    Carrera = entidad.PrecioCuota.Carrera.Descripcion,
                },
                AlumnoId = entidad.AlumnoId,
                Alumno = new AlumnoDTO
                {
                    Id = entidad.Alumno.Id,
                    Legajo = entidad.Alumno.Legajo,
                    Nombre = entidad.Alumno.Nombre,
                    Apellido = entidad.Alumno.Apellido,
                    Dni = entidad.Alumno.Dni,
                    Mail = entidad.Alumno.Mail,
                    FechaIngreso = entidad.Alumno.FechaIngreso,
                    Carrera = entidad.Alumno.Carrera.Descripcion

                },
                Eliminado = entidad.EstaEliminado,
            };
        }

        public async Task<IEnumerable<BaseDTO>> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Cuota, bool>> filtro = x => x.Numero.ToString() == cadenaBuscar;

            if (!mostrarTodos)
            {
                filtro = filtro.And(x => !x.EstaEliminado);
            }

            var entidad = await _unidadDeTrabajo.CuotaRepositorio.Obtener(filtro, "PrecioCuota.Carrera, Alumno.Carrera");

            return entidad.Select(x => new CuotaDTO
            {
                Id = x.Id,
                Numero = x.Numero,
                MontoAbonado = x.MontoAbonado,
                Fecha = x.Fecha,
                EstadoCuota = x.EstadoCuota,
                PrecioCuotaId = x.PrecioCuotaId,
                PrecioCuota = new PrecioCuotaDTO
                {
                    Id = x.PrecioCuota.Id,
                    Monto = x.PrecioCuota.Monto,
                    Fecha = x.PrecioCuota.Fecha,
                    CarreraId = x.PrecioCuota.CarreraId,
                    Carrera = x.PrecioCuota.Carrera.Descripcion,
                },
                AlumnoId = x.AlumnoId,
                Alumno = new AlumnoDTO
                {
                    Id = x.Alumno.Id,
                    Legajo = x.Alumno.Legajo,
                    Nombre = x.Alumno.Nombre,
                    Apellido = x.Alumno.Apellido,
                    Dni = x.Alumno.Dni,
                    Mail = x.Alumno.Mail,
                    FechaIngreso = x.Alumno.FechaIngreso,
                    Carrera = x.Alumno.Carrera.Descripcion

                },
                Eliminado = x.EstaEliminado,
            })
                .OrderBy(x => x.Numero)
                .ToList();
        }

        public async Task<IEnumerable<BaseDTO>> ObtenerTodos()
        {
            var entidad = await _unidadDeTrabajo.CuotaRepositorio.ObtenerTodos("PrecioCuota.Carrera, Alumno.Carrera");

            return entidad.Select(x => new CuotaDTO
            {
                Id = x.Id,
                Numero = x.Numero,
                MontoAbonado = x.MontoAbonado,
                Fecha = x.Fecha,
                EstadoCuota = x.EstadoCuota,
                PrecioCuotaId = x.PrecioCuotaId,
                PrecioCuota = new PrecioCuotaDTO
                {
                    Id = x.PrecioCuota.Id,
                    Monto = x.PrecioCuota.Monto,
                    Fecha = x.PrecioCuota.Fecha,
                    CarreraId = x.PrecioCuota.CarreraId,
                    Carrera = x.PrecioCuota.Carrera.Descripcion,
                },
                AlumnoId = x.AlumnoId,
                Alumno = new AlumnoDTO
                {
                    Id = x.Alumno.Id,
                    Legajo = x.Alumno.Legajo,
                    Nombre = x.Alumno.Nombre,
                    Apellido = x.Alumno.Apellido,
                    Dni = x.Alumno.Dni,
                    Mail = x.Alumno.Mail,
                    FechaIngreso = x.Alumno.FechaIngreso,
                    Carrera = x.Alumno.Carrera.Descripcion

                },
                Eliminado = x.EstaEliminado,
            })
                .OrderBy(x => x.Numero)
                .ToList();
        }
    }
}