using MovieManiaq.Model.Root;
using System.Collections.ObjectModel;
using static MovieManiaq.Model.Response.Movie.DetailModel;
using static MovieManiaq.Model.Response.Movie.SearchModel;

namespace MovieManiaq.Model.Search
{
    public class SearchMovieModel : BaseModel
    {
        public SearchMovieModel()
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
            set { SetProperty(ref movieid, value); }
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

        private IList<SearchRoot> listsearch { get; set; }

        public IList<SearchRoot> ListSearch
        {
            get
            {
                if (listsearch == null)
                {
                    listsearch = new ObservableCollection<SearchRoot>();
                }

                return listsearch;
            }
            set { listsearch = value; }
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
    }
}
