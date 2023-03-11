using MovieManiaq.ViewModel.Home;

namespace MovieManiaq.View.Home;

public partial class PeoplePage : ContentPage
{
	private readonly PeopleViewModel _peopleViewModel;
	public PeoplePage()
	{
		InitializeComponent();
		_peopleViewModel = new PeopleViewModel(Navigation);
		BindingContext = _peopleViewModel;
	}

    private void PeopleResult_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		_peopleViewModel.PeopleSelection(e);
    }

    private void NextPage_Pressed(object sender, EventArgs e)
    {
		_peopleViewModel.NextPage();
    }

	private void PreviousPage_Pressed(object sender, EventArgs e)
	{
		_peopleViewModel.PreviousPage();
	}
}