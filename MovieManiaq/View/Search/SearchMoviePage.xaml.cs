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

    private void MovieResult_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		_searchViewModel.MovieSelection(e);
    }

    private void NextPage_Pressed(object sender, EventArgs e)
    {
        _searchViewModel.NextPage();
    }

    private void PreviousPage_Pressed(object sender, EventArgs e)
    {
        _searchViewModel.PreviousPage();
    }
}