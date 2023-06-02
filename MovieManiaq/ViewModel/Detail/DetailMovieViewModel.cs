using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MovieManiaq.Model.Detail;
using MovieManiaq.Model.Response.Movie;
using MovieManiaq.Model.Root;
using MovieManiaq.ViewModel.RestAPI.Country;
using MovieManiaq.ViewModel.RestAPI.Currency;
using MovieManiaq.ViewModel.RestAPI.Geocoding;
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

                    var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

                    if (status == PermissionStatus.Granted)
                    {
                        var GeoRequest = new GeolocationRequest(GeolocationAccuracy.Lowest, TimeSpan.FromSeconds(15));
                        var location = await Geolocation.Default.GetLocationAsync(GeoRequest);

                        if (location != null)
                        {
                            var loc = await ReverseGeocodingClass.GetReverseGeocodingAsync(location.Latitude.ToString(), location.Longitude.ToString());

                            if (loc.results[0].country_code != null)
                            {
                                var country = await CountryClass.GetCountryAsync(loc.results[0].country_code);

                                if (country.data[0].code != null)
                                {
                                    var budget = await CurrencyClass.GetCurrencyAsync(country.data[0].code, detail.budget.ToString());

                                    if (budget.success && detail?.id != null)
                                    {
                                        //Data Sudah Terkonversi Ke Negara Masing Masing Lokasi User
                                        //Passing Data Dari Model Currency Ke Model Detail Error Retrieve Null Data
                                        var toast = Toast.Make(string.Format("From {0}{1} To {2}{3}", country.data[0].symbol, detail.budget.ToString(), country.data[0].symbol, budget.result), ToastDuration.Long);
                                        await toast.Show();


                                    }
                                }
                            }
                        }
                    }

                    var credits = await CreditsClass.GetCreditsAsync(MovieID);
                    if (credits.crew.Count > 0 || credits.cast.Count > 0)
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
                    if (images.logos.Count > 0 || images.posters.Count > 0 || images.backdrops.Count > 0)
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
                        //Handler Saat Proses Pengambilan Data Youtube Masih Error Saat RTO
                        for (int i = 0; i < 2; i++)
                        {
                            if (video.results[i].site == "YouTube")
                            {
                                var youtube = await YouTubeClass.GetYouTubeAsync(video.results[i].key);
                                if (youtube != null)
                                {
                                    var root = new YouTubeListRoot()
                                    {
                                            result = new List<Result>
                                        {
                                            new Result
                                            {
                                                name = video.results[i].name,
                                                type = video.results[i].type,
                                                url = youtube.formats[i].url,
                                                published_at = video.results[i].published_at,
                                                site = video.results[i].site
                                            }
                                        }
                                    };
                                    ListYouTube.Add(root);
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    var toast = Toast.Make(e.Message, ToastDuration.Long);
                    await toast.Show();
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
