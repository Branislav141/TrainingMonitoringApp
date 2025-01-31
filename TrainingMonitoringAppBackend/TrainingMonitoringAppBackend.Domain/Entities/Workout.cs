using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingMonitoringAppBackend.Domain.Entities
{
    public class Workout
    {
        public int Id { get; set; }
        public string UserId { get; set; } 
        public List<Exercise> Exercises { get; set; }
        public int Intensity { get; set; }  
        public int FatigueLevel { get; set; }  
        public string Notes { get; set; }  
        public DateTime WorkoutDate{ get; set; }  
    }
}
