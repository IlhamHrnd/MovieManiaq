using Newtonsoft.Json;
using MovieManiaq.Model.Root;
using static MovieManiaq.Model.Response.UpComingModel;

namespace MovieManiaq.ViewModel.RestAPI
{
    public class UpComingClass
    {
        public UpComingClass()
        {

        }

        private const string UpComingQuery = "https://api.themoviedb.org/3/movie/upcoming?api_key={0}&page=1";

        public static async Task<UpComingRoot> GetUpComingAsync()
        {
            UpComingRoot root = new UpComingRoot();
            HttpClient client = new HttpClient();
            string url = string.Format(UpComingQuery, ApiRoot.TheMovieDB);
            var response = await client.GetAsync(url);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var post = JsonConvert.DeserializeObject<UpComingRoot>(content);
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
