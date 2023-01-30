using MovieManiaq.ViewModel.Detail;

namespace MovieManiaq.View.Detail;

public partial class DetailMoviePage : ContentPage
{
	private readonly DetailMovieViewModel _detailViewModel;

    public DetailMoviePage(int MovieID)
	{
		InitializeComponent();
		_detailViewModel = new DetailMovieViewModel(Navigation, MovieID);
		BindingContext = _detailViewModel;
	}
}