using GoFitMobile.ViewModel;

namespace GoFitMobile.Pages.WorkoutPlans;

public partial class CreateWorkoutPage : ContentPage
{
	public CreateWorkoutPage(CreateWorkoutViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}