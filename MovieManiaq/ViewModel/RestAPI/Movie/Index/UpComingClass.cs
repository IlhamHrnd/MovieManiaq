using Newtonsoft.Json;
using RestSharp;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MovieManiaq.Model.Root;
using static MovieManiaq.Model.Response.Movie.Index.UpComingModel;

namespace MovieManiaq.ViewModel.RestAPI.Movie.Index
{
    public class UpComingClass
    {
        public UpComingClass()
        {

        }

        private const string UpComingQuery = "https://api.themoviedb.org/3/movie/upcoming?api_key={0}&page=1";

        public static async Task<UpComingRoot> GetUpComingAsync()
        {
            UpComingRoot root = new UpComingRoot();
            string url = string.Format(UpComingQuery, ApiRoot.TheMovieDB);
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
                    var get = JsonConvert.DeserializeObject<UpComingRoot>(content);
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
