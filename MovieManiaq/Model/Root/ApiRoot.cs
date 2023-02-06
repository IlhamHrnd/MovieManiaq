using System;
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
    }
}

