using PasantiasTW.Models;
using PasantiasTW.Models.Dtos;
using PasantiasTW.Repositories.Services;

namespace PasantiasTW.Services
{
    public class PracticeService : IPracticeService
    {
        private readonly IPracticeRepository _repo;
        private readonly IStudentRepository _studentRepository; 
        private readonly ICompanyRepository _companyRepository; 

        public PracticeService(
            IPracticeRepository repo,
            IStudentRepository studentRepository,
            ICompanyRepository companyRepository)
        {
            _repo = repo;
            _studentRepository = studentRepository;
            _companyRepository = companyRepository;
        }

        private PracticeResponseDto MapToDto(Practice practice)
        {
            return new PracticeResponseDto
            {
                PracticeId = practice.PracticeId,
                StartDate = practice.StartDate,
                EndDate = practice.EndDate,
                Status = practice.Status,
                Student = new StudentReferenceDto 
                {
                    StudentId = practice.Student.ID,
                    Name = practice.Student.Name,
                    Career = practice.Student.Career 
                },
                Company = new CompanyReferenceDto
                {
                    CompanyId = practice.Company.ID, 
                    Name = practice.Company.Name
                }
            };
        }

        public async Task<PracticeResponseDto> Create(CreatePracticeDto dto)
        {
            var student = await _studentRepository.GetOne(dto.StudentId);
            if (student is null) throw new Exception("Student not found");

            var company = await _companyRepository.GetOne(dto.CompanyId);
            if (company is null) throw new Exception("Company not found");

            var practice = new Practice
            {
                StudentId = dto.StudentId,
                CompanyId = dto.CompanyId,
                StartDate = dto.StartDate,
                Status = dto.Status ?? "Pending", 
                Student = student, 
                Company = company 
            };

            await _repo.Create(practice);

            return MapToDto(practice);
        }

        public async Task Delete(Guid id)
        {
            var practice = await _repo.GetById(id);
            if (practice == null) throw new Exception("Practice not found");
            await _repo.Delete(practice);
        }

        public async Task<IEnumerable<PracticeResponseDto>> GetAll()
        {
            var practiceEntities = await _repo.GetAll();
            return practiceEntities.Select(MapToDto).ToList();
        }

        public async Task<PracticeResponseDto?> GetById(Guid id)
        {
            var practice = await _repo.GetById(id);
            if (practice == null) return null;
            return MapToDto(practice);
        }

        public async Task<PracticeResponseDto?> Update(Guid id, UpdatePracticeDto dto)
        {
            Practice? practice = await _repo.GetById(id);
            if (practice == null) return null;

            practice.EndDate = dto.EndDate;
            practice.Status = dto.Status;

            await _repo.Update(practice);
            return MapToDto(practice);
        }
    }
}