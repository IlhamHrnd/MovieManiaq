﻿using Newtonsoft.Json;
using MovieManiaq.Model.Root;
using static MovieManiaq.Model.Response.Movie.Index.PopularModel;

namespace MovieManiaq.ViewModel.RestAPI.Movie.Index
{
    public class PopularClass
    {
        public PopularClass()
        {

        }

        private const string PopularQuery = "https://api.themoviedb.org/3/movie/popular?api_key={0}&page=1";

        public static async Task<PopularRoot> GetPopularAsync()
        {
            PopularRoot root = new PopularRoot();
            HttpClient client = new HttpClient();
            string url = string.Format(PopularQuery, ApiRoot.TheMovieDB);
            var response = await client.GetAsync(url);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var post = JsonConvert.DeserializeObject<PopularRoot>(content);
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