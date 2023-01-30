using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static MovieManiaq.Model.Response.Movie.DetailModel;

namespace MovieManiaq.Model.Detail
{
    public class DetailMovieModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DetailMovieModel()
        {

        }

        private string title = string.Empty;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private int movieid = 0;

        public int MovieID
        {
            get { return movieid; }
            set { SetProperty(ref movieid, value);}
        }

        private bool isbusy = false;

        public bool IsBusy
        {
            get { return isbusy; }
            set { SetProperty(ref isbusy, value); }
        }

        private bool isvisible = false;

        public bool IsVisible
        {
            get { return isvisible; }
            set { SetProperty(ref isvisible, value); }
        }

        private IList<DetailRoot> listdetailmovie { get; set; }

        public IList<DetailRoot> ListDetailMovie
        {
            get
            {
                if (listdetailmovie == null)
                {
                    listdetailmovie = new ObservableCollection<DetailRoot>();
                }

                return listdetailmovie;
            }
            set { listdetailmovie = value; }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;

            if (changed == null)
            {
                return;
            }

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }
            else
            {
                backingStore = value;
                OnPropertyChanged(propertyName);
                return true;
            }
        }
    }
}
