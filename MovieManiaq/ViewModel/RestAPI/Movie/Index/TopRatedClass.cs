using Newtonsoft.Json;
using MovieManiaq.Model.Root;
using static MovieManiaq.Model.Response.Movie.Index.TopRatedModel;

namespace MovieManiaq.ViewModel.RestAPI.Movie.Index
{
    public class TopRatedClass
    {
        public TopRatedClass()
        {

        }

        private const string TopRatedQuery = "https://api.themoviedb.org/3/movie/top_rated?api_key={0}&page=1";

        public static async Task<TopRatedRoot> GetTopRatedAsync()
        {
            TopRatedRoot root = new TopRatedRoot();
            HttpClient client = new HttpClient();
            string url = string.Format(TopRatedQuery, ApiRoot.TheMovieDB);
            var response = await client.GetAsync(url);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var post = JsonConvert.DeserializeObject<TopRatedRoot>(content);
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
