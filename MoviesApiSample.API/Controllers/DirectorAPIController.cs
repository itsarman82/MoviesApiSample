using Microsoft.AspNetCore.Mvc;
using MoviesApiSample.DAL.Framework;
using MoviesApiSample.Models;
using MoviesApiSample.Models.DirectorNamespace;
using System.ComponentModel.DataAnnotations;

namespace MoviesApiSample.API.Controllers
{
    [ApiController]
    [Route("Directors/[controller]")]
    public class DirectorAPIController : ControllerBase
    {
        private readonly ILogger<DirectorAPIController> _logger;
        private readonly IDirectorApiSampleRepository _directorApiSampleRepository;

        public DirectorAPIController(ILogger<DirectorAPIController> logger, IDirectorApiSampleRepository directorApiSampleRepository)
        {
            _logger = logger;
            _directorApiSampleRepository = directorApiSampleRepository;
        }

        [HttpGet(Name = "GetDirectors")]
        public async Task<IActionResult> GetDirectors()
        {
            try
            {
                var directors = await _directorApiSampleRepository.GetAllDirectorsAsync();
                var directorDtos = directors.Select(director => new DirectorDto
                {
                    Id = director.Id,
                    Name = director.Name,
                    LastName = director.LastName,
                    Gender = director.Gender,
                    Age = director.Age
                });
                return Ok(directorDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting directors.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id:int}", Name = "GetDirectorById")]
        public async Task<IActionResult> GetDirectorById(int id)
        {
            try
            {
                var director = await _directorApiSampleRepository.GetDirectorByIdAsync(id);
                if (director == null)
                {
                    return NotFound();
                }

                var directorDto = new DirectorDto
                {
                    Id = director.Id,
                    Name = director.Name,
                    LastName = director.LastName,
                    Gender = director.Gender,
                    Age = director.Age
                };

                return Ok(directorDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting director by id.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost(Name = "CreateDirector")]
        public async Task<IActionResult> CreateDirector([FromBody, Required] CreateDirectorDto createDirectorDto)
        {
            try
            {
                if (createDirectorDto == null)
                {
                    return BadRequest("Director object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var director = new Director
                {
                    Name = createDirectorDto.Name,
                    LastName = createDirectorDto.LastName,
                    Gender = createDirectorDto.Gender,
                    Age = createDirectorDto.Age
                };

                await _directorApiSampleRepository.AddDirectorAsync(director);
                return CreatedAtRoute("GetDirectorById", new { id = director.Id }, director);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating director.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id:int}", Name = "UpdateDirector")]
        public async Task<IActionResult> UpdateDirector(int id, [FromBody, Required] UpdateDirectorDto updateDirectorDto)
        {
            try
            {
                if (updateDirectorDto == null)
                {
                    return BadRequest("Director object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingDirector = await _directorApiSampleRepository.GetDirectorByIdAsync(id);
                if (existingDirector == null)
                {
                    return NotFound();
                }

                existingDirector.Name = updateDirectorDto.Name;
                existingDirector.LastName = updateDirectorDto.LastName;
                existingDirector.Gender = updateDirectorDto.Gender;
                existingDirector.Age = updateDirectorDto.Age;

                await _directorApiSampleRepository.UpdateDirectorAsync(existingDirector);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating director.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id:int}", Name = "DeleteDirector")]
        public async Task<IActionResult> DeleteDirector(int id)
        {
            try
            {
                var director = await _directorApiSampleRepository.GetDirectorByIdAsync(id);
                if (director == null)
                {
                    return NotFound();
                }

                await _directorApiSampleRepository.DeleteDirectorAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting director.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
