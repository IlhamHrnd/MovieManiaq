using MovieManiaq.Model.Detail;
using MovieManiaq.Model.Response.Movie;
using MovieManiaq.Model.Root;
using MovieManiaq.ViewModel.RestAPI.Movie;
using static MovieManiaq.Model.Response.Movie.List.YouTubeList;

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
                    if (detail?.id != null)
                    {
                        Title = detail.title;
                        ListDetail.Clear();
                        ListDetail.Add(detail);
                    }

                    var credits = await CreditsClass.GetCreditsAsync(MovieID);
                    if (credits.crew.Count > 0 && credits.cast.Count > 0)
                    {
                        ListCredits.Clear();
                        ListCredits.Add(credits);
                    }

                    var keyword = await KeywordClass.GetKeywordAsync(MovieID);
                    if (keyword.keywords.Count > 0)
                    {
                        ListKeyword.Clear();
                        ListKeyword.Add(keyword);
                    }

                    var images = await ImagesClass.GetImagesAsync(MovieID);
                    if (images.logos.Count > 0 && images.posters.Count > 0 && images.backdrops.Count > 0)
                    {
                        ListImages.Clear();
                        ListImages.Add(images);
                    }

                    var recommendations = await RecommendationsClass.GetRecommendationsAsync(MovieID);
                    if (recommendations.results.Count > 0)
                    {
                        ListRecommendations.Clear();
                        ListRecommendations.Add(recommendations);
                    }

                    var similiar = await SimiliarClass.GetSimiliarAsync(MovieID);
                    if (similiar.results.Count > 0)
                    {
                        ListSimiliar.Clear();
                        ListSimiliar.Add(similiar);
                    }

                    var review = await ReviewClass.GetReviewAsync(MovieID);
                    if (review.results.Count > 0)
                    {
                        ListReview.Clear();
                        ListReview.Add(review);
                    }

                    var video = await VideoClass.GetVideoAsync(MovieID);
                    if (video.results.Count > 0)
                    {
                        ListVideo.Clear();
                        ListVideo.Add(video);

                        //Sementara Hanya Dapat Mengambil Data Video Dari Index Pertama
                        if (video.results[0].site == "YouTube")
                        {
                            var youtube = await YouTubeClass.GetYouTubeAsync(video.results[0].key);
                            var root = new YouTubeListRoot()
                            {
                                result = new List<Result>
                            {
                                new Result
                                {
                                    name = video.results[0].name,
                                    type = video.results[0].type,
                                    url = youtube.formats[0].url,
                                    published_at = video.results[0].published_at,
                                    site = video.results[0].site
                                }
                            }
                            };
                            ListYouTube.Clear();
                            ListYouTube.Add(root);
                        }
                    }
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
