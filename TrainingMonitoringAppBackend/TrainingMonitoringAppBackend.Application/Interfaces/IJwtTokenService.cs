using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingMonitoringAppBackend.Application.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateJwtToken(string userId, string email);
    }
}
