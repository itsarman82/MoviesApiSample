using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoviesApiSample.Models.ActorNamespace;

namespace MoviesApiSample.DAL.Framework
{

    public interface IActorApiSampleRepository
    {
        Task<IEnumerable<Actor>> GetAllActorAsync();
        Task<Actor> GetActorByIdAsync(int id);
        Task AddActorAsync(Actor actor);
        Task DeleteActorAsync(int id);
        Task UpdateActorAsync(Actor actor);
    }
    public class ActorApiSampleRepository : IActorApiSampleRepository
    {
        private readonly MoviesApiSampleDbContex _context;

        public ActorApiSampleRepository(MoviesApiSampleDbContex context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Actor>> GetAllActorAsync()
        {
            return await _context.Actors.ToListAsync();
        }

        public async Task<Actor> GetActorByIdAsync(int id)
        {
            return await _context.Actors.FindAsync(id);
        }

        public async Task AddActorAsync(Actor actor)
        {
            if (actor == null) throw new ArgumentNullException(nameof(actor));

            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateActorAsync(Actor actor)
        {
            if (actor == null) throw new ArgumentNullException(nameof(actor));

            var existingActor = await _context.Actors.FindAsync(actor.Id);
            if (existingActor != null)
            {
                existingActor.Name = actor.Name;
                existingActor.LastName = actor.LastName;
                existingActor.Gender = actor.Gender;
                existingActor.Age = actor.Age;

                _context.Actors.Update(existingActor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteActorAsync(int id)
        {
            var actor = await _context.Actors.FindAsync(id);
            if (actor != null)
            {
                _context.Actors.Remove(actor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
