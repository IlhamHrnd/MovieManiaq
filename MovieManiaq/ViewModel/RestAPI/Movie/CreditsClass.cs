using Newtonsoft.Json;
using static MovieManiaq.Model.Response.Movie.CreditsModel;

namespace MovieManiaq.ViewModel.RestAPI.Movie
{
    public class CreditsClass
    {
        public CreditsClass()
        {

        }

        private const string CreditsQuery = "https://api.themoviedb.org/3/movie/{0}/credits?api_key=a173a42ac2309ccc70dc04a4fa1188cc";

        public static async Task<CreditsRoot> GetCreditsAsync(int movieid)
        {
            CreditsRoot root = new CreditsRoot();
            HttpClient client = new HttpClient();
            string url = string.Format(CreditsQuery, movieid);
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
