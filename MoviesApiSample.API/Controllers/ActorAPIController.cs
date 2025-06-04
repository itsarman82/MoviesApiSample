using Microsoft.AspNetCore.Mvc;
using MoviesApiSample.DAL.Framework;
using MoviesApiSample.Models;
using MoviesApiSample.Models.ActorNamespace;
using System.ComponentModel.DataAnnotations;

namespace MoviesApiSample.API.Controllers
{
    [ApiController]
    [Route("Actors/[controller]")]
    public class ActorAPIController : ControllerBase
    {
        private readonly ILogger<ActorAPIController> _logger;
        private readonly IActorApiSampleRepository _actorApiSampleRepository;

        public ActorAPIController(ILogger<ActorAPIController> logger, IActorApiSampleRepository actorApiSampleRepository)
        {
            _logger = logger;
            _actorApiSampleRepository = actorApiSampleRepository;
        }

        [HttpGet(Name = "GetActors")]
        public async Task<IActionResult> GetActors()
        {
            try
            {
                var actors = await _actorApiSampleRepository.GetAllActorAsync();
                var actorDtos = actors.Select(actor => new ActorDto
                {
                    Id = actor.Id,
                    Name = actor.Name,
                    LastName = actor.LastName,
                    Gender = actor.Gender,
                    Age = actor.Age
                });
                return Ok(actorDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting actors.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id:int}", Name = "GetActorById")]
        public async Task<IActionResult> GetActorById(int id)
        {
            try
            {
                var actor = await _actorApiSampleRepository.GetActorByIdAsync(id);
                if (actor == null)
                {
                    return NotFound();
                }

                var actorDto = new ActorDto
                {
                    Id = actor.Id,
                    Name = actor.Name,
                    LastName = actor.LastName,
                    Gender = actor.Gender,
                    Age = actor.Age
                };

                return Ok(actorDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting actor by id.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost(Name = "CreateActor")]
        public async Task<IActionResult> CreateActor([FromBody, Required] CreateActorDto createActorDto)
        {
            try
            {
                if (createActorDto == null)
                {
                    return BadRequest("Actor object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var actor = new Actor
                {
                    Name = createActorDto.Name,
                    LastName = createActorDto.LastName,
                    Gender = createActorDto.Gender,
                    Age = createActorDto.Age
                };

                await _actorApiSampleRepository.AddActorAsync(actor);
                return CreatedAtRoute("GetActorById", new { id = actor.Id }, actor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating actor.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id:int}", Name = "UpdateActor")]
        public async Task<IActionResult> UpdateActor(int id, [FromBody, Required] UpdateActorDto updateActorDto)
        {
            try
            {
                if (updateActorDto == null)
                {
                    return BadRequest("Actor object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingActor = await _actorApiSampleRepository.GetActorByIdAsync(id);
                if (existingActor == null)
                {
                    return NotFound();
                }

                existingActor.Name = updateActorDto.Name;
                existingActor.LastName = updateActorDto.LastName;
                existingActor.Gender = updateActorDto.Gender;
                existingActor.Age = updateActorDto.Age;

                await _actorApiSampleRepository.UpdateActorAsync(existingActor);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating actor.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id:int}", Name = "DeleteActor")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            try
            {
                var actor = await _actorApiSampleRepository.GetActorByIdAsync(id);
                if (actor == null)
                {
                    return NotFound();
                }

                await _actorApiSampleRepository.DeleteActorAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting actor.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
