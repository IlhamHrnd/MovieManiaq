namespace MovieManiaq.Model.Response.People
{
    public class DetailModel
    {
        public class DetailRoot
        {
            public string birthday { get; set; }
            public string known_for_department { get; set; }
            public object deathday { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public List<string> also_known_as { get; set; }
            public int gender { get; set; }
            public string gender_url
            {
                get
                {
                    if (gender == 1)
                    {
                        return string.Format("{0}", "Female");
                    }
                    else if (gender == 2)
                    {
                        return string.Format("{0}", "Male");
                    }
                    else
                    {
                        return string.Format("{0}", "Not Specified");
                    }
                }
            }
            public string biography { get; set; }
            public double popularity { get; set; }
            public string place_of_birth { get; set; }
            public string profile_path { get; set; }
            public string profile_url
            {
                get
                {
                    return string.Format("{0}{1}", "https://image.tmdb.org/t/p/w500", profile_path);
                }
            }
            public bool adult { get; set; }
            public string imdb_id { get; set; }
            public object homepage { get; set; }
        }
    }
}
