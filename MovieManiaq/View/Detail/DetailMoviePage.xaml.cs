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

    private void Recommendations_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		_detailViewModel.RecommendationsSelection(e);
    }

    private void Similiar_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		_detailViewModel.SimiliarSelection(e);
	}
}