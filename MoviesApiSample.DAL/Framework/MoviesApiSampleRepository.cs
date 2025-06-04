 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoviesApiSample.Models.MovieNamespace;
using Microsoft.Extensions.Logging;

namespace MoviesApiSample.DAL.Framework
{
    public interface IMoviesApiSampleRepository
    {
        Task InsertMovieAsync(Movie movie);
        Task DeleteMovieAsync(Movie movie);
        Task EditMovieAsync(Movie movie);
        Task<ICollection<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(int id);
    }

    public class MoviesApiSampleRepository : IMoviesApiSampleRepository
    {
        private readonly MoviesApiSampleDbContex _ctx;
        private readonly ILogger<MoviesApiSampleRepository> _logger;

        public MoviesApiSampleRepository(MoviesApiSampleDbContex ctx, ILogger<MoviesApiSampleRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public async Task InsertMovieAsync(Movie movie)
        {
            try
            {
                await _ctx.Movies.AddAsync(movie);
                await _ctx.SaveChangesAsync();
                _logger.LogInformation("Movie inserted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inserting movie.");
                throw;
            }
        }

        public async Task DeleteMovieAsync(Movie movie)
        {
            try
            {
                _ctx.Movies.Remove(movie);
                await _ctx.SaveChangesAsync();
                _logger.LogInformation("Movie deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting movie.");
                throw;
            }
        }

        public async Task EditMovieAsync(Movie movie)
        {
            try
            {
                _ctx.Movies.Update(movie);
                await _ctx.SaveChangesAsync();
                _logger.LogInformation("Movie updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating movie.");
                throw;
            }
        }

        public async Task<ICollection<Movie>> GetAllMoviesAsync()
        {
            try
            {
                return await _ctx.Movies.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving movies.");
                throw;
            }
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            try
            {
                var movie = await _ctx.Movies.FindAsync(id);
                if (movie == null)
                {
                    _logger.LogWarning($"Movie with id {id} not found.");
                }
                return movie;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving movie with id {id}.");
                throw;
            }
        }
    }
}