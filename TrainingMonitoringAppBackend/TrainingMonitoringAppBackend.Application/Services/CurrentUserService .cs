using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TrainingMonitoringAppBackend.Application.Interfaces;
using TrainingMonitoringAppBackend.Domain.Interfaces;

namespace TrainingMonitoringAppBackend.Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly ICurrentUserRepository _currentUserRepository;

        public CurrentUserService(ICurrentUserRepository currentUserRepository)
        {
            _currentUserRepository = currentUserRepository;
        }

        public async Task<IdentityUser?> GetLoggedInUserAsync(ClaimsPrincipal userPrincipal)
        {
            return await _currentUserRepository.GetLoggedInUserAsync(userPrincipal);
        }
    }
}
