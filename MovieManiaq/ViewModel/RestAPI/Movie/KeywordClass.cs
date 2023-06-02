using Newtonsoft.Json;
using RestSharp;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MovieManiaq.Model.Root;
using static MovieManiaq.Model.Response.Movie.KeywordModel;

namespace MovieManiaq.ViewModel.RestAPI.Movie
{
    public class KeywordClass
    {
        public KeywordClass()
        {

        }

        private const string KeywordQuery = "https://api.themoviedb.org/3/movie/{0}/keywords?api_key={1}";

        public static async Task<KeywordRoot> GetKeywordAsync(int movieid)
        {
            KeywordRoot root = new KeywordRoot();
            string url = string.Format(KeywordQuery, movieid, ApiRoot.TheMovieDB);
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
                    var get = JsonConvert.DeserializeObject<KeywordRoot>(content);
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
                var toast = Toast.Make("Failed Retrieve Keyword Data", ToastDuration.Long);
                await toast.Show();
            }

            return root;
        }
    }
}
