using Newtonsoft.Json;
using static MovieManiaq.Model.Response.Movie.DetailModel;

namespace MovieManiaq.ViewModel.RestAPI.Movie
{
    public class DetailClass
    {
        public DetailClass()
        {

        }

        private const string DetailMovieQuery = "https://api.themoviedb.org/3/movie/{0}?api_key=a173a42ac2309ccc70dc04a4fa1188cc";

        public static async Task<DetailRoot> GetDetailMovieAsync(int movieid)
        {
            DetailRoot root = new DetailRoot();
            HttpClient client = new HttpClient();
            string url = string.Format(DetailMovieQuery, movieid);
            var response = await client.GetAsync(url);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var post = JsonConvert.DeserializeObject<DetailRoot>(content);
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
