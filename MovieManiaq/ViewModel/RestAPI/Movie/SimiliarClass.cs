using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManiaq.Model.Root;
using static MovieManiaq.Model.Response.Movie.SimiliarModel;

namespace MovieManiaq.ViewModel.RestAPI.Movie
{
    public class SimiliarClass
    {
        public SimiliarClass()
        {

        }

        private const string SimiliarQuery = "https://api.themoviedb.org/3/movie/{0}/similar?api_key={1}&page=1";

        public static async Task<SimiliarRoot> GetSimiliarAsync(int movieid)
        {
            SimiliarRoot root = new SimiliarRoot();
            HttpClient client = new HttpClient();
            string url = string.Format(SimiliarQuery, movieid, ApiRoot.TheMovieDB);
            var response = await client.GetAsync(url);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var post = JsonConvert.DeserializeObject<SimiliarRoot>(content);
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
