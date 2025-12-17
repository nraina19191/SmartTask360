using Microsoft.EntityFrameworkCore;
using SmartTask.UserService.Application;
using SmartTask.UserService.Domain;

namespace SmartTask.UserService.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(User item)
        {
            var result = await _context.Users.AddAsync(item);
            return result.Entity.Id;
        }

        public void Delete(User item)
        {
            _context.Users.Remove(item);
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void Update(User item)
        {
            _context.Users.Update(item);
        }
    }
}
