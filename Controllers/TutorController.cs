using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PasantiasTW.Models.Dtos.Tutor;
using PasantiasTW.Services;

namespace PasantiasTW.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class TutorController:ControllerBase
    {
        private readonly ITutorService _service;
        public TutorController(ITutorService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllTutors()
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            return Ok(await _service.getAll());
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetTutorById(Guid id)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var tutor = await _service.getById(id);
            return tutor is null?NotFound(new { error = "Tutor not found", code = 404 }) :Ok(tutor);
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> CreateTutor([FromBody] CreateTutorDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var tutor = await _service.create(dto);
            return CreatedAtAction(nameof(GetTutorById), new { id = tutor }, tutor);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> UpdateTutor(Guid id, [FromBody] UpdateTutorDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var updatedTutor = await _service.update(id, dto);
            return updatedTutor is null ? NotFound(new { error = "Tutor not found", code = 404 }) : Ok(updatedTutor);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> DeleteTutor(Guid id)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            await _service.delete(id);
            return NoContent();
        }
    }
}
