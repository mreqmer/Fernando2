using BL;
using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamenAPI_MartaRequejo.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        // GET: api/<DepartamentosController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult resultado;

            List<ClsDepartamento> departamentos = ClsListadosBL.obtieneListaDepartamentoBl();

            if (departamentos==null)
            {
                resultado = StatusCode(StatusCodes.Status500InternalServerError, "No se pudo obtener el listado");
            }
            else
            {
                resultado = Ok(departamentos);
            }

            return resultado;
        }

        // GET api/<DepartamentosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult resultado;

            ClsDepartamento departamento = ClsManejadoraBL.obtieneDepartamentoIdBL(id);

            if (departamento == null)
            {
                resultado = StatusCode(StatusCodes.Status500InternalServerError, "No se pudo obtener el listado");
            }
            else
            {
                resultado = Ok(departamento);
            }

            return resultado;
        }

        // GET api/<DepartamentosController>/5/Personas
        [HttpGet("{id}/Personas")]
        public IActionResult GetPersona(int id)
        {
            IActionResult resultado;

            List<ClsPersona> personas = ClsListadosBL.obtienePersonasDepartamentoBL(id);

            if (personas == null)
            {
                resultado = StatusCode(StatusCodes.Status500InternalServerError, "No se pudo obtener el listado");
            }
            else
            {
                resultado = Ok(personas);
            }

            return resultado;
        }

        // GET api/<DepartamentosController>/3/Personas/6
        [HttpGet("{id}/Personas/{idPersona}")]
        public IActionResult GetPersona(int id, int idPersona)
        {
            //No se si está bien hacer un GET para los datos de una persona de un departamento 
            IActionResult resultado;

            ClsPersona persona = ClsManejadoraBL.obtienePersonaIdBL(idPersona);

            if (persona == null)
            {
                resultado = StatusCode(StatusCodes.Status500InternalServerError, "No se pudo obtener el listado");
            }
            else
            {
                resultado = Ok(persona);
            }

            return resultado;
        }

        //// POST api/<DepartamentosController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<DepartamentosController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<DepartamentosController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
