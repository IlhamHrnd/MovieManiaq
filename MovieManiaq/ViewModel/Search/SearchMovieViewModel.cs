using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MovieManiaq.Model.Root;
using MovieManiaq.Model.Search;
using MovieManiaq.ViewModel.RestAPI.Movie;

namespace MovieManiaq.ViewModel.Search
{
    public class SearchMovieViewModel : SearchMovieModel
    {
        private readonly NetworkModel network = new NetworkModel();

        private readonly INavigation _navigation;

        public SearchMovieViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }

        public async void MovieSearch(object obj)
        {
            bool valid_connect = network.CekJaringan;

            IsVisible = true;
            IsBusy = true;

            if (valid_connect)
            {
                var press = (SearchBar)obj;
                
                if (!string.IsNullOrEmpty(press.Text))
                {
                    var search = await SearchClass.GetSearchAsync(press.Text);
                    ListSearch.Clear();
                    ListSearch.Add(search);
                }
            }

            else
            {
                var toast = Toast.Make("You're Offline", ToastDuration.Long, 30);
                await toast.Show();
            }

            IsBusy = false;
            IsVisible = false;
        }

        private async void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            bool valid_connect = network.CekJaringan;

            if (!valid_connect)
            {
                var toast = Toast.Make("You're Offline", ToastDuration.Long);
                await toast.Show();
            }

            else if (valid_connect)
            {
                var toast = Toast.Make("Back Online", ToastDuration.Long);
                await toast.Show();
            }
        }
    }
}
