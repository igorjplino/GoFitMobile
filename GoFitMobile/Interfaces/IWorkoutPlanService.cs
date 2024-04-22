using GoFitMobile.Models;

namespace GoFitMobile.Interfaces;
public interface IWorkoutPlanService
{
    Task CreateNewWorkoutPlanAsync(WorkoutPlan workoutPlan);
    Task<List<WorkoutPlan>> ListWorkoutPlansByAthletIdAsync(Guid id);
    Task<WorkoutPlan?> GetWortkoutPlanByIdAsync(Guid id);
}
