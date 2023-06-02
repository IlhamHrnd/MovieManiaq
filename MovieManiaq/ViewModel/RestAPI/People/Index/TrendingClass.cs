using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MovieManiaq.Model.Root;
using Newtonsoft.Json;
using RestSharp;
using static MovieManiaq.Model.Response.People.Index.TrendingModel;

namespace MovieManiaq.ViewModel.RestAPI.People.Index
{
    public class TrendingClass
    {
        public TrendingClass()
        {
            
        }

        private const string TrendingQuery = "https://api.themoviedb.org/3/person/popular?api_key={0}&page={1}";

        public static async Task<TrendingRoot> GetTrendingAsync(int page)
        {
            TrendingRoot root = new TrendingRoot();
            string url = string.Format(TrendingQuery, ApiRoot.TheMovieDB, page);
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
