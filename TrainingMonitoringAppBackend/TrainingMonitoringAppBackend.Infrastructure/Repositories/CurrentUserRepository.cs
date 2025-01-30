using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TrainingMonitoringAppBackend.Domain.Entities;
using TrainingMonitoringAppBackend.Domain.Interfaces;

namespace TrainingMonitoringAppBackend.Infrastructure.Repositories
{
    public class CurrentUserRepository : ICurrentUserRepository
    {
        private readonly UserManager<User> _userManager;  

        public CurrentUserRepository(UserManager<User> userManager)  
        {
            _userManager = userManager;
        }

        public async Task<User?> GetLoggedInUserAsync(ClaimsPrincipal userPrincipal)
        {
            return await _userManager.GetUserAsync(userPrincipal);  
        }
    }
}
