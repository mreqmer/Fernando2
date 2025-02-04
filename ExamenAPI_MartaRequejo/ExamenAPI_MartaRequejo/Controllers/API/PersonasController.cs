using BL;
using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamenAPI_MartaRequejo.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        // GET: api/<PersonasController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult resultado;

            List<ClsPersona> personas = ClsListadosBL.obtieneListaPersonasBl();

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

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult resultado;

            ClsPersona persona = ClsManejadoraBL.obtienePersonaIdBL(id);

            if (persona == null)
            {
                resultado = StatusCode(StatusCodes.Status500InternalServerError, "No se pudo obtener la persona");
            }
            else
            {
                resultado = Ok(persona);
            }

            return resultado;
        }

        //// POST api/<PersonasController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PersonasController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PersonasController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
