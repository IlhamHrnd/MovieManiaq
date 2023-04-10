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

        private static string geoapify = "38ae614765f24647ac2f3dbe6c8a1035";

        public static string GeoAPify
        {
            get { return geoapify; }
            set { geoapify = value; }
        }

        private static string rapidapi = "6219c891camsh4b45be529f36f81p1c71cfjsn8bf7cb5004f7";

        public static string RapidAPI
        {
            get { return rapidapi; }
            set { rapidapi = value; }
        }
    }
}

