namespace MovieManiaq.Model.Root
{
    public class ApiRoot
	{
		public ApiRoot()
		{

		}

        private static string themoviedb = "a173a42ac2309ccc70dc04a4fa1188cc";

        public static string TheMovieDB
        {
            get { return themoviedb; }
            set { themoviedb = value; }
        }

        private static string youtubeapilayer = "n6oWHaCuwow1sDzEIi5b1aRsAkri2943";

        public static string YouTubeAPILayer
        {
            get { return youtubeapilayer; }
            set { youtubeapilayer = value; }
        }
    }
}

