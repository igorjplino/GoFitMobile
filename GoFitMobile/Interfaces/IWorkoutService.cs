using GoFitMobile.Models;

namespace GoFitMobile.Interfaces;
public interface IWorkoutService
{
    Task<List<WorkoutPlan>> ListWorkoutPlansByAthletIdAsync(Guid id);
}
