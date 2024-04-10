using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoFitMobile.Models;
using GoFitMobile.Pages.WorkoutPlans;

namespace GoFitMobile.ViewModel;

public partial class CreateWorkoutViewModel : ObservableObject
{
    [ObservableProperty]
    string name;

    [RelayCommand]
    async Task Save()
    {
        var workout = new Workout
        {
            Name = Name,
            Description = "Testeeee",
            Order = 0,
            WorkoutExercises = new List<WorkoutExercise>
            {
                new WorkoutExercise
                {
                    ExerciseId = new Guid("17e5b542-e5a3-4f50-8a67-0ee42330ff0c"),
                    Order = 0,
                    Sets = new List<WorkoutSet>
                    {
                        new WorkoutSet
                        {
                            Order = 0
                        }
                    }
                }
            }
        };

        var navigationParameter = new Dictionary<string, object>
        {
            { "NewWorkout", workout }
        };

        await Shell.Current.GoToAsync($"{nameof(CreateWorkoutPlanPage)}", navigationParameter);
    }
}
