using Newtonsoft.Json;
using static MovieManiaq.Model.Response.NowShowingModel;

namespace MovieManiaq.ViewModel.RestAPI
{
    public class NowShowingClass
    {
        public NowShowingClass()
        {

        }

        private const string NowShowingQuery = "https://api.themoviedb.org/3/movie/now_playing?api_key=a173a42ac2309ccc70dc04a4fa1188cc&page=1";

        public static async Task<NowShowingRoot> GetNowShowingAsync()
        {
            NowShowingRoot root = new NowShowingRoot();
            HttpClient client = new HttpClient();
            string url = string.Format(NowShowingQuery);
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
