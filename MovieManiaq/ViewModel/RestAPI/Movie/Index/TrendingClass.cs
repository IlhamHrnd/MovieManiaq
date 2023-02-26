using Newtonsoft.Json;
using MovieManiaq.Model.Root;
using static MovieManiaq.Model.Response.Movie.Index.TrendingModel;

namespace MovieManiaq.ViewModel.RestAPI.Movie.Index
{
    public class TrendingClass
    {
        public TrendingClass()
        {

        }

        private const string TrendingQuery = "https://api.themoviedb.org/3/trending/movie/week?api_key={0}&page=1";

        public static async Task<TrendingRoot> GetTrendingAsync()
        {
            TrendingRoot root = new TrendingRoot();
            HttpClient client = new HttpClient();
            string url = string.Format(TrendingQuery, ApiRoot.TheMovieDB);
            var response = await client.GetAsync(url);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var post = JsonConvert.DeserializeObject<TrendingRoot>(content);
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
