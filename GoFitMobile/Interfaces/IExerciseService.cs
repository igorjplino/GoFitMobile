using GoFitMobile.Models;

namespace GoFitMobile.Interfaces;
public interface IExerciseService
{
    Task<List<Exercise>> GetExerciseListAsync();
}
