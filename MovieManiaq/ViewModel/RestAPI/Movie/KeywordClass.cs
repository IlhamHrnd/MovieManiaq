using Newtonsoft.Json;
using static MovieManiaq.Model.Response.Movie.KeywordModel;

namespace MovieManiaq.ViewModel.RestAPI.Movie
{
    public class KeywordClass
    {
        public KeywordClass()
        {

        }

        private const string KeywordQuery = "https://api.themoviedb.org/3/movie/{0}/keywords?api_key=a173a42ac2309ccc70dc04a4fa1188cc";

        public static async Task<KeywordRoot> GetKeywordAsync(int movieid)
        {
            KeywordRoot root = new KeywordRoot();
            HttpClient client = new HttpClient();
            string url = string.Format(KeywordQuery, movieid);
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
