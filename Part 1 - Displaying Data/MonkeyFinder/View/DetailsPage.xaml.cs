namespace MonkeyFinder;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(MonkeyDetailsViewModel monkeyDetailsVM)
	{
		InitializeComponent();
		BindingContext = monkeyDetailsVM;
	}
}