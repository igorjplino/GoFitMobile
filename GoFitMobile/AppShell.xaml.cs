using GoFitMobile.Pages.WorkoutPlans;

namespace GoFitMobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(CreateWorkoutPlanPage), typeof(CreateWorkoutPlanPage));
    }
}
