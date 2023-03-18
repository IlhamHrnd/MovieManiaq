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

    private void Trending_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
    {
		_mainViewModel.TrendingSelection(sender);
    }

    private void Trending_Tapped(object sender, TappedEventArgs e)
    {
		_mainViewModel.TrendingCommand();
    }

	private void NowShowing_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
	{
		_mainViewModel.NowShowingSelection(sender);
	}

	private void NowShowing_Tapped(object sender, TappedEventArgs e)
	{
		_mainViewModel.NowShowingCommand();
	}

	private void UpComing_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
	{
		_mainViewModel.UpCoomingSelection(sender);
	}

	private void UpComing_Tapped(object sender, TappedEventArgs e)
	{
		_mainViewModel.UpComingCommand();
	}

	private void TopRated_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
	{
		_mainViewModel.TopRatedSelection(sender);
	}

	private void TopRated_Tapped(object sender, TappedEventArgs e)
	{
		_mainViewModel.TopRatedCommand();
	}

    private void Popular_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
    {
        _mainViewModel.PopularSelection(sender);
    }

    private void Popular_Tapped(object sender, TappedEventArgs e)
    {
        _mainViewModel.PopularCommand();
    }
}