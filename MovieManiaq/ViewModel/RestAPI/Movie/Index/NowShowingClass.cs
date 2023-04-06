using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MovieManiaq.Model.Root;
using Newtonsoft.Json;
using RestSharp;
using static MovieManiaq.Model.Response.Movie.Index.NowShowingModel;

namespace MovieManiaq.ViewModel.RestAPI.Movie.Index
{
    public class NowShowingClass
    {
        public NowShowingClass()
        {

        }

        private const string NowShowingQuery = "https://api.themoviedb.org/3/movie/now_playing?api_key={0}&page=1";

        public static async Task<NowShowingRoot> GetNowShowingAsync()
        {
            NowShowingRoot root = new NowShowingRoot();
            string url = string.Format(NowShowingQuery, ApiRoot.TheMovieDB);
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
                    var get = JsonConvert.DeserializeObject<NowShowingRoot>(content);
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
