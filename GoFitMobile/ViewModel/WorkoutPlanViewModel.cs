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
        var id = new Guid("36251202-61be-46c6-b8f9-dc30cc80fc31");

        WorkoutPlans = new ObservableCollection<WorkoutPlan>(await _workoutService.ListWorkoutPlansByAthletIdAsync(id));
    }

    [RelayCommand]
    async Task GoToCreateWorkoutPlan()
    {
        await Shell.Current.GoToAsync(nameof(CreateWorkoutPlanPage));
    }
}
