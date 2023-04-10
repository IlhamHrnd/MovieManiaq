using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MovieManiaq.Model.Root;
using Newtonsoft.Json;
using RestSharp;
using static MovieManiaq.Model.Response.Country.CountryModel;

namespace MovieManiaq.ViewModel.RestAPI.Country
{
    public class CountryClass
    {
        public CountryClass()
        {
            
        }

        private const string CountryQuery = "https://wft-geo-db.p.rapidapi.com/v1/locale/currencies?countryId={0}";

        public static async Task<CountryRoot> GetCountryAsync(string country)
        {
            CountryRoot root = new CountryRoot();
            string url = string.Format(CountryQuery, country);
            var client = new RestClient(url);
            var request = new RestRequest
            {
                Method = Method.Get,
                Timeout = 10000
            };
            request.AddHeader("X-RapidAPI-Key", ApiRoot.RapidAPI);
            request.AddHeader("X-RapidAPI-Host", "wft-geo-db.p.rapidapi.com");
            var response = await client.ExecuteGetAsync(request);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content;
                    var get = JsonConvert.DeserializeObject<CountryRoot>(content);
                    root = get;
                }
                else
                {
                    var toast = Toast.Make(response.ErrorException.Message, ToastDuration.Long);
                    await toast.Show();
                }
            }
            catch (Exception e)
            {
                var toast = Toast.Make(e.Message, ToastDuration.Long);
                await toast.Show();
            }
            return root;
        }
    }
}
