using ApiExamenAzureSeriesMacarena.Models;
using ApiExamenAzureSeriesMacarena.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiExamenAzureSeriesMacarena.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonajes repo;

        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            return await this.repo.GetPersonajesAsync();
        }
        [HttpGet]
        [Route("Series")]

        public async Task<ActionResult<List<string>>> GetSeries()
        {
            return await this.repo.GetSeriesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personaje>> FindPersonaje(int id)
        {
            return await this.repo.FindPersonajeAsync(id);
        }

        [HttpGet]
        [Route("PersonajesSeries/{serie}")]

        public async Task<ActionResult<List<Personaje>>> FindPersonajesSeries(string serie)
        {
            return await this.repo.FindPersonajesSerieAsync(serie);
        }

        [HttpPost]
        [Route("[action]")]

        public async Task<ActionResult> InsertPersonaje(Personaje personaje)
        {
            await this.repo.InsertPersonajeAsync(personaje.IdPersonaje, personaje.Nombre, personaje.Imagen, personaje.Serie);
            return Ok();
        }

        [HttpPut]
        [Route("[action]")]

        public async Task<ActionResult> UpdatePersonaje(Personaje personaje)
        {
            await this.repo.UpdatePersonajeAsync(personaje.IdPersonaje, personaje.Nombre, personaje.Imagen, personaje.Serie);
            return Ok();
        }

        [HttpDelete]
        [Route("[action]")]

        public async Task<ActionResult> DeletePersonaje(int id)
        {
            if (await this.repo.FindPersonajeAsync(id) == null)
            {
                return NotFound();
            }
            else
            {
                await this.repo.DeletePersonaje(id);
                return Ok();
            }
        }

    }
}
