namespace MovieManiaq.Model.Response.Movie
{
    public class VideoModel
    {
        public class Result
        {
            public string iso_639_1 { get; set; }
            public string iso_3166_1 { get; set; }
            public string name { get; set; }
            public string key { get; set; }
            public string key_url
            {
                get
                {
                    if (site == "YouTube")
                    {
                        return string.Format("{0}{1}", "https://www.youtube.com/watch?v=", key);
                    }
                    else
                    {
                        return string.Format("{0}{1}", "https://vimeo.com/", key);
                    }
                }
            }
            public string site { get; set; }
            public int size { get; set; }
            public string type { get; set; }
            public bool official { get; set; }
            public DateTime published_at { get; set; }
            public string id { get; set; }
        }

        public class VideoRoot
        {
            public int id { get; set; }
            public List<Result> results { get; set; }
        }
    }
}
