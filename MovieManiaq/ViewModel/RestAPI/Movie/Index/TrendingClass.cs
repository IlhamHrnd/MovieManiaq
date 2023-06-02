using Newtonsoft.Json;
using RestSharp;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MovieManiaq.Model.Root;
using static MovieManiaq.Model.Response.Movie.Index.TrendingModel;

namespace MovieManiaq.ViewModel.RestAPI.Movie.Index
{
    public class TrendingClass
    {
        public TrendingClass()
        {

        }

        private const string TrendingQuery = "https://api.themoviedb.org/3/trending/movie/week?api_key={0}&page=1";

        public static async Task<TrendingRoot> GetTrendingAsync()
        {
            TrendingRoot root = new TrendingRoot();
            string url = string.Format(TrendingQuery, ApiRoot.TheMovieDB);
            var client = new RestClient(url);
            var request = new RestRequest
            {
                Method = Method.Get,
                Timeout = 1000
            };
            var response = await client.ExecuteGetAsync(request);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content;
                    var get = JsonConvert.DeserializeObject<TrendingRoot>(content);
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
                var toast = Toast.Make("Failed Retrieve Trending Data", ToastDuration.Long);
                await toast.Show();
            }
            return root;
        }
    }
}
