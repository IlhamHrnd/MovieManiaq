﻿namespace MovieManiaq.Model.Response.Currency
{
    public class CurrencyModel
    {
        public class Info
        {
            public double rate { get; set; }
            public int timestamp { get; set; }
        }

        public class Query
        {
            public int amount { get; set; }
            public string from { get; set; }
            public string to { get; set; }
        }

        public class CurrencyRoot
        {
            public string date { get; set; }
            public Info info { get; set; }
            public Query query { get; set; }
            public double result { get; set; }
            public bool success { get; set; }
        }
    }
}
