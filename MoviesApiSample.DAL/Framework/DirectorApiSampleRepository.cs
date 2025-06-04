using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoviesApiSample.Models.DirectorNamespace;

namespace MoviesApiSample.DAL.Framework
{
    public interface IDirectorApiSampleRepository
    {
        Task AddDirectorAsync(Director director);
        Task DeleteDirectorAsync(int id);
        Task<Director> GetDirectorByIdAsync(int id);
        Task<IEnumerable<Director>> GetAllDirectorsAsync();
        Task UpdateDirectorAsync(Director director);
    }
    public class DirectorApiSampleRepository : IDirectorApiSampleRepository
    {
        private readonly MoviesApiSampleDbContex _context;

        public DirectorApiSampleRepository(MoviesApiSampleDbContex contex)
        {
            _context = contex;
        }

        public async Task AddDirectorAsync(Director director)
        {
            if (director == null)
            {
                throw new ArgumentNullException(nameof(director));
            }
            await _context.AddAsync(director);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Director>> GetAllDirectorsAsync()
        {
            return await _context.Directors.ToListAsync();
        }

        public async Task<Director> GetDirectorByIdAsync(int id)
        {
            return await _context.Directors.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task UpdateDirectorAsync(Director director)
        {
            if (director == null)
            {
                throw new ArgumentNullException(nameof(director));
            }

            var existingDirector = await GetDirectorByIdAsync(director.Id);
            if (existingDirector != null)
            {
                existingDirector.Name = director.Name;
                existingDirector.LastName = director.LastName;
                existingDirector.Gender = director.Gender;
                existingDirector.Age = director.Age;

                _context.Update(existingDirector);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteDirectorAsync(int id)
        {
            var director = await GetDirectorByIdAsync(id);
            if (director != null)
            {
                _context.Remove(director);
                await _context.SaveChangesAsync();
            }
        }
    }
}
