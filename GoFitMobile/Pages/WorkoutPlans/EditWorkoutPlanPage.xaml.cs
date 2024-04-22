using GoFitMobile.ViewModel;

namespace GoFitMobile.Pages.WorkoutPlans;

public partial class EditWorkoutPlanPage : ContentPage
{
	public EditWorkoutPlanPage(EditWorkoutPlanViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}