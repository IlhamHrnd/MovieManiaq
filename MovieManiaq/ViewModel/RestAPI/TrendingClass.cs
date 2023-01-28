using Newtonsoft.Json;
using static MovieManiaq.Model.Response.TrendingModel;

namespace MovieManiaq.ViewModel.RestAPI
{
    public class TrendingClass
    {
        public TrendingClass()
        {

        }

        private const string TrendingQuery = "https://api.themoviedb.org/3/trending/all/week?api_key=a173a42ac2309ccc70dc04a4fa1188cc&page=1";

        public static async Task<TrendingRoot> GetTrendingAsync()
        {
            TrendingRoot root = new TrendingRoot();
            HttpClient client = new HttpClient();
            string url = string.Format(TrendingQuery);
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
