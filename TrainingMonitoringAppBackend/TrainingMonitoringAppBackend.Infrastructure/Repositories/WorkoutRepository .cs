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
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly TrainingDbContext _context;

        public WorkoutRepository(TrainingDbContext context)
        {
            _context = context;
        }

        
    }


}
