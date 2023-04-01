namespace MovieManiaq.Model.Response.Movie
{
    public class ListYouTubeModel
    {
        public class ListYouTubeRoot
        {
            public List<YouTube> youtube { get; set; }
        }

        public class YouTube
        {
            public string title { get; set; }
            public string url { get; set; }
            public string site
            {
                get
                {
                    return "YouTube";
                }
            }
            public DateTime publish { get; set; }
        }
    }
}
