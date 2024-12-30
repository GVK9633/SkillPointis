using Application.Interface;
using Core.Interface;
using Core.Models.DataTransferObject.User;
using Core.Models.Domain;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        public UserService(IUserRepository userRepository,IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }
        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await _userRepository.GetUserAsync();
        }

        public async Task<UserDto> CreateUserAsync(UserRequestDto userRequest)
        {
            var token = Guid.NewGuid().ToString();
            var user = new User 
            {   Username = userRequest.Username, 
                Email = userRequest.Email, 
                Password = userRequest.Password, 
                EmailConfirmed = false, 
                ActiveUser = false,
                ConfirmationToken = token
            }; 
            await _userRepository.CreateUserAsync(user);
            var confirmationLink = $"https://localhost:7264/api/users/confirm?token={token}";
            await _emailService.SendEmailAsync(userRequest.Email, "Verify Your Email", $"Please click the link to verify your email : {confirmationLink}");
            return new UserDto 
            { 
                Username = user.Username, 
                Email = user.Email 
            };
        }

        public async Task<UserDetailsDto> GetUserByTokenAsync(string token)
        {
            var data = await _userRepository.GetUserByTokenAsync(token);
            return new UserDetailsDto
            {
                Username = data.Username,
                Email = data.Email,
                Password = data.Password,
                EmailConfirmed = data.EmailConfirmed,
                ActiveUser = data.ActiveUser,
                ConfirmationToken = data.ConfirmationToken,
            };
        }

        public async Task UpdateUserAsync(UserDetailsDto user)
        {
            var userDetail = new User
            {
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                EmailConfirmed = true,
                ActiveUser = true,
                ConfirmationToken = "",    // Clear the token
            };
            await _userRepository.UpdateUserAsync(userDetail);
        }
    }
}
