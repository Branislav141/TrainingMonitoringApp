using TrainingMonitoringAppBackend.Application.Dtos;
using TrainingMonitoringAppBackend.Application.Interfaces;
using TrainingMonitoringAppBackend.Domain.Entities;
using TrainingMonitoringAppBackend.Domain.Interfaces;
using System;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography;

namespace TrainingMonitoringAppBackend.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtTokenService _jwtTokenService;

        public UserService(IUserRepository userRepository, JwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
        }

        public async Task RegisterUserAsync(RegisterModel registrationModel)
        {
            var existingUser = await _userRepository.GetByEmailAsync(registrationModel.Email);
            if (existingUser != null)
            {
                throw new Exception("User already exists with this email.");
            }

            var passwordHash = HashPassword(registrationModel.Password);

            var user = new User
            {
                FirstName = registrationModel.FirstName,
                LastName = registrationModel.LastName,
                Email = registrationModel.Email,
                PasswordHash = passwordHash,
                Gender = registrationModel.Gender,
            };

            await _userRepository.AddAsync(user);
        }

        public async Task<string> LoginUserAsync(LoginModel loginModel)
        {
            var user = await _userRepository.GetByEmailAsync(loginModel.Email);
            if (user == null || user.PasswordHash != HashPassword(loginModel.Password))
            {
                throw new Exception("Invalid email or password.");
            }

            
            return _jwtTokenService.GenerateJwtToken(user.Id, user.Email);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
