using GoFitMobile.ViewModel;

namespace GoFitMobile.Pages;

public partial class WorkoutPlansPage : ContentPage
{
    public WorkoutPlansPage(WorkoutPlanViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}