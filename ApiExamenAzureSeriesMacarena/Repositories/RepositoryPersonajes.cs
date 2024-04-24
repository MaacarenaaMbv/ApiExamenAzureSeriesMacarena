using ApiExamenAzureSeriesMacarena.Data;
using ApiExamenAzureSeriesMacarena.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExamenAzureSeriesMacarena.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajesContext context;
        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<List<string>> GetSeriesAsync()
        {
            List<string> series = await this.context.Personajes.Select(p => p.Serie).Distinct().ToListAsync();
            return series;
        }

        public async Task<Personaje> FindPersonajeAsync(int idPersonaje)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(z => z.IdPersonaje == idPersonaje);
        }

        public async Task<List<Personaje>> FindPersonajesSerieAsync(string serie)
        {
            return await this.context.Personajes.Where(p => p.Serie == serie).ToListAsync();
        }

        public async Task InsertPersonajeAsync(int idPersonaje, string nombre, string imagen, string serie)
        {
            Personaje personaje = new Personaje();
            personaje.IdPersonaje = idPersonaje;
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.Serie = serie;
            this.context.Personajes.Add(personaje);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonajeAsync(int idPersonaje, string nombre, string imagen, string serie)
        {
            Personaje personaje = await this.FindPersonajeAsync(idPersonaje);
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.Serie = serie;
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePersonaje(int idPersonaje)
        {
            Personaje personaje = await this.FindPersonajeAsync(idPersonaje);
            this.context.Personajes.Remove(personaje);
            await this.context.SaveChangesAsync();
        }

    }
}
