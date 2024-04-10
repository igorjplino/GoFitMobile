using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoFitMobile.Interfaces;
using GoFitMobile.Models;
using GoFitMobile.Pages.WorkoutPlans;
using System.Collections.ObjectModel;

namespace GoFitMobile.ViewModel;
public partial class WorkoutPlanViewModel : ObservableObject
{
    private readonly IWorkoutService _workoutService;

    [ObservableProperty]
    ObservableCollection<WorkoutPlan> workoutPlans;

    public WorkoutPlanViewModel(IWorkoutService workoutService)
    {
        _workoutService = workoutService;

        workoutPlans = [];
    }

    [RelayCommand]
    async Task LoadWorkoutPlans()
    {
        var id = new Guid("d2d86d97-3f2c-4eb9-b979-c1937b212412");

        WorkoutPlans = new ObservableCollection<WorkoutPlan>(await _workoutService.ListWorkoutPlansByAthletIdAsync(id));
    }

    [RelayCommand]
    async Task GoToCreateWorkoutPlan()
    {
        await Shell.Current.GoToAsync(nameof(CreateWorkoutPlanPage));
    }
}
