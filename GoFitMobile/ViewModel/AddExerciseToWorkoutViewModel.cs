using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoFitMobile.Interfaces;
using GoFitMobile.Models;
using GoFitMobile.Pages.WorkoutPlans;
using System.Collections.ObjectModel;

namespace GoFitMobile.ViewModel;
public partial class AddExerciseToWorkoutViewModel : ObservableObject, IQueryAttributable
{
    private readonly IExerciseService _exerciseService;

    private readonly List<WorkoutSet> _globalWorkoutSets;
    private List<Guid> AlreadyAddedExercisesId;

    [ObservableProperty]
    ObservableCollection<Exercise> exercises;

    [ObservableProperty]
    ObservableCollection<object> selectedExercises;

    public AddExerciseToWorkoutViewModel(IExerciseService exerciseService)
    {
        _exerciseService = exerciseService;

        _globalWorkoutSets = new List<WorkoutSet>
        {
            new WorkoutSet
            {
                WarmUp = false,
                MaxRepetitions = 0,
                MinRepetitions = 0,
                ResetTime = 60,
            },
            new WorkoutSet
            {
                WarmUp = false,
                MaxRepetitions = 0,
                MinRepetitions = 0,
                ResetTime = 60,
            },
            new WorkoutSet
            {
                WarmUp = false,
                MaxRepetitions = 0,
                MinRepetitions = 0,
                ResetTime = 60,
            }
        };

        SelectedExercises = [];
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("AlreadyAddedExercisesId", out object? value) && value is List<Guid> exercisesId)
        {
            AlreadyAddedExercisesId = exercisesId;
        }
    }

    [RelayCommand]
    async Task LoadExercises()
    {
        var exercises = await _exerciseService.GetExerciseListAsync();

        Exercises = new ObservableCollection<Exercise>(exercises.Where(CheckAlreadyAddedExercise));
    }
    
    [RelayCommand]
    async Task AddExersises()
    {
        var workoutExercises = new List<WorkoutExercise>(SelectedExercises.Count);

        for (int i = 0; i < SelectedExercises.Count; i++)
        {
            var exercise = (Exercise) SelectedExercises[i];

            if (!AlreadyAddedExercisesId.Any(x => x == exercise.Id))
            {
                workoutExercises.Add(new WorkoutExercise
                {
                    ExerciseId = exercise.Id,
                    Name = exercise.Name,
                    Order = i,
                    Sets = _globalWorkoutSets,
                });
            }
        }

        var navigationParameter = new Dictionary<string, object>
        {
            { "NewWorkoutExercises", workoutExercises }
        };

        await Shell.Current.GoToAsync($"{nameof(CreateWorkoutPage)}", navigationParameter);
    }

    bool CheckAlreadyAddedExercise(Exercise exercise)
    {
        return !AlreadyAddedExercisesId.Any(x => x == exercise.Id);
    }
}
