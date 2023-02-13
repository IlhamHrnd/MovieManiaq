using MovieManiaq.Model.Response.Movie;
using MovieManiaq.ViewModel.Search;
using static MovieManiaq.Model.Response.Movie.SearchModel;

namespace MovieManiaq.View.Search;

public partial class SearchMoviePage : ContentPage
{
	private readonly SearchMovieViewModel _searchViewModel;

	public SearchMoviePage()
	{
		InitializeComponent();
		_searchViewModel = new SearchMovieViewModel(Navigation);
		BindingContext	= _searchViewModel;
	}

    private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
		_searchViewModel.MovieSearch(sender);
    }
}