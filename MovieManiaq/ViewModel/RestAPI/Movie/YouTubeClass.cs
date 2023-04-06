using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MovieManiaq.Model.Root;
using Newtonsoft.Json;
using RestSharp;
using static MovieManiaq.Model.Response.Movie.YouTubeModel;

namespace MovieManiaq.ViewModel.RestAPI.Movie
{
    public class YouTubeClass
    {
        public YouTubeClass()
        {
            
        }

        private const string YouTubeQuery = "https://api.apilayer.com/youtube/video/streaming-data?id={0}&apikey={1}";

        public static async Task<YouTubeRoot> GetYouTubeAsync(string youtubeid)
        {
            YouTubeRoot root = new YouTubeRoot();
            string url = string.Format(YouTubeQuery, youtubeid, ApiRoot.YouTubeAPILayer);
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
                    var get = JsonConvert.DeserializeObject<YouTubeRoot>(content);
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
