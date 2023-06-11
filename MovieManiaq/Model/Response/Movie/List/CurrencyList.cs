namespace MovieManiaq.Model.Response.Movie.List
{
    public class CurrencyList
    {
        public class CurrencyListRoot
        {
            public Result results {  get; set; }
            public string Symbols { get; set; }
        }

        public class Result
        {
            public double budget { get; set; }
            public double revenue { get; set; }
        }
    }
}
