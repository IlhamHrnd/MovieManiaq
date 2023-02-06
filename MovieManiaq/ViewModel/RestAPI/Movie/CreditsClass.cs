using Newtonsoft.Json;
using MovieManiaq.Model.Root;
using static MovieManiaq.Model.Response.Movie.CreditsModel;

namespace MovieManiaq.ViewModel.RestAPI.Movie
{
    public class CreditsClass
    {
        public CreditsClass()
        {

        }

        private const string CreditsQuery = "https://api.themoviedb.org/3/movie/{0}/credits?api_key={1}";

        public static async Task<CreditsRoot> GetCreditsAsync(int movieid)
        {
            CreditsRoot root = new CreditsRoot();
            HttpClient client = new HttpClient();
            string url = string.Format(CreditsQuery, movieid, ApiRoot.TheMovieDB);
            var response = await client.GetAsync(url);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var post = JsonConvert.DeserializeObject<CreditsRoot>(content);
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
