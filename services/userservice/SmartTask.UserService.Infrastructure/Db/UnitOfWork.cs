using SmartTask.UserService.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTask.UserService.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserDbContext _userDbContext;

        public UnitOfWork(UserDbContext userDbContext, IUserRepository users)
        {
            _userDbContext = userDbContext;
            Users = users;
        }

        public IUserRepository Users { get; set; }

        public void Dispose()
        {
            _userDbContext.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _userDbContext.SaveChangesAsync();
        }
    }
}
