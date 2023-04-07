using MovieManiaq.Model.Home;
using MovieManiaq.Model.Root;
using MovieManiaq.ViewModel.RestAPI.Github;

namespace MovieManiaq.ViewModel.Home
{
    public class GithubCommitViewModel : GithubCommitModel
    {
        private readonly NetworkModel network = new NetworkModel();

        private readonly INavigation _navigation;

        public GithubCommitViewModel(INavigation navigation)
        {
            _navigation = navigation;

            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

            LoadData();
        }

        private async void LoadData()
        {
            bool valid_connect = network.CekJaringan;

            IsBusy = true;
            IsVisible = true;

            if (valid_connect)
            {
                var commithistory = await CommitHistoryClass.GetCommitHistoryAsync();
                ListCommitHistory.Clear();
                for (int i = 0; i < commithistory.Count; i++)
                {
                    ListCommitHistory.Add(commithistory[i]);
                }
            }
            else
            {
                NetworkModel.NoConnection();
            }

            IsBusy = false;
            IsVisible = false;
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            NetworkModel.Connectivity_ConnectivityChanged(sender, e);
        }
    }
}