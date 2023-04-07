using MovieManiaq.ViewModel.Home;

namespace MovieManiaq.View.Home;

public partial class GithubCommitPage : ContentPage
{
	private readonly GithubCommitViewModel _githubCommitViewModel;

	public GithubCommitPage()
	{
		InitializeComponent();
		_githubCommitViewModel = new GithubCommitViewModel(Navigation);
		BindingContext = _githubCommitViewModel;
	}
}