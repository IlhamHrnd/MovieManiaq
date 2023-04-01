using MovieManiaq.Model.Detail;
using MovieManiaq.Model.Response.Movie;
using MovieManiaq.Model.Root;
using MovieManiaq.ViewModel.RestAPI.Movie;
using static MovieManiaq.Model.Response.Movie.ListYouTubeModel;

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
                try
                {
                    var detail = await DetailClass.GetDetailMovieAsync(MovieID);
                    ListDetail.Clear();
                    ListDetail.Add(detail);

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

                    //List Video Sementara Hanya Dapat Satu Video
                    ListYouTube.Clear();
                    for (int i = 0; i < 1; i++)
                    {
                        if (video.results[i].site == "YouTube")
                        {
                            var youtube = await YouTubeClass.GetYouTubeAsync(video.results[i].key);

                            var youtubes = new ListYouTubeRoot()
                            {
                                youtube = new List<YouTube>()
                                {
                                    new YouTube()
                                    {
                                        title = video.results[i].name,
                                        url = youtube.formats[i].url,
                                        publish = video.results[i].published_at

                                    }
                                }
                            };
                            ListYouTube.Add(youtubes);
                        }
                    }

                    var recommendations = await RecommendationsClass.GetRecommendationsAsync(MovieID);
                    ListRecommendations.Clear();
                    ListRecommendations.Add(recommendations);

                    var similiar = await SimiliarClass.GetSimiliarAsync(MovieID);
                    ListSimiliar.Clear();
                    ListSimiliar.Add(similiar);

                    var review = await ReviewClass.GetReviewAsync(MovieID);
                    ListReview.Clear();
                    ListReview.Add(review);

                    Title = detail.title;
                }
                catch (Exception e)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", string.Format("{0}", e.Message), "OK");
                }
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

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            NetworkModel.Connectivity_ConnectivityChanged(sender, e);
        }
    }
}
