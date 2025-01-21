using BL;
using ENT;
using Microsoft.AspNetCore.Mvc;
using EjercicioASP.Models.VM;
using EjercicioASP.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EjercicioASP.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        // GET: api/<PesonasController>
        [HttpGet]
        public List<ClsPersona>  Get()
        {
            List<ClsPersona> listaPersonas = new List<ClsPersona>();
            try
            {
                listaPersonas = ClsListadosBL.ObtieneListadoPersonasBl();

                return listaPersonas;
            }
            catch (Exception ex)
            {
                
            }
            

            return listaPersonas;
        }

        // GET api/<PesonasController>/5
        [HttpGet("{id}")]
        public ClsPersona Get(int id)
        {
            ClsPersona p = ClsManejadoraBL.findPersonaBl(id);
            
            return p;
        }

        // POST api/<PesonasController>
        [HttpPost]
        public IActionResult Post([FromBody] ClsPersona persona)
        {
            IActionResult salida;

            if (persona != null)
            {
                try
                {
                    int affectedRows = ClsManejadoraBL.newPersonaBl(persona);
                    if (affectedRows > 0)
                    {
                        salida = Ok("Se ha guardado correctamente.");
                    }
                    else
                    {
                        salida = Ok("No se ha podido guardar la persona.");
                    }
                }
                catch (Exception e)
                {
                    salida = BadRequest();
                }
            }
            else
            {
                salida = BadRequest();
            }
            return salida;
        }

        // PUT api/<PesonasController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] ClsPersona persona)
        {
            IActionResult salida;
            if (persona != null && persona.Id > 0)
            {
                try
                {
                    int affectedRows =ClsManejadoraBL.newPersonaBl(persona);
                    if (affectedRows > 0)
                    {
                        salida = Ok("Se ha modificado correctamente");
                    }
                    else
                    {
                        salida = Ok("No se ha podido modificar la persona");
                    }
                }
                catch (Exception e)
                {
                    salida = BadRequest();
                }
            }
            else
            {
                salida = BadRequest();
            }
            return salida;
        }

        // DELETE api/<PesonasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult salida;
            if (id > 0)
            {
                try
                {
                    int affectedRows = ClsManejadoraBL.borrarPersonaBl(id);
                    if (affectedRows > 0)
                    {
                        salida = Ok("Se ha borrado de forma satisfactoria.");
                    }
                    else
                    {
                        salida = Ok("No se ha podido borrar.");
                    }
                }
                catch (Exception e)
                {
                    salida = BadRequest();
                }
            }
            else
            {
                salida = BadRequest();
            }
            return salida;
        }
    }
}
