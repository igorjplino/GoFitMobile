using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoFitMobile.Interfaces;
using GoFitMobile.Models;
using GoFitMobile.Pages.WorkoutPlans;
using System.Collections.ObjectModel;

namespace GoFitMobile.ViewModel;
public partial class WorkoutPlanViewModel : ObservableObject
{
    private readonly IWorkoutPlanService _workoutPlanService;

    [ObservableProperty]
    ObservableCollection<WorkoutPlan> workoutPlans;

    public WorkoutPlanViewModel(IWorkoutPlanService workoutPlanService)
    {
        _workoutPlanService = workoutPlanService;

        workoutPlans = [];
    }

    [RelayCommand]
    async Task LoadWorkoutPlans()
    {
        var id = new Guid("d2d86d97-3f2c-4eb9-b979-c1937b212412");

        var workoutPlans = await _workoutPlanService.ListWorkoutPlansByAthletIdAsync(id);

        WorkoutPlans = new ObservableCollection<WorkoutPlan>(workoutPlans);
    }

    [RelayCommand]
    async Task GoToCreateWorkoutPlan()
    {
        await Shell.Current.GoToAsync(nameof(CreateWorkoutPlanPage));
    }

    [RelayCommand]
    async Task GoToEditWorkoutPlan(WorkoutPlan workoutPlan)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "WorkoutPlan", workoutPlan }
        };

        await Shell.Current.GoToAsync(nameof(EditWorkoutPlanPage), navigationParameter);
    }
}
