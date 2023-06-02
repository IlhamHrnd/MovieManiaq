using Newtonsoft.Json;
using RestSharp;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MovieManiaq.Model.Root;
using static MovieManiaq.Model.Response.Movie.VideoModel;


namespace MovieManiaq.ViewModel.RestAPI.Movie
{
    public class VideoClass
    {
        public VideoClass()
        {

        }

        private const string VideoQuery = "https://api.themoviedb.org/3/movie/{0}/videos?api_key={1}";

        public static async Task<VideoRoot> GetVideoAsync(int movieid)
        {
            VideoRoot root = new VideoRoot();
            string url = string.Format(VideoQuery, movieid, ApiRoot.TheMovieDB);
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
                    var get = JsonConvert.DeserializeObject<VideoRoot>(content);
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
                var toast = Toast.Make("Failed Retrieve Video Data", ToastDuration.Long);
                await toast.Show();
            }

            return root;
        }
    }
}
