using Newtonsoft.Json;
using static MovieManiaq.Model.Response.Movie.ImagesModel;

namespace MovieManiaq.ViewModel.RestAPI.Movie
{
    public class ImagesClass
    {
        public ImagesClass()
        {

        }

        private const string ImagesQuery = "https://api.themoviedb.org/3/movie/{0}/images?api_key=a173a42ac2309ccc70dc04a4fa1188cc";

        public static async Task<ImagesRoot> GetImagesAsync(int movieid)
        {
            ImagesRoot root = new ImagesRoot();
            HttpClient client = new HttpClient();
            string url = string.Format(ImagesQuery, movieid);
            var response = await client.GetAsync(url);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var post = JsonConvert.DeserializeObject<ImagesRoot>(content);
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
