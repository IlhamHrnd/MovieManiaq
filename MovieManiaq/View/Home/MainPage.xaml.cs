using MovieManiaq.ViewModel.Home;

namespace MovieManiaq.View.Home;

public partial class MainPage : ContentPage
{
	private readonly MainViewModel _mainViewModel;

	public MainPage()
	{
		InitializeComponent();
		_mainViewModel = new MainViewModel(Navigation);
		BindingContext	= _mainViewModel;
	}
}