using Microsoft.AspNetCore.Mvc;
using PasantiasTW.Models.Dtos;
using PasantiasTW.Services;

namespace PasantiasTW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PracticeController : ControllerBase
    {
        private readonly IPracticeService _service;

        public PracticeController(IPracticeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPractices()
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPracticeById(Guid id)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var practice = await _service.GetById(id);
            return practice is null ? NotFound() : Ok(practice);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePractice([FromBody] CreatePracticeDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var practice = await _service.Create(dto);
            return CreatedAtAction(nameof(GetPracticeById), new { id = practice.PracticeId }, practice);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePractice(Guid id, [FromBody] UpdatePracticeDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var updatedPractice = await _service.Update(id, dto);
            return updatedPractice is null ? NotFound() : Ok(updatedPractice);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePractice(Guid id)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            await _service.Delete(id);
            return NoContent();
        }
    }
}