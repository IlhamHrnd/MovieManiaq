using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MovieManiaq.Model.Detail;
using MovieManiaq.Model.Response.Movie;
using MovieManiaq.Model.Root;
using MovieManiaq.ViewModel.RestAPI.Movie;

namespace MovieManiaq.ViewModel.Detail
{
    public class DetailMovieViewModel : DetailMovieModel
    {
        private readonly NetworkModel network = new NetworkModel();
        
        private readonly INavigation _navigation;

        public DetailMovieViewModel(INavigation navigation, int movieID)
        {
            _navigation = navigation;
            MovieID = movieID;

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
                var detail = await DetailClass.GetDetailMovieAsync(MovieID);
                ListDetail.Clear();
                ListDetail.Add(detail);

                Title = detail.title;

                var credits = await CreditsClass.GetCreditsAsync(MovieID);
                ListCredits.Clear();
                ListCredits.Add(credits);

                var keyword = await KeywordClass.GetKeywordAsync(MovieID);
                ListKeyword.Clear();
                ListKeyword.Add(keyword);

                var images = await ImagesClass.GetImagesAsync(MovieID);
                ListImages.Clear();
                ListImages.Add(images);

                var video = await VideoClass.GetVideoAsync(MovieID);
                ListVideo.Clear();
                ListVideo.Add(video);

                var recommendations = await RecommendationsClass.GetRecommendationsAsync(MovieID);
                ListRecommendations.Clear();
                ListRecommendations.Add(recommendations);

                var similiar = await SimiliarClass.GetSimiliarAsync(MovieID);
                ListSimiliar.Clear();
                ListSimiliar.Add(similiar);

                var review = await ReviewClass.GetReviewAsync(MovieID);
                ListReview.Clear();
                ListReview.Add(review);
            }

            else
            {
                NetworkModel.NoConnection();
            }

            IsBusy = false;
            IsVisible = false;
        }

        public void RecommendationsSelection(SelectionChangedEventArgs e)
        {
            var movieID = e.CurrentSelection[0] as RecommendationsModel.Result;

            if (movieID != null)
            {
                MovieID = movieID.id;

                LoadData();
            }
        }

        public void SimiliarSelection(SelectionChangedEventArgs e)
        {
            var movieID = e.CurrentSelection[0] as SimiliarModel.Result;

            if (movieID != null)
            {
                MovieID = movieID.id;

                LoadData();
            }
        }

        private async void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            bool valid_connect = network.CekJaringan;

            if (!valid_connect)
            {
                NetworkModel.NoConnection();
            }

            else if (valid_connect)
            {
                var toast = Toast.Make("Back Online", ToastDuration.Long);
                await toast.Show();

                LoadData();
            }
        }
    }
}
