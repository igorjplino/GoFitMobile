using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoFitMobile.Interfaces;
using GoFitMobile.Models;
using GoFitMobile.Pages;
using GoFitMobile.Pages.WorkoutPlans;
using System.Collections.ObjectModel;

namespace GoFitMobile.ViewModel;

[QueryProperty("NewWorkout", "NewWorkout")]
public partial class CreateWorkoutPlanViewModel : ObservableObject
{
    readonly IWorkoutPlanService _workoutPlanService;

    [ObservableProperty]
    string title;

    [ObservableProperty]
    string description;

    [ObservableProperty]
    Workout newWorkout;

    [ObservableProperty]
    ObservableCollection<Workout> workouts;

    public CreateWorkoutPlanViewModel(IWorkoutPlanService workoutPlanService)
    {
        _workoutPlanService = workoutPlanService;

        Workouts = new ObservableCollection<Workout>();
    }

    [RelayCommand]
    void LoadWorkouts()
    {
        if (NewWorkout is not null)
        {
            Workouts.Add(NewWorkout);
        }
    }

    [RelayCommand]
    async Task GoToAddWorkout()
    {
        await Shell.Current.GoToAsync(nameof(CreateWorkoutPage));
    }

    [RelayCommand]
    async Task Save()
    {
        var workoutPlan = new WorkoutPlan
        {
            AthleteId = new Guid("d2d86d97-3f2c-4eb9-b979-c1937b212412"),
            Title = Title,
            Description = Description,
            Workouts = Workouts.ToList()
        };

        await _workoutPlanService.CreateNewWorkoutPlanAsync(workoutPlan);

        await Shell.Current.GoToAsync(nameof(WorkoutPlansPage));
    }
}
