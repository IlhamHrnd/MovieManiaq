using Newtonsoft.Json;
using MovieManiaq.Model.Root;
using static MovieManiaq.Model.Response.Movie.Index.NowShowingModel;

namespace MovieManiaq.ViewModel.RestAPI.Movie.Index
{
    public class NowShowingClass
    {
        public NowShowingClass()
        {

        }

        private const string NowShowingQuery = "https://api.themoviedb.org/3/movie/now_playing?api_key={0}&page=1";

        public static async Task<NowShowingRoot> GetNowShowingAsync()
        {
            NowShowingRoot root = new NowShowingRoot();
            HttpClient client = new HttpClient();
            string url = string.Format(NowShowingQuery, ApiRoot.TheMovieDB);
            var response = await client.GetAsync(url);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var post = JsonConvert.DeserializeObject<NowShowingRoot>(content);
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
