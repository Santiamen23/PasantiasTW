using Microsoft.EntityFrameworkCore;
using PasantiasTW.Data;
using PasantiasTW.Models;

namespace PasantiasTW.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) { _context = context; }

        public Task<User?> GetByEmailAddress(string email) =>
            _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public Task<User?> GetByRefreshToken(string refreshToken) =>
            _context.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
