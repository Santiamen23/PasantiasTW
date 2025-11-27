using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PasantiasTW.Models;
using PasantiasTW.Models.Dtos;
using PasantiasTW.Services;

namespace PasantiasTW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentResponseDto>>> GetAllStudents()
        {
            var items = await _service.GetAll();
            return Ok(items);
        }
        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<StudentResponseDto>> GetOne(Guid id)
        {
            var student = await _service.GetOne(id);
            return student is null ? NotFound() : Ok(student);
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<StudentResponseDto>> CreateStudent([FromBody] CreateStudentDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var student = await _service.CreateStudent(dto);
            return CreatedAtAction(nameof(GetOne), new { id = student.Id }, student);
        }
        [HttpPut("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<StudentResponseDto>> UpdateStudent([FromBody] UpdateStudentDto dto, Guid id)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var update = await _service.UpdateStudent(dto, id);
            return Ok(update);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            await _service.DeleteStudent(id);
            return NoContent();
        }
    }
}
