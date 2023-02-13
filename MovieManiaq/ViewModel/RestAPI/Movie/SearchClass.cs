﻿using MovieManiaq.Model.Root;
using Newtonsoft.Json;
using static MovieManiaq.Model.Response.Movie.SearchModel;

namespace MovieManiaq.ViewModel.RestAPI.Movie
{
    public class SearchClass
    {
        public SearchClass()
        {

        }

        private const string SearchQuery = "https://api.themoviedb.org/3/search/movie?api_key={0}&query={1}&page=1&include_adult=false";

        public static async Task<SearchRoot> GetSearchAsync(string query)
        {
            SearchRoot root = new SearchRoot();
            HttpClient client = new HttpClient();
            string url = string.Format(SearchQuery, ApiRoot.TheMovieDB, query);
            var response = await client.GetAsync(url);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var post = JsonConvert.DeserializeObject<SearchRoot>(content);
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