namespace MovieManiaq.Model.Response.Movie
{
    public class ReviewModel
    {
        public class AuthorDetails
        {
            public string name { get; set; }
            public string username { get; set; }
            public string avatar_path { get; set; }
            public string avatar_url
            {
                get
                {
                    return string.Format("{0}{1}", "https://image.tmdb.org/t/p/w500", avatar_path);
                }
            }
            public double? rating { get; set; }
        }

        public class Result
        {
            public string author { get; set; }
            public AuthorDetails author_details { get; set; }
            public string content { get; set; }
            public DateTime created_at { get; set; }
            public string id { get; set; }
            public DateTime updated_at { get; set; }
            public string url { get; set; }
        }

        public class ReviewRoot
        {
            public int id { get; set; }
            public int page { get; set; }
            public List<Result> results { get; set; }
            public int total_pages { get; set; }
            public int total_results { get; set; }
        }
    }
}
