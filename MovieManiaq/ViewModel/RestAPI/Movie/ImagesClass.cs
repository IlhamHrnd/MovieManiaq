using Newtonsoft.Json;
using RestSharp;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MovieManiaq.Model.Root;
using static MovieManiaq.Model.Response.Movie.ImagesModel;


namespace MovieManiaq.ViewModel.RestAPI.Movie
{
    public class ImagesClass
    {
        public ImagesClass()
        {

        }

        private const string ImagesQuery = "https://api.themoviedb.org/3/movie/{0}/images?api_key={1}";

        public static async Task<ImagesRoot> GetImagesAsync(int movieid)
        {
            ImagesRoot root = new ImagesRoot();
            string url = string.Format(ImagesQuery, movieid, ApiRoot.TheMovieDB);
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
                    var get = JsonConvert.DeserializeObject<ImagesRoot>(content);
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
