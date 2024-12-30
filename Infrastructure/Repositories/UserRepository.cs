using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interface;
using Core.Models.DataTransferObject.User;
using Core.Models.Domain;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> CreateUserAsync(User user)
        {
            await _dbContext.user.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetUserAsync()
        {
            return await _dbContext.user.ToListAsync();
        }

        public async Task<User> GetUserByTokenAsync(string token)
        {
            return await _dbContext.user.FirstOrDefaultAsync(x => x.ConfirmationToken == token);
        }

        public async Task UpdateUserAsync(User user)
        {
            _dbContext.user.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
