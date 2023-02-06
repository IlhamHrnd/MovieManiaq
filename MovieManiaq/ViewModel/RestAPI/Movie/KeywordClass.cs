using Newtonsoft.Json;
using MovieManiaq.Model.Root;
using static MovieManiaq.Model.Response.Movie.KeywordModel;

namespace MovieManiaq.ViewModel.RestAPI.Movie
{
    public class KeywordClass
    {
        public KeywordClass()
        {

        }

        private const string KeywordQuery = "https://api.themoviedb.org/3/movie/{0}/keywords?api_key={1}";

        public static async Task<KeywordRoot> GetKeywordAsync(int movieid)
        {
            KeywordRoot root = new KeywordRoot();
            HttpClient client = new HttpClient();
            string url = string.Format(KeywordQuery, movieid, ApiRoot.TheMovieDB);
            var response = await client.GetAsync(url);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var post = JsonConvert.DeserializeObject<KeywordRoot>(content);
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
