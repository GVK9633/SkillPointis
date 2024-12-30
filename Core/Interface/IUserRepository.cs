using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.DataTransferObject.User;
using Core.Models.Domain;

namespace Core.Interface
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<IEnumerable<User>> GetUserAsync();
        Task<User> GetUserByTokenAsync(string token);
        Task UpdateUserAsync(User user);

    }
}
