namespace MovieManiaq.Model.Response.People
{
    public class CreditsModel
    {
        public CreditsModel()
        {
            
        }

        public class Cast
        {
            public string character { get; set; }
            public string credit_id { get; set; }
            public string release_date { get; set; }
            public int vote_count { get; set; }
            public bool video { get; set; }
            public bool adult { get; set; }
            public double vote_average { get; set; }
            public string title { get; set; }
            public List<int> genre_ids { get; set; }
            public string original_language { get; set; }
            public string original_title { get; set; }
            public double popularity { get; set; }
            public int id { get; set; }
            public string backdrop_path { get; set; }
            public string backdrop_url
            {
                get
                {
                    return string.Format("{0}{1}", "https://image.tmdb.org/t/p/w500", backdrop_path);
                }
            }
            public string overview { get; set; }
            public string poster_path { get; set; }
            public string poster_url
            {
                get
                {
                    return string.Format("{0}{1}", "https://image.tmdb.org/t/p/w500", poster_path);
                }
            }
        }

        public class Crew
        {
            public int id { get; set; }
            public string department { get; set; }
            public string original_language { get; set; }
            public string original_title { get; set; }
            public string job { get; set; }
            public string overview { get; set; }
            public int vote_count { get; set; }
            public bool video { get; set; }
            public string poster_path { get; set; }
            public string poster_url
            {
                get
                {
                    return string.Format("{0}{1}", "https://image.tmdb.org/t/p/w500", poster_path);
                }
            }
            public string backdrop_path { get; set; }
            public string backdrop_url
            {
                get
                {
                    return string.Format("{0}{1}", "https://image.tmdb.org/t/p/w500", backdrop_path);
                }
            }
            public string title { get; set; }
            public double popularity { get; set; }
            public List<int> genre_ids { get; set; }
            public double vote_average { get; set; }
            public bool adult { get; set; }
            public string release_date { get; set; }
            public string credit_id { get; set; }
        }

        public class CreditsRoot
        {
            public List<Cast> cast { get; set; }
            public List<Crew> crew { get; set; }
            public int id { get; set; }
        }
    }
}
