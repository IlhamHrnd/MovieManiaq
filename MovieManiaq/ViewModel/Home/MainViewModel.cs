using MovieManiaq.Model.Home;
using MovieManiaq.Model.Response;
using MovieManiaq.Model.Root;
using MovieManiaq.View.Detail;
using MovieManiaq.ViewModel.RestAPI;

namespace MovieManiaq.ViewModel.Home
{
    public class MainViewModel : MainModel
    {
        private readonly NetworkModel network = new NetworkModel();

        int TrendingID;
        int NowPlayingID;
        int UpComingID;
        int TopRatedID;
        int PopularID;

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
    }
}
