namespace MovieManiaq.Model.Response.Country
{
    public class CountryModel
    {
        public class Datum
        {
            public string code { get; set; }
            public List<string> countryCodes { get; set; }
            public string symbol { get; set; }
        }

        public class Metadata
        {
            public int currentOffset { get; set; }
            public int totalCount { get; set; }
        }

        public class CountryRoot
        {
            public List<Datum> data { get; set; }
            public Metadata metadata { get; set; }
        }
    }
}
