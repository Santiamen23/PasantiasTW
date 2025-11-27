using Microsoft.EntityFrameworkCore;
using PasantiasTW.Data;
using PasantiasTW.Models;
using PasantiasTW.Repositories;
using PasantiasTW.Repositories.Interfaces;

namespace PasantiasTW.Repositories
{
    public class PracticeRepository : IPracticeRepository 
    {
        private readonly AppDbContext _context;

        public PracticeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Practice practice)
        {
            await _context.Practices.AddAsync(practice);
            bool exists = await _context.StudentsCompanies
                .AnyAsync(sc =>
                    sc.StudentID == practice.StudentId &&
                    sc.CompanyID == practice.CompanyId);
            if (!exists)
            {
                var sc = new StudentCompany
                {
                    StudentID = practice.StudentId,
                    CompanyID = practice.CompanyId
                };
                await _context.StudentsCompanies.AddAsync(sc);
            }
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Practice practice)
        {
            _context.Practices.Remove(practice);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Practice>> GetAll()
        {
            return await _context.Practices
                .Include(p => p.Student)
                .Include(p => p.Company)
                .ToListAsync();
        }

        public async Task<Practice?> GetById(Guid id)
        {
            return await _context.Practices
                .Include(p => p.Student)
                .Include(p => p.Company)
                .FirstOrDefaultAsync(p => p.PracticeId == id);
        }

        public async Task Update(Practice practice)
        {
            _context.Practices.Update(practice);
            await _context.SaveChangesAsync();
        }
    }
}