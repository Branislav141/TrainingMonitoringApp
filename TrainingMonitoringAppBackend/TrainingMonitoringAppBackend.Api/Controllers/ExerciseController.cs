using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TrainingMonitoringAppBackend.Application.Dtos;
using TrainingMonitoringAppBackend.Application.Interfaces;
using TrainingMonitoringAppBackend.Domain.Entities;
using ExerciseModel = TrainingMonitoringAppBackend.Application.Dtos.Exercise;
using Exercise = TrainingMonitoringAppBackend.Domain.Entities.Exercise;

namespace TrainingMonitoringAppBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }



        [HttpGet("all")]
        public async Task<IActionResult> GetAllExercises()
        {
            var exercises = await _exerciseService.GetAllExercisesAsync();
            if (exercises == null || exercises.Count == 0)
            {
                return NotFound("No exercises found.");
            }

            return Ok(exercises);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddExercise([FromBody] ExerciseModel exerciseModel)
        {
            if (exerciseModel == null)
            {
                return BadRequest("Invalid exercise data.");
            }

            var exercise = new Exercise
            {
                ExerciseName = exerciseModel.ExerciseName,
                ExerciseType = exerciseModel.ExerciseType,
                Duration = exerciseModel.Duration,
                CaloriesBurned = exerciseModel.CaloriesBurned
            };

            await _exerciseService.AddExerciseAsync(exercise);

            return Ok(exercise);
        }



    }
}
