using Newtonsoft.Json;
using RestSharp;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MovieManiaq.Model.Root;
using static MovieManiaq.Model.Response.Movie.CreditsModel;


namespace MovieManiaq.ViewModel.RestAPI.Movie
{
    public class CreditsClass
    {
        public CreditsClass()
        {

        }

        private const string CreditsQuery = "https://api.themoviedb.org/3/movie/{0}/credits?api_key={1}";

        public static async Task<CreditsRoot> GetCreditsAsync(int movieid)
        {
            CreditsRoot root = new CreditsRoot();
            string url = string.Format(CreditsQuery, movieid, ApiRoot.TheMovieDB);
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
                    var get = JsonConvert.DeserializeObject<CreditsRoot>(content);
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
