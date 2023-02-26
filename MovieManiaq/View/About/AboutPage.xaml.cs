using MovieManiaq.ViewModel.About;

namespace MovieManiaq.View.About;

public partial class AboutPage : ContentPage
{
	private readonly AboutViewModel _aboutViewModel;

	public AboutPage()
	{
		InitializeComponent();
		_aboutViewModel = new AboutViewModel();
		BindingContext = _aboutViewModel;
	}
}