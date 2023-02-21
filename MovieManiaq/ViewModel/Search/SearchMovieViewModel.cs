using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MovieManiaq.Model.Root;
using MovieManiaq.Model.Search;
using MovieManiaq.View.Detail;
using MovieManiaq.ViewModel.RestAPI.Movie;
using static MovieManiaq.Model.Response.Movie.SearchModel;

namespace MovieManiaq.ViewModel.Search
{
    public class SearchMovieViewModel : SearchMovieModel
    {
        private readonly NetworkModel network = new NetworkModel();

        private readonly INavigation _navigation;

        public SearchMovieViewModel(INavigation navigation)
        {
            _navigation = navigation;

            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
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
                    var search = await SearchClass.GetSearchAsync(press.Text, Page);
                    ListSearch.Clear();
                    ListSearch.Add(search);
                    MovieTitle = press.Text;
                    Page = (int)search.page;
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

        public async void MovieSelection(SelectionChangedEventArgs e)
        {
            var movieID = e.CurrentSelection[0] as Result;

            if (movieID != null)
            {
                await _navigation.PushAsync(new DetailMoviePage((int)movieID.id));
            }
        }

        public async void NextPage()
        {
            var maxPage = ListSearch[0].total_pages;

            if (Page >= maxPage)
            {
                await Application.Current.MainPage.DisplayAlert("Latest Page", "This Is The Latest Page", "OK");
            }

            else
            {
                bool valid_connect = network.CekJaringan;

                IsVisible = true;
                IsBusy = true;

                if (valid_connect)
                {
                    var nextPage = ListSearch[0].page + 1;

                    var next = await SearchClass.GetSearchAsync(MovieTitle, (int)nextPage);
                    ListSearch.Clear();
                    ListSearch.Add(next);
                    Page = (int)next.page;
                }

                else
                {
                    var toast = Toast.Make("You're Offline", ToastDuration.Long, 30);
                    await toast.Show();
                }

                IsBusy = false;
                IsVisible = false;
            }
        }

        public async void PreviousPage()
        {
            if (Page <= 1)
            {
                await Application.Current.MainPage.DisplayAlert("First Page", "This Is The First Page", "OK");
            }

            else
            {
                bool valid_connect = network.CekJaringan;

                IsVisible = true;
                IsBusy = true;

                if (valid_connect)
                {
                    var previousPage = ListSearch[0].page - 1;

                    var previous = await SearchClass.GetSearchAsync(MovieTitle, (int)previousPage);
                    ListSearch.Clear();
                    ListSearch.Add(previous);
                    Page = (int)previous.page;
                }

                else
                {
                    var toast = Toast.Make("You're Offline", ToastDuration.Long, 30);
                    await toast.Show();
                }

                IsBusy = false;
                IsVisible = false;
            }
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
