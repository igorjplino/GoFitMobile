using GoFitMobile.ViewModel;

namespace GoFitMobile.Pages.WorkoutPlans;

public partial class AddExerciseToWorkoutPage : ContentPage
{
	public AddExerciseToWorkoutPage(AddExerciseToWorkoutViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}