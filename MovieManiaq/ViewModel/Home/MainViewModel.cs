using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Maui.Devices.Sensors;
using MovieManiaq.Model.Home;
using MovieManiaq.Model.Response.Movie.Index;
using MovieManiaq.Model.Root;
using MovieManiaq.View.Detail;
using MovieManiaq.ViewModel.RestAPI.Geocoding;
using MovieManiaq.ViewModel.RestAPI.Movie.Index;

namespace MovieManiaq.ViewModel.Home
{
    public class MainViewModel : MainModel
    {
        private readonly NetworkModel network = new NetworkModel();

        private readonly INavigation _navigation;

        private readonly IMemoryCache _memoryCache;
        public MainViewModel(INavigation navigation, IMemoryCache memoryCache)
        {
            _navigation = navigation;
            _memoryCache = memoryCache;

            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

            LoadData();
        }

        private async void LoadData()
        {
            bool valid_connect = network.CekJaringan;

            IsVisible = true;
            IsBusy = true;

            if (valid_connect)
            {
                string Region = string.Empty;

                try
                {
                    var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

                    if (status == PermissionStatus.Granted)
                    {
                        var GeoRequest = new GeolocationRequest(GeolocationAccuracy.Lowest, TimeSpan.FromSeconds(15));
                        var location = await Geolocation.Default.GetLocationAsync(GeoRequest);

                        if (location != null)
                        {
                            var loc = await ReverseGeocodingClass.GetReverseGeocodingAsync(location.Latitude.ToString(), location.Longitude.ToString());

                            if (loc != null)
                            {
                                Region = string.Format("&region={0}", loc.results[0].country_code);
                            }
                            else
                            {
                                Region = string.Empty;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    var toast = Toast.Make(ex.Message, ToastDuration.Long);
                    await toast.Show();
                }

                var nowshowing = await NowShowingClass.GetNowShowingAsync(Region);
                if (nowshowing.results.Count > 0)
                {
                    ListNowShowing.Clear();
                    ListNowShowing.Add(nowshowing);
                }

                var trending = await TrendingClass.GetTrendingAsync();
                if (trending.results.Count > 0)
                {
                    ListTrending.Clear();
                    ListTrending.Add(trending);
                }

                var upcoming = await UpComingClass.GetUpComingAsync(Region);
                if (upcoming.results.Count > 0)
                {
                    ListUpComing.Clear();
                    ListUpComing.Add(upcoming);
                }

                var toprated = await TopRatedClass.GetTopRatedAsync(Region);
                if (toprated.results.Count > 0)
                {
                    ListTopRated.Clear();
                    ListTopRated.Add(toprated);
                }

                var popular = await PopularClass.GetPopularAsync(Region);
                if (popular.results.Count > 0)
                {
                    ListPopular.Clear();
                    ListPopular.Add(popular);
                }
            }

            else
            {
                NetworkModel.NoConnection();
            }

            IsBusy = false;
            IsVisible = false;
        }

        public void TrendingSelection(object obj)
        {
            var carousel = obj as CarouselView;
            var select = carousel.CurrentItem;

            if (select != null)
            {
                var movieID = select as TrendingModel.Result;
                TrendingID = movieID.id;                
            }
        }

        public async void TrendingCommand()
        {
            await _navigation.PushAsync(new DetailMoviePage(TrendingID));
        }

        public void NowShowingSelection(object obj)
        {
            var carousel = obj as CarouselView;
            var select = carousel.CurrentItem;

            if (select != null)
            {
                var movieID = select as NowShowingModel.Result;
                NowPlayingID = movieID.id;
            }
        }

        public async void NowShowingCommand()
        {
            await _navigation.PushAsync(new DetailMoviePage(NowPlayingID));
        }

        public void UpCoomingSelection(object obj)
        {
            var carousel = obj as CarouselView;
            var select = carousel.CurrentItem;

            if (select != null)
            {
                var movieID = select as UpComingModel.Result;
                UpComingID = movieID.id;
            }
        }

        public async void UpComingCommand()
        {
            await _navigation.PushAsync(new DetailMoviePage(UpComingID));
        }

        public void TopRatedSelection(object obj)
        {
            var carousel = obj as CarouselView;
            var select = carousel.CurrentItem;

            if (select != null)
            {
                var movieID = select as TopRatedModel.Result;
                TopRatedID = movieID.id;
            }
        }

        public async void TopRatedCommand()
        {
            await _navigation.PushAsync(new DetailMoviePage(TopRatedID));
        }

        public void PopularSelection(object obj)
        {
            var carousel = obj as CarouselView;
            var select = carousel.CurrentItem;

            if (select != null)
            {
                var movieID = select as PopularModel.Result;
                PopularID = movieID.id;
            }
        }

        public async void PopularCommand()
        {
            await _navigation.PushAsync(new DetailMoviePage(PopularID));
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            NetworkModel.Connectivity_ConnectivityChanged(sender, e);
        }
    }
}
