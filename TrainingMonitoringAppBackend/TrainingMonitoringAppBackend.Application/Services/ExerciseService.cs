using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingMonitoringAppBackend.Application.Interfaces;
using TrainingMonitoringAppBackend.Domain.Entities;

namespace TrainingMonitoringAppBackend.Application.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task AddExerciseAsync(Exercise exercise)
        {
            await _exerciseRepository.AddExerciseAsync(exercise);
        }

        public async Task<List<Exercise>> GetAllExercisesAsync()
        {
            return await _exerciseRepository.GetAllExercisesAsync();
        }


    }

}
