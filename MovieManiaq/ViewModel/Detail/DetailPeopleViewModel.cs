using MovieManiaq.Model.Detail;
using MovieManiaq.Model.Root;
using MovieManiaq.ViewModel.RestAPI.People;

namespace MovieManiaq.ViewModel.Detail
{
    public class DetailPeopleViewModel : DetailPeopleModel
    {
        private readonly NetworkModel network = new NetworkModel();

        private readonly INavigation _navigation;

        public DetailPeopleViewModel(INavigation navigation, int peopleid)
        {
            _navigation = navigation;
            PeopleID = peopleid;

            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

            Load_Data();
        }

        private async void Load_Data()
        {
            bool valid_connect = network.CekJaringan;

            IsVisible = true;
            IsBusy = true;

            if (valid_connect)
            {
                var detail = await DetailClass.GetDetailMovieAsync(PeopleID);
                ListDetail.Clear();
                ListDetail.Add(detail);
                Title = detail.name;
            }

            else
            {
                NetworkModel.NoConnection();
            }

            IsBusy = false;
            IsVisible = false;
        }
        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            NetworkModel.Connectivity_ConnectivityChanged(sender, e);
        }
    }
}
