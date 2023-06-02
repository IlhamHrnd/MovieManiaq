using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MovieManiaq.Model.Root;
using Newtonsoft.Json;
using RestSharp;
using static MovieManiaq.Model.Response.People.DetailModel;

namespace MovieManiaq.ViewModel.RestAPI.People
{
    public class DetailClass
    {
        public DetailClass()
        {
            
        }

        private const string DetailMovieQuery = "https://api.themoviedb.org/3/person/{0}?api_key={1}";

        public static async Task<DetailRoot> GetDetailMovieAsync(int peopleid)
        {
            DetailRoot root = new DetailRoot();
            string url = string.Format(DetailMovieQuery, peopleid, ApiRoot.TheMovieDB);
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
                    var get = JsonConvert.DeserializeObject<DetailRoot>(content);
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
                var toast = Toast.Make("Failed Retrieve Detail Data", ToastDuration.Long);
                await toast.Show();
            }

            return root;
        }
    }
}
