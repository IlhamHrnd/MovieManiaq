namespace MovieManiaq.Model.Response.Geocoding
{
    public class ReverseGeocodingModel
    {
        public class Bbox
        {
            public double lon1 { get; set; }
            public double lat1 { get; set; }
            public double lon2 { get; set; }
            public double lat2 { get; set; }
        }

        public class Datasource
        {
            public string sourcename { get; set; }
            public string attribution { get; set; }
            public string license { get; set; }
            public string url { get; set; }
        }

        public class Rank
        {
            public double importance { get; set; }
            public double popularity { get; set; }
        }

        public class Result
        {
            public Datasource datasource { get; set; }
            public string country { get; set; }
            public string country_code { get; set; }
            public double lon { get; set; }
            public double lat { get; set; }
            public int distance { get; set; }
            public string result_type { get; set; }
            public string formatted { get; set; }
            public string address_line1 { get; set; }
            public string address_line2 { get; set; }
            public string category { get; set; }
            public Timezone timezone { get; set; }
            public Rank rank { get; set; }
            public string place_id { get; set; }
            public Bbox bbox { get; set; }
        }

        public class ReverseGeocodingRoot
        {
            public List<Result> results { get; set; }
        }

        public class Timezone
        {
            public string name { get; set; }
            public string offset_STD { get; set; }
            public int offset_STD_seconds { get; set; }
            public string offset_DST { get; set; }
            public int offset_DST_seconds { get; set; }
            public string abbreviation_STD { get; set; }
            public string abbreviation_DST { get; set; }
        }
    }
}
