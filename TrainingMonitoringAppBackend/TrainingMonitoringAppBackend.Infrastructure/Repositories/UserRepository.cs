using Microsoft.AspNetCore.Identity;
using System;
using System.Text;
using System.Threading.Tasks;
using TrainingMonitoringAppBackend.Domain.Entities;
using TrainingMonitoringAppBackend.Domain.Interfaces;

namespace TrainingMonitoringAppBackend.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task AddAsync(User user)
        {
            user.UserName = user.Email;
            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    sb.AppendLine(error.Description); 
                }
                throw new Exception($"User creation failed. Errors: {sb.ToString()}"); 
            }
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
    }
}
