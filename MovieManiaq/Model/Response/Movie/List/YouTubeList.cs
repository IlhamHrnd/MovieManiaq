namespace MovieManiaq.Model.Response.Movie.List
{
    public class YouTubeList
    {
        public class YouTubeListRoot
        {
            public List<Result> result { get; set; }
        }

        public class Result
        {
            public string url { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public DateTime published_at { get; set; }
            public string site { get; set; }
        }
    }
}
