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
    }
}
