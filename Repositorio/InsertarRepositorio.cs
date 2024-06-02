using CareMod.Shared;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class InsertarRepositorio : IInsertarRepositorio
    {
        private readonly IDbConnection _dbconnection;

        public InsertarRepositorio(IDbConnection dbConnection)
        {
            _dbconnection = dbConnection;
        }

        /// <summary>
        /// Inserta una nuevo paciente en la base de datos.
        /// </summary>
        /// <param name="pacientes">La instancia de la clase Personas que contiene la información de la raza a insertar.</param>
        /// <returns>Devuelve true si la inserción fue exitosa, de lo contrario, false.</returns>
        public async Task<bool> InsertarPaciente(Pacientes pacientes)
        {
            try
            {
                string sql = @"
                INSERT INTO tb_pacientes
                (documento_paciente, tipo_documento, primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, fecha_de_nacimiento, rh, eps, tipo_de_usuario, residencia, religion, id_acompanniante, estatus_ac_noac, fecha_creacion, fecha_edicion, amarillo, rojo, ciam, morado, verde) 
                VALUES (:documento_paciente, :tipo_documento, :primer_nombre, :segundo_nombre, :primer_apellido, :segundo_apellido, :fecha_de_nacimiento, :RH, :eps, :tipo_de_usuario, :residencia, :religion, :id_acompanniante, :estatus_ac_noac, :fecha_creacion, :fecha_edicion, :amarillo, :rojo, :ciam, :morado, :verde)
                ";
                var resulttado = await _dbconnection.ExecuteAsync(sql, new
                {
                    pacientes.documento_paciente,
                    pacientes.tipo_documento,
                    pacientes.primer_nombre,
                    pacientes.segundo_nombre,
                    pacientes.primer_apellido,
                    pacientes.segundo_apellido,
                    pacientes.fecha_de_nacimiento,
                    pacientes.RH,
                    pacientes.eps,
                    pacientes.tipo_de_usuario,
                    pacientes.residencia,
                    pacientes.religion,
                    pacientes.id_acompanniante,
                    estatus_ac_noac=pacientes.estatus_ac_noac ? 1 : 0,
                    pacientes.fecha_creacion,
                    pacientes.fecha_edicion,
                    amarillo=pacientes.amarillo?1:0,
                    rojo=pacientes.rojo ? 1 : 0,
                    ciam = pacientes.ciam ? 1 : 0,
                    morado = pacientes.morado ? 1 : 0,
                    verde = pacientes.verde ? 1 : 0

                }, null, 10, CommandType.Text);

                return resulttado > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally { _dbconnection.Close(); }
        }

        /// <summary>
        /// Inserta una nueva especie en la base de datos.
        /// </summary>
        /// <param name="empleadosDTO">La instancia de la clase Especies que contiene la información de la especie a insertar.</param>
        /// <returns>Devuelve true si la inserción fue exitosa, de lo contrario, false.</returns>
        public async Task<bool> InsertarEmpleado(EmpleadosDTO empleadosDTO)
        {
            try
            {
                string sql = "InsertarEmpleado";

                var resulttado = await _dbconnection.ExecuteAsync(sql, new
                {
                    empleadosDTO.fecha_de_ingreso,
                    empleadosDTO.persona,
                    empleadosDTO.jefe,
                    empleadosDTO.nombre_usuario,
                    empleadosDTO.contrasennia,
                    empleadosDTO.detalle_permisos,
                }, null, 10, CommandType.StoredProcedure);

                return resulttado > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally { _dbconnection.Close(); }
        }

        /// <summary>
        /// Inserta una nueva persona en la base de datos.
        /// </summary>
        /// <param name="registro_OcupacionesDTO">La instancia de la clase Personas que contiene la información de la persona a insertar.</param>
        /// <returns>Devuelve true si la inserción fue exitosa, de lo contrario, false.</returns>
        public async Task<bool> InsertarRegistro_ocupaciones(Registro_ocupacionesDTO registro_OcupacionesDTO)
        {
            try
            {
                string sql = "InsertarRegistro_ocupaciones";

                var resulttado = await _dbconnection.ExecuteAsync(sql, new
                {
                    registro_OcupacionesDTO.fecha_ingreso,
                    registro_OcupacionesDTO.fecha_salida,
                    registro_OcupacionesDTO.cama,
                    registro_OcupacionesDTO.id_paciente,
                }, null, 10, CommandType.StoredProcedure);

                return resulttado > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally { _dbconnection.Close(); }
        }
    }
}
