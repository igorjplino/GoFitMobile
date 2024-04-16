using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoFitMobile.Models;
using GoFitMobile.Pages.WorkoutPlans;
using System.Collections.ObjectModel;

namespace GoFitMobile.ViewModel;

public partial class CreateWorkoutViewModel : ObservableObject, IQueryAttributable
{
    [ObservableProperty]
    string name;

    [ObservableProperty]
    ObservableCollection<WorkoutExercise> newWorkoutExercises;

    [ObservableProperty]
    ObservableCollection<WorkoutExercise> workoutExercises;

    public CreateWorkoutViewModel()
    {
        WorkoutExercises = new();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("NewWorkoutExercises", out object? value) && value is List<WorkoutExercise> exercises)
        {
            foreach (var exercise in exercises)
            {
                WorkoutExercises.Add(exercise);
            }
        }
    }

    [RelayCommand]
    async Task GoToAddExercise()
    {
        try
        {
            List<Guid> alreadyAddedExercisesId = WorkoutExercises.Select(x => x.ExerciseId).ToList();

            var navigationParameter = new Dictionary<string, object>
            {
                { "AlreadyAddedExercisesId", alreadyAddedExercisesId }
            };

            await Shell.Current.GoToAsync($"{nameof(AddExerciseToWorkoutPage)}", navigationParameter);
        }
        catch (Exception ex)
        {

        }
        
    }

    [RelayCommand]
    void LoadNewWorkoutExercises()
    {
        //if (NewWorkoutExercises is not null)
        //{
        //    foreach (var exercise in NewWorkoutExercises)
        //    {
        //        WorkoutExercises.Add(exercise);
        //    }
        //}
    }

    [RelayCommand]
    async Task Save()
    {
        var workout = new Workout
        {
            Name = Name,
            Description = "Testeeee",
            WorkoutExercises = WorkoutExercises.ToList()
        };

        var navigationParameter = new Dictionary<string, object>
        {
            { "NewWorkout", workout }
        };

        await Shell.Current.GoToAsync($"{nameof(CreateWorkoutPlanPage)}", navigationParameter);
    }
}
