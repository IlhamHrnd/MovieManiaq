using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MovieManiaq.Model.Root;
using Newtonsoft.Json;
using RestSharp;
using static MovieManiaq.Model.Response.Geocoding.ReverseGeocodingModel;

namespace MovieManiaq.ViewModel.RestAPI.Geocoding
{
    public class ReverseGeocodingClass
    {
        public ReverseGeocodingClass()
        {
            
        }

        private const string ReverseGeocodingQuery = "https://api.geoapify.com/v1/geocode/reverse?lat={0}&lon={1}&type=country&limit=1&format=json&apiKey={2}";

        public static async Task<ReverseGeocodingRoot> GetReverseGeocodingAsync(string lat, string lon)
        {
            ReverseGeocodingRoot root = new ReverseGeocodingRoot();
            string url = string.Format(ReverseGeocodingQuery, lat, lon, ApiRoot.GeoAPify);
            var client = new RestClient(url);
            var request = new RestRequest
            {
                Method = Method.Get,
                Timeout = 10000
            };
            var response = await client.ExecuteGetAsync(request);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content;
                    var get = JsonConvert.DeserializeObject<ReverseGeocodingRoot>(content);
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
