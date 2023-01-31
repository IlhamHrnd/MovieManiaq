using Newtonsoft.Json;
using static MovieManiaq.Model.Response.Movie.VideoModel;

namespace MovieManiaq.ViewModel.RestAPI.Movie
{
    public class VideoClass
    {
        public VideoClass()
        {

        }

        private const string VideoQuery = "https://api.themoviedb.org/3/movie/{0}/videos?api_key=a173a42ac2309ccc70dc04a4fa1188cc";

        public static async Task<VideoRoot> GetVideoAsync(int movieid)
        {
            VideoRoot root = new VideoRoot();
            HttpClient client = new HttpClient();
            string url = string.Format(VideoQuery, movieid);
            var response = await client.GetAsync(url);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var post = JsonConvert.DeserializeObject<VideoRoot>(content);
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
