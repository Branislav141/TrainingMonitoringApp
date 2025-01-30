using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TrainingMonitoringAppBackend.Application.Interfaces
{
    public interface ICurrentUserService
    {
        Task<IdentityUser?> GetLoggedInUserAsync(ClaimsPrincipal userPrincipal);
    }
}
