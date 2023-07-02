namespace MovieManiaq.Model.Root
{
    public class ApiRoot
	{
		public ApiRoot()
		{

		}

        //API Key UI Kit
        private static string syncfucion = "MjUzNDA1MkAzMjMyMmUzMDJlMzBMRjZHK0NBTXhhVWluNTd5OGFHMnM4T0lpejZ6d0hPMzZ4ZWF1QUhJZFVBPQ==";

        public static string Syncfucion
        {
            get { return syncfucion; }
            set { syncfucion = value; }
        }

        //API Key Untuk Production
        private static string themoviedb = "a173a42ac2309ccc70dc04a4fa1188cc";

        public static string TheMovieDB
        {
            get { return themoviedb; }
            set { themoviedb = value; }
        }

        //API Key Untuk Production
        private static string youtubeapilayer = "n6oWHaCuwow1sDzEIi5b1aRsAkri2943";

        public static string YouTubeAPILayer
        {
            get { return youtubeapilayer; }
            set { youtubeapilayer = value; }
        }

        //API Key Untuk Production
        private static string geoapify = "38ae614765f24647ac2f3dbe6c8a1035";

        public static string GeoAPify
        {
            get { return geoapify; }
            set { geoapify = value; }
        }

        //API Key Untuk Production
        //private static string rapidapi = "6af9da9c8emsh8c9f65f79d75211p189b4fjsn44455f2f40da";

        //public static string RapidAPI
        //{
        //    get { return rapidapi; }
        //    set { rapidapi = value; }
        //}

        //API Key Untuk Testing
        private static string rapidapi = "6219c891camsh4b45be529f36f81p1c71cfjsn8bf7cb5004f7";

        public static string RapidAPI
        {
            get { return rapidapi; }
            set { rapidapi = value; }
        }
    }
}

