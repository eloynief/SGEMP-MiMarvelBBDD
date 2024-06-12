using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiMarvelBBDD.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        // GET: api/<PersonajesController>
        [HttpGet]
        public IActionResult Get()
        {

            IActionResult salida;

            List<clasePersonaje> listado = new List<clasePersonaje>();



            //try para ponerle los valores a la lista y ponerlos al IactionResult
            try
            {

                listado = ClaseBL.listaPersonajesAzureBL();

                if (listado.Count == 0)
                {

                    salida = NoContent();
                }
                else
                {
                    salida = Ok(listado);
                }

            }
            catch (Exception ex)
            {

                salida = BadRequest();

            }


            return salida;

        }

        // GET api/<PersonajesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PersonajesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {















        }

        // PUT api/<PersonajesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonajesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
