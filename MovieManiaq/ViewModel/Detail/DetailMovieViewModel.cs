﻿using MovieManiaq.Model.Detail;
using MovieManiaq.Model.Root;
using MovieManiaq.ViewModel.RestAPI.Movie;

namespace MovieManiaq.ViewModel.Detail
{
    public class DetailMovieViewModel : DetailMovieModel
    {
        private readonly NetworkModel network = new NetworkModel();
        
        private readonly INavigation _navigation;

        public DetailMovieViewModel(INavigation navigation, int movieID)
        {
            _navigation = navigation;
            MovieID = movieID;

            LoadData();
        }

        private async void LoadData()
        {
            bool valid_connect = network.CekJaringan;

            IsVisible = true;
            IsBusy = true;

            if (valid_connect)
            {
                var detail = await DetailClass.GetDetailMovieAsync(MovieID);
                ListDetail.Clear();
                ListDetail.Add(detail);

                Title = detail.title;

                var credits = await CreditsClass.GetCreditsAsync(MovieID);
                ListCredits.Clear();
                ListCredits.Add(credits);

                var keyword = await KeywordClass.GetKeywordAsync(MovieID);
                ListKeyword.Clear();
                ListKeyword.Add(keyword);

                var images = await ImagesClass.GetImagesAsync(MovieID);
                ListImages.Clear();
                ListImages.Add(images);
            }

            IsBusy = false;
            IsVisible = false;
        }
    }
}
