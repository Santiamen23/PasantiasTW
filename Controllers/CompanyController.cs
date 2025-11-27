using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PasantiasTW.Models;
using PasantiasTW.Models.Dtos.Company;
using PasantiasTW.Services;

namespace PasantiasTW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;
        public CompanyController(ICompanyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyResponseDto>>> GetAllCompanies()
        {
            var items = await _service.GetAll();
            return Ok(items);
        }
        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<CompanyResponseDto>> GetOne(Guid id)
        {
            var company = await _service.GetOne(id);
            return company is null ? NotFound() : Ok(company);
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var company = await _service.CreateCompany(dto);
            return CreatedAtAction(nameof(GetOne), new { id = company.CompanyId }, company);
        }

        [HttpPut("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<CompanyResponseDto>> UpdateCompany([FromBody] UpdateCompanyDto dto, Guid id)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var updated = await _service.UpdateCompany(dto, id);
            return Ok(updated);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            await _service.DeleteCompany(id);
            return NoContent();
        }
    }
}
