using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.DataTransferObject.User;
using Core.Models.Domain;

namespace Application.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<UserDto> CreateUserAsync(UserRequestDto userRequest);
        Task<UserDetailsDto> GetUserByTokenAsync(string token);
        Task UpdateUserAsync(UserDetailsDto user);
    }
}
