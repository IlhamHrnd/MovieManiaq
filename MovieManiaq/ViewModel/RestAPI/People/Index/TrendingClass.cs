using MovieManiaq.Model.Root;
using Newtonsoft.Json;
using static MovieManiaq.Model.Response.People.Index.TrendingModel;

namespace MovieManiaq.ViewModel.RestAPI.People.Index
{
    public class TrendingClass
    {
        public TrendingClass()
        {
            
        }

        private const string TrendingQuery = "https://api.themoviedb.org/3/person/popular?api_key={0}&page={1}";

        public static async Task<TrendingRoot> GetTrendingAsync(int page)
        {
            TrendingRoot root = new TrendingRoot();
            HttpClient client = new HttpClient();
            string url = string.Format(TrendingQuery, ApiRoot.TheMovieDB, page);
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
