using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TrainingMonitoringAppBackend.Domain.Entities;

namespace TrainingMonitoringAppBackend.Domain.Interfaces
{
    public interface ICurrentUserRepository
    {
        Task<User?> GetLoggedInUserAsync(ClaimsPrincipal userPrincipal);  
    }
}
