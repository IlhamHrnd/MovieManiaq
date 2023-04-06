using Newtonsoft.Json;
using RestSharp;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MovieManiaq.Model.Root;
using static MovieManiaq.Model.Response.Movie.Index.TopRatedModel;

namespace MovieManiaq.ViewModel.RestAPI.Movie.Index
{
    public class TopRatedClass
    {
        public TopRatedClass()
        {

        }

        private const string TopRatedQuery = "https://api.themoviedb.org/3/movie/top_rated?api_key={0}&page=1";

        public static async Task<TopRatedRoot> GetTopRatedAsync()
        {
            TopRatedRoot root = new TopRatedRoot();
            string url = string.Format(TopRatedQuery, ApiRoot.TheMovieDB);
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
                    var get = JsonConvert.DeserializeObject<TopRatedRoot>(content);
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
