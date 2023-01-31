using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static MovieManiaq.Model.Response.Movie.CreditsModel;
using static MovieManiaq.Model.Response.Movie.DetailModel;
using static MovieManiaq.Model.Response.Movie.ImagesModel;
using static MovieManiaq.Model.Response.Movie.KeywordModel;

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

        private IList<DetailRoot> listdetail { get; set; }

        public IList<DetailRoot> ListDetail
        {
            get
            {
                if (listdetail == null)
                {
                    listdetail = new ObservableCollection<DetailRoot>();
                }

                return listdetail;
            }
            set { listdetail = value; }
        }

        private IList<CreditsRoot> listcredits { get; set; }

        public IList<CreditsRoot> ListCredits
        {
            get
            {
                if (listcredits == null)
                {
                    listcredits = new ObservableCollection<CreditsRoot>();
                }

                return listcredits;
            }
            set { listcredits = value; }
        }

        private IList<ImagesRoot> listimages { get; set; }

        public IList<ImagesRoot> ListImages
        {
            get
            {
                if (listimages == null)
                {
                    listimages = new ObservableCollection<ImagesRoot>();
                }

                return listimages;
            }
            set { listimages = value; }
        }

        private IList<KeywordRoot> listkeyword { get; set; }

        public IList<KeywordRoot> ListKeyword
        {
            get
            {
                if (listkeyword == null)
                {
                    listkeyword = new ObservableCollection<KeywordRoot>();
                }

                return listkeyword;
            }
            set { listkeyword = value; }
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
