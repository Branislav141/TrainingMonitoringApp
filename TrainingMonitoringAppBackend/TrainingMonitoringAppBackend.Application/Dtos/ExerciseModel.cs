using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingMonitoringAppBackend.Domain.Entities;

namespace TrainingMonitoringAppBackend.Application.Dtos
{
    public class Exercise
    {
        public int Id { get; set; }
        public string ExerciseName { get; set; }
        public double Duration { get; set; }
        public double CaloriesBurned { get; set; }
        public string ExerciseType { get; set; }

    }

}
