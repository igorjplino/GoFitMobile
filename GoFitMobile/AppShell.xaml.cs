using GoFitMobile.Pages;
using GoFitMobile.Pages.WorkoutPlans;

namespace GoFitMobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(WorkoutPlansPage), typeof(WorkoutPlansPage));
        Routing.RegisterRoute(nameof(CreateWorkoutPlanPage), typeof(CreateWorkoutPlanPage));
        Routing.RegisterRoute(nameof(CreateWorkoutPage), typeof(CreateWorkoutPage));
        Routing.RegisterRoute(nameof(AddExerciseToWorkoutPage), typeof(AddExerciseToWorkoutPage));
    }
}
