using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingMonitoringAppBackend.Domain.Entities
{
    public class Training
    {
        public int Id { get; set; }
        public string Type { get; set; } 
        public TimeSpan Duration { get; set; } 
        public double CaloriesBurned { get; set; } 
        public int TrainingIntensity { get; set; } 
        public int Fatigue { get; set; } 
        public string Notes { get; set; } 
        public DateTime DateTime { get; set; } 

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
