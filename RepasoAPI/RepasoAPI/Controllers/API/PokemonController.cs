using DAL;
using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RepasoAPI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        // GET: api/<PokemonController>
        [HttpGet]
        public IActionResult Get()
        {

            IActionResult salida;
            List<ClsPokemon> listaPokemon = ClsListadosDAL.ObtieneListadoPokemon();

            if (listaPokemon == null || !listaPokemon.Any())
            {
                salida = StatusCode(StatusCodes.Status500InternalServerError, "No se pudo obtener el listado de Pokémon.");

            }
            else
            {
                Console.WriteLine(listaPokemon[1].GrupoHuevo);
                salida = Ok(listaPokemon);
            }



            return salida;
        }

        // GET api/<PokemonController>/5
        [HttpGet("{input}")]
        public IActionResult Get(string input)
        {
            if (int.TryParse(input, out int id))
            {
                ClsPokemon p = ClsListadosDAL.ObtienePokemonDex(id);
                return p == null
                    ? StatusCode(StatusCodes.Status500InternalServerError, "500. No se pudo obtener el pokémon")
                    : Ok(p);
            }
            else
            {
                ClsPokemon p = ClsListadosDAL.ObtienePokemonNombre(input);
                return p == null
                    ? StatusCode(StatusCodes.Status500InternalServerError, "500. No se pudo obtener el pokémon")
                    : Ok(p);
            }
        }

        // POST api/<PokemonController>
        [HttpPost]
        public IActionResult Post([FromBody] ClsPokemon p)
        {
            IActionResult salida;
            if (p == null)
            {
                salida = StatusCode(StatusCodes.Status500InternalServerError, "No se pudo crear.");
            }
            else
            {
                salida = Ok(p);
                ClsListadosDAL.addPokemon(p);
            }
            return salida;
        }

        // PUT api/<PokemonController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClsPokemon pokemon)
        {
            ClsPokemon p = ClsListadosDAL.ObtienePokemonDex(id);
            IActionResult salida;
            if (p == null)
            {
                salida = StatusCode(StatusCodes.Status500InternalServerError, "No se pudo crear.");
            }
            else
            {
                ClsListadosDAL.ModificaPokemon(pokemon);
                salida = Ok(p);

            }

            return salida;
        }
        // DELETE api/<PokemonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

