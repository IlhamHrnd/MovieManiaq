namespace MovieManiaq.Model.Response.People.Index
{
    public class TrendingModel
    {
        public class KnownFor
        {
            public string backdrop_path { get; set; }
            public string first_air_date { get; set; }
            public List<int> genre_ids { get; set; }
            public int id { get; set; }
            public string media_type { get; set; }
            public string name { get; set; }
            public List<string> origin_country { get; set; }
            public string original_language { get; set; }
            public string original_name { get; set; }
            public string overview { get; set; }
            public string poster_path { get; set; }
            public double vote_average { get; set; }
            public int vote_count { get; set; }
            public bool? adult { get; set; }
            public string original_title { get; set; }
            public string release_date { get; set; }
            public string title { get; set; }
            public bool? video { get; set; }
        }

        public class Result
        {
            public bool adult { get; set; }
            public int gender { get; set; }
            public int id { get; set; }
            public List<KnownFor> known_for { get; set; }
            public string known_for_department { get; set; }
            public string name { get; set; }
            public double popularity { get; set; }
            public string profile_path { get; set; }
            public string profile_url
            {
                get
                {
                    return string.Format("{0}{1}", "https://image.tmdb.org/t/p/w500", profile_path);
                }
            }
        }

        public class TrendingRoot
        {
            public int page { get; set; }
            public List<Result> results { get; set; }
            public int total_pages { get; set; }
            public int total_results { get; set; }
        }
    }
}
