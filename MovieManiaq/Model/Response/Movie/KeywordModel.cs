namespace MovieManiaq.Model.Response.Movie
{
    public class KeywordModel
    {
        public class Keyword
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class KeywordRoot
        {
            public int id { get; set; }
            public List<Keyword> keywords { get; set; }
        }
    }
}
