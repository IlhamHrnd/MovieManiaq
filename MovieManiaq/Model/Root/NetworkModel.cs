using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace MovieManiaq.Model.Root
{
    public class NetworkModel
    {
        private static readonly NetworkModel network = new NetworkModel();

        public NetworkModel()
        {

        }

        private bool cekjaringan()
        {
            NetworkAccess access = Connectivity.Current.NetworkAccess;

            if (access == NetworkAccess.Internet)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CekJaringan
        {
            get { return cekjaringan(); }
        }

        public static async void NoConnection()
        {
            var toast = Toast.Make("You're Offline", ToastDuration.Long);
            await toast.Show();
        }

        public static async void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            bool valid_connect = network.CekJaringan;

            if (!valid_connect)
            {
                NoConnection();
            }

            else if (valid_connect)
            {
                var toast = Toast.Make("Back Online", ToastDuration.Long);
                await toast.Show();
            }
        }
    }
}
