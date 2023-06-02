using Newtonsoft.Json;
using RestSharp;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MovieManiaq.Model.Root;
using static MovieManiaq.Model.Response.Movie.SimiliarModel;


namespace MovieManiaq.ViewModel.RestAPI.Movie
{
    public class SimiliarClass
    {
        public SimiliarClass()
        {

        }

        private const string SimiliarQuery = "https://api.themoviedb.org/3/movie/{0}/similar?api_key={1}&page=1";

        public static async Task<SimiliarRoot> GetSimiliarAsync(int movieid)
        {
            SimiliarRoot root = new SimiliarRoot();
            string url = string.Format(SimiliarQuery, movieid, ApiRoot.TheMovieDB);
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
                    var get = JsonConvert.DeserializeObject<SimiliarRoot>(content);
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
                var toast = Toast.Make("Failed Retrieve Similiar Data", ToastDuration.Long);
                await toast.Show();
            }

            return root;
        }
    }
}
