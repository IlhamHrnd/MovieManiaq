using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MovieManiaq.Model.Root;
using Newtonsoft.Json;
using RestSharp;
using static MovieManiaq.Model.Response.Currency.CurrencyModel;

namespace MovieManiaq.ViewModel.RestAPI.Currency
{
    public class CurrencyClass
    {
        public CurrencyClass()
        {
            
        }

        private const string CurrencyQuery = "https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=USD&to={0}&amount={1}";

        public static async Task<CurrencyRoot> GetCurrencyAsync(string to, string amount)
        {
            CurrencyRoot root = new CurrencyRoot();
            string url = string.Format(CurrencyQuery, to, amount);
            var client = new RestClient(url);
            var request = new RestRequest
            {
                Method = Method.Get,
                Timeout = 10000
            };
            request.AddHeader("X-RapidAPI-Key", ApiRoot.RapidAPI);
            request.AddHeader("X-RapidAPI-Host", "currency-conversion-and-exchange-rates.p.rapidapi.com");
            var response = await client.ExecuteGetAsync(request);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content;
                    var get = JsonConvert.DeserializeObject<CurrencyRoot>(content);
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
                var toast = Toast.Make("Failed Retrieve Currency Data", ToastDuration.Long);
                await toast.Show();
            }
            return root;
        }
    }
}
