using Newtonsoft.Json;
using static MovieManiaq.Model.Response.Movie.RecommendationsModel;

namespace MovieManiaq.ViewModel.RestAPI.Movie
{
    public class RecommendationsClass
    {
        public RecommendationsClass()
        {

        }

        private const string RecommendationsQuery = "https://api.themoviedb.org/3/movie/{0}/recommendations?api_key=a173a42ac2309ccc70dc04a4fa1188cc&page=1";

        public static async Task<RecommendationsRoot> GetRecommendationsAsync(int movieid)
        {
            RecommendationsRoot root = new RecommendationsRoot();
            HttpClient client = new HttpClient();
            string url = string.Format(RecommendationsQuery, movieid);
            var response = await client.GetAsync(url);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var post = JsonConvert.DeserializeObject<RecommendationsRoot>(content);
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
