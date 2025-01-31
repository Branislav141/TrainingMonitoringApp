using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingMonitoringAppBackend.Application.Interfaces;
using TrainingMonitoringAppBackend.Domain.Entities;
using TrainingMonitoringAppBackend.Infrastructure.Data;

namespace TrainingMonitoringAppBackend.Infrastructure.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly TrainingDbContext _context;

        public ExerciseRepository(TrainingDbContext context)
        {
            _context = context;
        }



        public async Task AddExerciseAsync(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();  
        }
        public async Task<List<Exercise>> GetAllExercisesAsync()
        {
            return await _context.Exercises.ToListAsync();
        }



    }


}
