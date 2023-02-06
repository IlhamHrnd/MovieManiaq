using Newtonsoft.Json;
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
            HttpClient client = new HttpClient();
            string url = string.Format(ImagesQuery, movieid, ApiRoot.TheMovieDB);
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
