using MovieManiaq.Model.Detail;
using MovieManiaq.Model.Response.People;
using MovieManiaq.Model.Root;
using MovieManiaq.View.Detail;
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
                if (detail != null)
                {
                    ListDetail.Clear();
                    ListDetail.Add(detail);
                }

                var credits = await CreditsClass.GetCreditsAsync(PeopleID);
                if (credits.crew.Count > 0 || credits.cast.Count > 0)
                {
                    ListCredits.Clear();
                    ListCredits.Add(credits);
                }

                Title = detail.name;
            }

            else
            {
                NetworkModel.NoConnection();
            }

            IsBusy = false;
            IsVisible = false;
        }

        public async void CastSelection(SelectionChangedEventArgs e)
        {
            var movieID = e.CurrentSelection[0] as CreditsModel.Cast;

            if (movieID != null)
            {
                await _navigation.PushAsync(new DetailMoviePage(movieID.id));
            }
        }

        public async void CrewSelection(SelectionChangedEventArgs e)
        {
            var movieID = e.CurrentSelection[0] as CreditsModel.Crew;

            if (movieID != null)
            {
                await _navigation.PushAsync(new DetailMoviePage(movieID.id ));
            }
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            NetworkModel.Connectivity_ConnectivityChanged(sender, e);
        }
    }
}
