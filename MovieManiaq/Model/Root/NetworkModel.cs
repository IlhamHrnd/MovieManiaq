using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManiaq.Model.Root
{
    public class NetworkModel
    {
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
            var toast = Toast.Make("You're Offline", ToastDuration.Long, 30);
            await toast.Show();
        }
    }
}
