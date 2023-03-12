using MovieManiaq.Model.Root;
using MovieManiaq.Model.Search;
using MovieManiaq.View.Detail;
using MovieManiaq.ViewModel.RestAPI.People;
using static MovieManiaq.Model.Response.People.SearchModel;

namespace MovieManiaq.ViewModel.Search
{
    public class SearchPeopleViewModel : SearchPeopleModel
    {
        private readonly NetworkModel network = new NetworkModel();

        private readonly INavigation _navigation;

        public SearchPeopleViewModel(INavigation navigation)
        {
            _navigation = navigation;

            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        public async void PeopleSearch(object obj)
        {
            bool valid_connect = network.CekJaringan;

            IsVisible = true;
            IsBusy = true;

            if (valid_connect)
            {
                var press = obj as SearchBar;

                if (!string.IsNullOrEmpty(press.Text))
                {
                    var search = await SearchClass.GetSearchAsync(press.Text, Page);
                    ListSearch.Clear();
                    ListSearch.Add(search);
                    PeopleName = press.Text;
                    Page = search.page;
                }
            }

            else
            {
                NetworkModel.NoConnection();
            }

            IsVisible = false;
            IsBusy = false;
        }

        public async void PeopleSelection(SelectionChangedEventArgs e)
        {
            var peopleid = e.CurrentSelection[0] as Result;

            if (peopleid != null)
            {
                await _navigation.PushAsync(new DetailPeoplePage(peopleid.id));
            }
        }

        public async void NextPage()
        {
            var maxPage = ListSearch[0].total_pages;

            if (Page >= maxPage)
            {
                await Application.Current.MainPage.DisplayAlert("Latest Page", "This Is The Latest Page", "OK");
            }

            else
            {
                bool valid_connect = network.CekJaringan;

                IsVisible = true;
                IsBusy = true;

                if (valid_connect)
                {
                    var nextPage = ListSearch[0].page + 1;

                    var next = await SearchClass.GetSearchAsync(PeopleName, nextPage);
                    ListSearch.Clear();
                    ListSearch.Add(next);
                    Page = next.page;
                }

                else
                {
                    NetworkModel.NoConnection();
                }

                IsBusy = false;
                IsVisible = false;
            }
        }

        public async void PreviousPage()
        {
            if (Page <= 1)
            {
                await Application.Current.MainPage.DisplayAlert("First Page", "This Is The First Page", "OK");
            }

            else
            {
                bool valid_connect = network.CekJaringan;

                IsVisible = true;
                IsBusy = true;

                if (valid_connect)
                {
                    var previousPage = ListSearch[0].page - 1;

                    var previous = await SearchClass.GetSearchAsync(PeopleName, previousPage);
                    ListSearch.Clear();
                    ListSearch.Add(previous);
                    Page = previous.page;
                }

                else
                {
                    NetworkModel.NoConnection();
                }

                IsBusy = false;
                IsVisible = false;
            }
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            NetworkModel.Connectivity_ConnectivityChanged(sender, e);
        }
    }
}
