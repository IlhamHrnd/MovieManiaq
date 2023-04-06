using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MovieManiaq.Model.Root;
using Newtonsoft.Json;
using RestSharp;
using static MovieManiaq.Model.Response.Movie.SearchModel;

namespace MovieManiaq.ViewModel.RestAPI.Movie
{
    public class SearchClass
    {
        public SearchClass()
        {

        }

        private const string SearchQuery = "https://api.themoviedb.org/3/search/movie?api_key={0}&query={1}&page={2}&include_adult=false";

        public static async Task<SearchRoot> GetSearchAsync(string query, int page)
        {
            SearchRoot root = new SearchRoot();
            string url = string.Format(SearchQuery, ApiRoot.TheMovieDB, query, page);
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
                    var get = JsonConvert.DeserializeObject<SearchRoot>(content);
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
