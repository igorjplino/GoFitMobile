namespace GoFitMobile.Models;
public class WorkoutPlan
{
    public Guid AthleteId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public List<Workout> Workouts { get; set; } = [];
}
