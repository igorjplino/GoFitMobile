namespace GoFitMobile.Models;

public class Workout
{ 
    public string Name { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    public List<WorkoutExercise> WorkoutExercises { get; set; } = [];
}
