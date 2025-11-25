using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PasantiasTW.Models;
using PasantiasTW.Models.Dtos;
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
        public async Task<IActionResult> GetAllCompanies()
        {
            IEnumerable<Company> items = await _service.GetAll();
            return Ok(items);
        }
        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var company = await _service.GetOne(id);
            return Ok(company);
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var company = await _service.CreateCompany(dto);
            return CreatedAtAction(nameof(GetOne), new { id = company.ID }, company);
        }

        [HttpPut("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> UpdateCompany([FromBody] UpdateCompanyDto dto, Guid id)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var company = await _service.UpdateCompany(dto, id);
            return CreatedAtAction(nameof(GetOne), new { id = company.ID }, company);
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
