using Newtonsoft.Json;
using static MovieManiaq.Model.Response.UpComingModel;

namespace MovieManiaq.ViewModel.RestAPI
{
    public class UpComingClass
    {
        public UpComingClass()
        {

        }

        private const string UpComingQuery = "https://api.themoviedb.org/3/movie/upcoming?api_key=a173a42ac2309ccc70dc04a4fa1188cc&page=1";

        public static async Task<UpComingRoot> GetUpComingAsync()
        {
            UpComingRoot root = new UpComingRoot();
            HttpClient client = new HttpClient();
            string url = string.Format(UpComingQuery);
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
