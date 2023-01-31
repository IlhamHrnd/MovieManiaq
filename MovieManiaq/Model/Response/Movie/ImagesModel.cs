namespace MovieManiaq.Model.Response.Movie
{
    public class ImagesModel
    {
        public class Backdrop
        {
            public double aspect_ratio { get; set; }
            public int height { get; set; }
            public string iso_639_1 { get; set; }
            public string file_path { get; set; }
            public string file_url
            {
                get
                {
                    return string.Format("{0}{1}", "https://image.tmdb.org/t/p/w500", file_path);
                }
            }
            public double vote_average { get; set; }
            public int vote_count { get; set; }
            public int width { get; set; }
        }

        public class Logo
        {
            public double aspect_ratio { get; set; }
            public int height { get; set; }
            public string iso_639_1 { get; set; }
            public string file_path { get; set; }
            public string file_url
            {
                get
                {
                    return string.Format("{0}{1}", "https://image.tmdb.org/t/p/w500", file_path);
                }
            }
            public double vote_average { get; set; }
            public int vote_count { get; set; }
            public int width { get; set; }
        }

        public class Poster
        {
            public double aspect_ratio { get; set; }
            public int height { get; set; }
            public string iso_639_1 { get; set; }
            public string file_path { get; set; }
            public string file_url
            {
                get
                {
                    return string.Format("{0}{1}", "https://image.tmdb.org/t/p/w500", file_path);
                }
            }
            public double vote_average { get; set; }
            public int vote_count { get; set; }
            public int width { get; set; }
        }

        public class ImagesRoot
        {
            public List<Backdrop> backdrops { get; set; }
            public int id { get; set; }
            public List<Logo> logos { get; set; }
            public List<Poster> posters { get; set; }
        }
    }
}
