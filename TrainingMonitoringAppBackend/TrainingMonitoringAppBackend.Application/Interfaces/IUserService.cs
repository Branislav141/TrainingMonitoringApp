using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingMonitoringAppBackend.Application.Dtos;

namespace TrainingMonitoringAppBackend.Application.Interfaces
{
    public interface IUserService
    {
        Task RegisterUserAsync(RegisterModel model);
        Task<string> LoginUserAsync(LoginModel model);
    }
}
