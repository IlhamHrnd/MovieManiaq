using MovieManiaq.Model.Root;
using Newtonsoft.Json;
using static MovieManiaq.Model.Response.People.CreditsModel;

namespace MovieManiaq.ViewModel.RestAPI.People
{
    public class CreditsClass
    {
        public CreditsClass()
        {
            
        }

        private const string CreditsQuery = "https://api.themoviedb.org/3/person/{0}/movie_credits?api_key={1}";

        public static async Task<CreditsRoot> GetCreditsAsync(int peopleid)
        {
            CreditsRoot root = new CreditsRoot();
            HttpClient client = new HttpClient();
            string url = string.Format(CreditsQuery, peopleid, ApiRoot.TheMovieDB);
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
