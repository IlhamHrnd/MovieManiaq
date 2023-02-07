using MovieManiaq.Model.Root;
using Newtonsoft.Json;
using static MovieManiaq.Model.Response.Movie.ReviewModel;

namespace MovieManiaq.ViewModel.RestAPI.Movie
{
    public class ReviewClass
    {
        public ReviewClass()
        {

        }

        private const string ReviewQuery = "https://api.themoviedb.org/3/movie/{0}/reviews?api_key={1}&page=1";

        public static async Task<ReviewRoot> GetReviewAsync(int movieid)
        {
            ReviewRoot root = new ReviewRoot();
            HttpClient client = new HttpClient();
            string url = string.Format(ReviewQuery, movieid, ApiRoot.TheMovieDB);
            var response = await client.GetAsync(url);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var post = JsonConvert.DeserializeObject<ReviewRoot>(content);
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
