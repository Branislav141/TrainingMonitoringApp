using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingMonitoringAppBackend.Domain.Entities;

namespace TrainingMonitoringAppBackend.Application.Interfaces
{
    public interface IExerciseService
    {
       
        Task AddExerciseAsync(Exercise exercise);
        Task<List<Exercise>> GetAllExercisesAsync();
    }



}
