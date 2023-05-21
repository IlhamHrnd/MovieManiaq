using System.Globalization;

namespace MovieManiaq.Model.Response.Movie
{
    public class DetailModel
    {
        public class Genre
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class ProductionCompany
        {
            public int id { get; set; }
            public string logo_path { get; set; }
            public string logo_url
            {
                get
                {
                    return string.Format("{0}{1}", "https://image.tmdb.org/t/p/w500", logo_path);
                }
            }
            public string name { get; set; }
            public string origin_country { get; set; }
        }

        public class ProductionCountry
        {
            public string iso_3166_1 { get; set; }
            public string name { get; set; }
        }

        public class DetailRoot
        {
            public bool adult { get; set; }
            public string backdrop_path { get; set; }
            public string background_url
            {
                get
                {
                    return string.Format("{0}{1}", "https://image.tmdb.org/t/p/w500", backdrop_path);
                }
            }
            public object belongs_to_collection { get; set; }
            public long budget { get; set; }
            public string budget_currency
            {
                get { return budget.ToString("C", CultureInfo.CreateSpecificCulture("en-US")); }
            }
            public List<Genre> genres { get; set; }
            public string homepage { get; set; }
            public int id { get; set; }
            public string imdb_id { get; set; }
            public string original_language { get; set; }
            public string original_title { get; set; }
            public string overview { get; set; }
            public double popularity { get; set; }
            public string poster_path { get; set; }
            public string poster_url
            {
                get
                {
                    return string.Format("{0}{1}", "https://image.tmdb.org/t/p/w500", poster_path);
                }
            }
            public List<ProductionCompany> production_companies { get; set; }
            public List<ProductionCountry> production_countries { get; set; }
            public string release_date { get; set; }
            public long revenue { get; set; }
            public string revenue_currency
            {
                get
                {
                    return revenue.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                }
            }
            public int runtime { get; set; }
            public string runtime_hours
            {

                get
                {
                    var count = TimeSpan.FromMinutes(runtime);
                    return string.Format("{0}:{1:00}", (int)count.TotalHours, count.Minutes);
                }
            }
            public List<SpokenLanguage> spoken_languages { get; set; }
            public string status { get; set; }
            public string tagline { get; set; }
            public string title { get; set; }
            public bool video { get; set; }
            public double vote_average { get; set; }
            public int vote_count { get; set; }
        }

        public class SpokenLanguage
        {
            public string iso_639_1 { get; set; }
            public string name { get; set; }
        }
    }
}
