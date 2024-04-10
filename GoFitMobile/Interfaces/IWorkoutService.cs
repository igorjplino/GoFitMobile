using GoFitMobile.Models;

namespace GoFitMobile.Interfaces;
public interface IWorkoutService
{
    Task CreateNewWorkoutPlanAsync(WorkoutPlan workoutPlan);
    Task<List<WorkoutPlan>> ListWorkoutPlansByAthletIdAsync(Guid id);
}
