using MovieManiaq.Model.Root;

namespace MovieManiaq;

public partial class App : Application
{
	public App()
	{
		Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(ApiRoot.Syncfucion);

		InitializeComponent();

		MainPage = new AppShell();
	}

    protected override async void OnStart()
    {
		await PermissionRoot.RequestPermission();
    }
}
