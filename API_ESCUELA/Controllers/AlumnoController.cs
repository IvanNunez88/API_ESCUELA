using API_ESCUELA.BLL;
using API_ESCUELA.MODELS;
using API_ESCUELA.MODELS.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API_ESCUELA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController(IConfiguration _config) : ControllerBase
    {
        private string conn = _config.GetConnectionString("Prod");

        [HttpPost] //INSERT - CREATE
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] DtoAltaAlumno Alumno)
        {
            IEnumerable<string> enuValidaciones = await BL_ALUMNO.ValidarDatosAlta(Alumno);
            ResponseApi<IEnumerable<string>> rsp = new();

            if (!enuValidaciones.Any())
            {
                IEnumerable<string> enuDatos = await BL_ALUMNO.GuardarAlumno(conn, Alumno);
                if (enuDatos.ToList()[0] == "00")
                {
                    rsp.Status = enuDatos.ToList()[0];
                    rsp.Value = enuDatos;
                }
                else
                {
                    rsp.Status = enuDatos.ToList()[0];
                    rsp.Msg = enuDatos.ToList()[1];
                }

            }
            else
            {
                rsp.Status = "14";
                rsp.Msg = enuValidaciones.ToList()[0];
            }

            return Ok(rsp);
        }

        [HttpGet] // SELECT - READ
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            IEnumerable<DtoConsulAlumnos> enuDatos = await BL_ALUMNO.ListarAlumno(conn);
            ResponseApi<IEnumerable<DtoConsulAlumnos>> rsp = new();

            if (enuDatos.Any())
            {
                //PRUEBA DE CAMBIO
                rsp.Status = "00";
                rsp.Value = enuDatos;
            }
            else
            {
                rsp.Status = "14";
                rsp.Msg = "No se encontro información";
            }


            return Ok(rsp);
        }

        [HttpPut] // UPDATE - UPDATE
        [Route("Modificar")]
        public async Task<IActionResult> Modificar([FromBody] DtoModificarAlumno Alumno)
        {
            IEnumerable<string> enuValidaciones = await BL_ALUMNO.ValidarDatosModificacion(Alumno);
            ResponseApi<IEnumerable<string>> rsp = new();

            if (!enuValidaciones.Any())
            {
                IEnumerable<string> enuDatos = await BL_ALUMNO.ModificarAlumno(conn, Alumno);
                if (enuDatos.ToList()[0] == "00")
                {
                    rsp.Status = enuDatos.ToList()[0];
                    rsp.Value = enuDatos;
                }
                else
                {
                    rsp.Status = enuDatos.ToList()[0];
                    rsp.Msg = enuDatos.ToList()[1];
                }

            }
            else
            {
                rsp.Status = "14";
                rsp.Msg = enuValidaciones.ToList()[0];
            }

            return Ok(rsp);
        }

        [HttpDelete] //DELETE -- DELETE
        [Route("Borrar/{Matricula:int}")]
        public async Task<IActionResult> Borrar(int Matricula)
        {
            IEnumerable<string> enuDatos = await BL_ALUMNO.BorrarAlumno(conn, Matricula);
            ResponseApi<IEnumerable<string>> rsp = new();

            if (enuDatos.ToList()[0] == "00")
            {
                rsp.Status = enuDatos.ToList()[0];
                rsp.Value = enuDatos;
            }
            else
            {
                rsp.Status = "14";
                rsp.Msg = enuDatos.ToList()[1];
            }

            return Ok(rsp);
        }

    }
}
