using GoFitMobile.ViewModel;

namespace GoFitMobile.Pages.WorkoutPlans;

public partial class CreateWorkoutPlanPage : ContentPage
{
	public CreateWorkoutPlanPage(CreateWorkoutPlanViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}