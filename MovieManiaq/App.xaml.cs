using MovieManiaq.Model.Root;

namespace MovieManiaq;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    protected override async void OnStart()
    {
		await PermissionRoot.RequestPermission();
    }
}
