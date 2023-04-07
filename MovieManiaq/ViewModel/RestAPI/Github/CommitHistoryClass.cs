using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Newtonsoft.Json;
using RestSharp;
using static MovieManiaq.Model.Response.Github.CommitHistoryModel;

namespace MovieManiaq.ViewModel.RestAPI.Github
{
    public class CommitHistoryClass
    {
        public CommitHistoryClass()
        {
            
        }

        private const string CommitHistoryQuery = "https://api.github.com/repos/IlhamHrnd/MovieManiaq/commits";

        public static async Task<List<CommitHistoryRoot>> GetCommitHistoryAsync()
        {
            List<CommitHistoryRoot> root = new List<CommitHistoryRoot>();
            string url = string.Format(CommitHistoryQuery);
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
                    var get = JsonConvert.DeserializeObject<List<CommitHistoryRoot>>(content);
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
