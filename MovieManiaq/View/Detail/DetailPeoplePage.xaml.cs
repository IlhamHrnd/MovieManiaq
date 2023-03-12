using MovieManiaq.ViewModel.Detail;

namespace MovieManiaq.View.Detail;

public partial class DetailPeoplePage : ContentPage
{
	private readonly DetailPeopleViewModel _peopleViewModel;

	public DetailPeoplePage(int peopleid)
	{
		InitializeComponent();
		_peopleViewModel = new DetailPeopleViewModel(Navigation, peopleid);
		BindingContext = _peopleViewModel;
	}
}