using MovieManiaq.Model.Home;
using MovieManiaq.Model.Root;
using MovieManiaq.ViewModel.RestAPI;

namespace MovieManiaq.ViewModel.Home
{
    public class MainViewModel : MainModel
    {
        private readonly NetworkModel network = new NetworkModel();

        private readonly INavigation _navigation;

        public MainViewModel(INavigation navigation)
        {
            _navigation = navigation;

            LoadData();
        }

        private async void LoadData()
        {
            bool valid_connect = network.CekJaringan;

            IsVisible = true;
            IsBusy = true;

            if (valid_connect)
            {
                var trending = await TrendingClass.GetTrendingAsync();
                ListTrending.Clear();
                ListTrending.Add(trending);

                var upcoming = await UpComingClass.GetUpComingAsync();
                ListUpComing.Clear();
                ListUpComing.Add(upcoming);

                var nowshowing = await NowShowingClass.GetNowShowingAsync();
                ListNowShowing.Clear();
                ListNowShowing.Add(nowshowing);

                var toprated = await TopRatedClass.GetTopRatedAsync();
                ListTopRated.Clear();
                ListTopRated.Add(toprated);

                var popular = await PopularClass.GetPopularAsync();
                ListPopular.Clear();
                ListPopular.Add(popular);
            }

            IsBusy = false;
            IsVisible = false;
        }
    }
}
