using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoFitMobile.Interfaces;
using GoFitMobile.Models;
using GoFitMobile.Pages;
using System.Collections.ObjectModel;

namespace GoFitMobile.ViewModel;

[QueryProperty("WorkoutPlan", "WorkoutPlan")]
public partial class EditWorkoutPlanViewModel : ObservableObject, IQueryAttributable
{
    readonly IWorkoutPlanService _workoutPlanService;

    [ObservableProperty]
    WorkoutPlan workoutPlan;

    [ObservableProperty]
    ObservableCollection<Workout> workouts;


    public EditWorkoutPlanViewModel(IWorkoutPlanService workoutPlanService)
    {
        _workoutPlanService = workoutPlanService;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("NewWorkoutExercises", out object? value) && value is WorkoutPlan workoutPlan)
        {
            WorkoutPlan = workoutPlan;
        }
    }

    [RelayCommand]
    async Task LoadWorkouts()
    {
        var workoutPlan = await _workoutPlanService.GetWortkoutPlanByIdAsync(WorkoutPlan.Id);

        if (workoutPlan is not null)
        {
            Workouts = new ObservableCollection<Workout>(workoutPlan.Workouts);
        }
    }

    [RelayCommand]
    async Task Save()
    {
        //await _workoutService.CreateNewWorkoutPlanAsync(WorkoutPlan);

        await Shell.Current.GoToAsync(nameof(WorkoutPlansPage));
    }
}
