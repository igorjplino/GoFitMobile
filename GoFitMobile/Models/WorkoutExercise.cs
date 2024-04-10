namespace GoFitMobile.Models;

public class WorkoutExercise
{
    public Guid ExerciseId { get; set; }
    public int Order { get; set; }
    public List<WorkoutSet> Sets { get; set; } = [];
}
