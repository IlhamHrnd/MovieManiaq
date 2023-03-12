using MovieManiaq.Model.Root;
using Newtonsoft.Json;
using static MovieManiaq.Model.Response.People.DetailModel;

namespace MovieManiaq.ViewModel.RestAPI.People
{
    public class DetailClass
    {
        public DetailClass()
        {
            
        }

        private const string DetailMovieQuery = "https://api.themoviedb.org/3/person/{0}?api_key={1}";

        public static async Task<DetailRoot> GetDetailMovieAsync(int peopleid)
        {
            DetailRoot root = new DetailRoot();
            HttpClient client = new HttpClient();
            string url = string.Format(DetailMovieQuery, peopleid, ApiRoot.TheMovieDB);
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
