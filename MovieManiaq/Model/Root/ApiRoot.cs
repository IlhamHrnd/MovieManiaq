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
            get
            {
                if (!IsSyncfusionSet())
                {
                    SetSyncfucion(syncfucion);
                }
                
                return GetSyncfucion();
            }
            set
            {
                SetSyncfucion(syncfucion);
            }
        }

        private static string GetSyncfucion()
        {
            return SecureStorage.GetAsync(syncfucion).GetAwaiter().GetResult();
        }

        private static void SetSyncfucion(string apiKey)
        {
            SecureStorage.SetAsync(syncfucion, apiKey).GetAwaiter().GetResult();
        }

        public static bool IsSyncfusionSet()
        {
            return !string.IsNullOrEmpty(SecureStorage.GetAsync(syncfucion).GetAwaiter().GetResult());
        }

        //API Key Untuk Production
        private static string themoviedb = "a173a42ac2309ccc70dc04a4fa1188cc";

        public static string TheMovieDB
        {
            get
            {
                if (!IsTheMovieDBSet())
                {
                    SetTheMovieDB(themoviedb);
                }

                return GetTheMovieDB();
            }
            set
            {
                SetTheMovieDB(themoviedb);
            }
        }

        public static string GetTheMovieDB()
        {
            return SecureStorage.GetAsync(themoviedb).GetAwaiter().GetResult();
        }

        private static void SetTheMovieDB(string apiKey)
        {
            SecureStorage.SetAsync(themoviedb, apiKey).GetAwaiter().GetResult();
        }

        public static bool IsTheMovieDBSet()
        {
            return !string.IsNullOrEmpty(SecureStorage.GetAsync(themoviedb).GetAwaiter().GetResult());
        }

        //API Key Untuk Production
        private static string youtubeapilayer = "n6oWHaCuwow1sDzEIi5b1aRsAkri2943";

        public static string YouTubeAPILayer
        {
            get
            {
                if (!IsYouTubeAPILayerSet())
                {
                    SetYouTubeAPILayer(youtubeapilayer);
                }

                return GetYouTubeAPILayer();
            }
            set
            {
                SetYouTubeAPILayer(youtubeapilayer);
            }
        }

        public static string GetYouTubeAPILayer()
        {
            return SecureStorage.GetAsync(youtubeapilayer).GetAwaiter().GetResult();
        }

        public static void SetYouTubeAPILayer(string apiKey)
        {
            SecureStorage.SetAsync(youtubeapilayer, apiKey).GetAwaiter().GetResult();
        }

        public static bool IsYouTubeAPILayerSet()
        {
            return !string.IsNullOrEmpty(SecureStorage.GetAsync(youtubeapilayer).GetAwaiter().GetResult());
        }

        //API Key Untuk Production
        private static string geoapify = "38ae614765f24647ac2f3dbe6c8a1035";

        public static string GeoAPify
        {
            get
            {
                if (!IsGetAPifySet())
                {
                    SetGeoAPify(geoapify);
                }

                return GetGeoAPify();
            }
            set
            {
                SetGeoAPify(geoapify);
            }
        }

        public static string GetGeoAPify()
        {
            return SecureStorage.GetAsync(geoapify).GetAwaiter().GetResult();
        }

        public static void SetGeoAPify(string apiKey)
        {
            SecureStorage.SetAsync(geoapify, apiKey).GetAwaiter().GetResult();
        }

        public static bool IsGetAPifySet()
        {
            return !string.IsNullOrEmpty(SecureStorage.GetAsync(geoapify).GetAwaiter().GetResult());
        }

        //API Key Untuk Production
        private static string rapidapi = "6af9da9c8emsh8c9f65f79d75211p189b4fjsn44455f2f40da";

        public static string RapidAPI
        {
            get
            {
                if (!IsRapidAPISet())
                {
                    SetRapidAPI(rapidapi);
                }

                return GetRapidAPI();
            }
            set
            {
                SetRapidAPI(rapidapi);
            }
        }

        public static string GetRapidAPI()
        {
            return SecureStorage.GetAsync(rapidapi).GetAwaiter().GetResult();
        }

        public static void SetRapidAPI(string apiKey)
        {
            SecureStorage.SetAsync(rapidapi, apiKey).GetAwaiter().GetResult();
        }

        public static bool IsRapidAPISet()
        {
            return !string.IsNullOrEmpty(SecureStorage.GetAsync(rapidapi).GetAwaiter().GetResult());
        }

        ////API Key Untuk Testing
        //private static string rapidapi = "6219c891camsh4b45be529f36f81p1c71cfjsn8bf7cb5004f7";

        //public static string RapidAPI
        //{
        //    get { return rapidapi; }
        //    set { rapidapi = value; }
        //}
    }
}

