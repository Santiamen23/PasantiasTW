using Microsoft.EntityFrameworkCore;
using PasantiasTW.Data;
using PasantiasTW.Models;

namespace PasantiasTW.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _db;
        public CompanyRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task Add(Company company)
        {
            await _db.Companies.AddAsync(company);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Company company)
        {
            _db.Companies.Remove(company);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _db.Companies.ToListAsync();
        }

        public async Task<Company?> GetOne(Guid id)
        {
            return await _db.Companies.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task Update(Company company)
        {
            _db.Companies.Update(company);
            await _db.SaveChangesAsync();
        }
    }
}
