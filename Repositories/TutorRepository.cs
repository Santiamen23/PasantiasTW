using Microsoft.EntityFrameworkCore;
using PasantiasTW.Data;
using PasantiasTW.Models;

namespace PasantiasTW.Repositories
{
    public class TutorRepository : ITutorRepository
    {
        private readonly AppDbContext _context;

        public TutorRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task create(Tutor tutor)
        {
            await _context.Tutors.AddAsync(tutor);
            await _context.SaveChangesAsync();
        }

        public async Task delete(Tutor tutor)
        {
            _context.Tutors.Remove(tutor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tutor>> getAll()
        {
            return await _context.Tutors.Include(t=>t.Company).ToListAsync();
        }

        public async Task<Tutor?> getById(Guid id)
        {
            return await _context.Tutors.Include(t=>t.Company).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task update(Tutor tutor)
        {
            _context.Tutors.Update(tutor);
            await _context.SaveChangesAsync();
        }
    }
}
