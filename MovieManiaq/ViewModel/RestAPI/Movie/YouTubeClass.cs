using MovieManiaq.Model.Root;
using Newtonsoft.Json;
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
            HttpClient client = new HttpClient();
            string url = string.Format(YouTubeQuery, youtubeid, ApiRoot.YouTubeAPILayer);
            var response = await client.GetAsync(url);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var post = JsonConvert.DeserializeObject<YouTubeRoot>(content);
                    root = post;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Input Data Salah", "OK");
                }
            }

            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error " + e.Message + "", "OK");
            }
            return root;
        }
    }
}
