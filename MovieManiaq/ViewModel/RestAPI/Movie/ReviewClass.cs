using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MovieManiaq.Model.Root;
using Newtonsoft.Json;
using RestSharp;
using static MovieManiaq.Model.Response.Movie.ReviewModel;

namespace MovieManiaq.ViewModel.RestAPI.Movie
{
    public class ReviewClass
    {
        public ReviewClass()
        {

        }

        private const string ReviewQuery = "https://api.themoviedb.org/3/movie/{0}/reviews?api_key={1}&page=1";

        public static async Task<ReviewRoot> GetReviewAsync(int movieid)
        {
            ReviewRoot root = new ReviewRoot();
            string url = string.Format(ReviewQuery, movieid, ApiRoot.TheMovieDB);
            var client = new RestClient(url);
            var request = new RestRequest
            {
                Method = Method.Get,
                Timeout = 10000
            };
            var response = await client.ExecuteGetAsync(request);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content;
                    var get = JsonConvert.DeserializeObject<ReviewRoot>(content);
                    root = get;
                }
                else
                {
                    var toast = Toast.Make(response.ErrorException.Message, ToastDuration.Long);
                    await toast.Show();
                }
            }
            catch (Exception e)
            {
                var toast = Toast.Make(e.Message, ToastDuration.Long);
                await toast.Show();
            }

            return root;
        }
    }
}
