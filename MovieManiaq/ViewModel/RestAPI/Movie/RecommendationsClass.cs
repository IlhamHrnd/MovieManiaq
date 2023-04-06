using Newtonsoft.Json;
using RestSharp;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MovieManiaq.Model.Root;
using static MovieManiaq.Model.Response.Movie.RecommendationsModel;


namespace MovieManiaq.ViewModel.RestAPI.Movie
{
    public class RecommendationsClass
    {
        public RecommendationsClass()
        {

        }

        private const string RecommendationsQuery = "https://api.themoviedb.org/3/movie/{0}/recommendations?api_key={1}&page=1";

        public static async Task<RecommendationsRoot> GetRecommendationsAsync(int movieid)
        {
            RecommendationsRoot root = new RecommendationsRoot();
            string url = string.Format(RecommendationsQuery, movieid, ApiRoot.TheMovieDB);
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
                    var get = JsonConvert.DeserializeObject<RecommendationsRoot>(content);
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
