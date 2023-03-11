using MovieManiaq.ViewModel.Search;

namespace MovieManiaq.View.Search;

public partial class SearchPeoplePage : ContentPage
{
	private readonly SearchPeopleViewModel _searchViewModel;

	public SearchPeoplePage()
	{
		InitializeComponent();
		_searchViewModel = new SearchPeopleViewModel(Navigation);
		BindingContext = _searchViewModel;
	}

    private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
		_searchViewModel.PeopleSearch(sender);
    }

    private void NextPage_Pressed(object sender, EventArgs e)
    {
        _searchViewModel.NextPage();
    }

    private void PreviousPage_Pressed(object sender, EventArgs e)
    {
        _searchViewModel.PreviousPage();
    }

    private void PeopleResult_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _searchViewModel.PeopleSelection(e);
    }
}