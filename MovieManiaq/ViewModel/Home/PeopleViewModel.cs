﻿using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MovieManiaq.Model.Home;
using MovieManiaq.Model.Root;
using MovieManiaq.ViewModel.RestAPI.People.Index;
using static MovieManiaq.Model.Response.People.Index.TrendingModel;

namespace MovieManiaq.ViewModel.Home
{
    public class PeopleViewModel : PeopleModel
    {
        private readonly NetworkModel network = new NetworkModel();

        private readonly INavigation _navigation;

        public PeopleViewModel(INavigation navigation)
        {
            _navigation = navigation;

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
                var trending = await TrendingClass.GetTrendingAsync(Page);
                ListTrending.Clear();
                ListTrending.Add(trending);
            }

            else
            {
                NetworkModel.NoConnection();
            }

            IsBusy = false;
            IsVisible = false;
        }

        public async void PeopleSelection(SelectionChangedEventArgs e)
        {
            var peopleID = e.CurrentSelection[0] as Result;

            if (peopleID != null)
            {
                //Notif Only
                //Next Time Design Detail People
                var toast = Toast.Make(string.Format("You Have Selected {0}", peopleID.name), ToastDuration.Long);
                await toast.Show();
            }
        }

        public async void NextPage()
        {
            var maxPage = ListTrending[0].total_pages;

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
                    var nextPage = ListTrending[0].page + 1;

                    var next = await TrendingClass.GetTrendingAsync(nextPage);
                    ListTrending.Clear();
                    ListTrending.Add(next);
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
                    var previousPage = ListTrending[0].page - 1;

                    var previous = await TrendingClass.GetTrendingAsync(previousPage);
                    ListTrending.Clear();
                    ListTrending.Add(previous);
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
