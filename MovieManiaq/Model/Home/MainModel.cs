using MovieManiaq.Model.Root;
using System.Collections.ObjectModel;
using static MovieManiaq.Model.Response.NowShowingModel;
using static MovieManiaq.Model.Response.PopularModel;
using static MovieManiaq.Model.Response.TopRatedModel;
using static MovieManiaq.Model.Response.TrendingModel;
using static MovieManiaq.Model.Response.UpComingModel;

namespace MovieManiaq.Model.Home
{
    public class MainModel : BaseModel
    {
        public MainModel()
        {

        }

        private string title = "Home";

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
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

        private int trendingid = 0;

        public int TrendingID
        {
            get { return trendingid; }
            set { SetProperty(ref trendingid, value); }
        }

        private int nowplayingid = 0;

        public int NowPlayingID
        {
            get { return nowplayingid; }
            set { SetProperty(ref nowplayingid, value); }
        }

        private int upcomingid = 0;

        public int UpComingID
        {
            get { return upcomingid; }
            set { SetProperty(ref upcomingid, value); }
        }

        private int topratedid = 0;

        public int TopRatedID
        {
            get { return topratedid; }
            set { SetProperty(ref topratedid, value); }
        }

        private int popularid = 0;

        public int PopularID
        {
            get { return popularid; }
            set { SetProperty(ref popularid, value); }
        }

        private IList<TrendingRoot> listtrending { get; set; }

        public IList<TrendingRoot> ListTrending
        {
            get
            {
                if (listtrending == null)
                {
                    listtrending = new ObservableCollection<TrendingRoot>();
                }
                return listtrending;
            }
            set { listtrending = value;}
        }

        private IList<UpComingRoot> listupcoming { get; set; }

        public IList<UpComingRoot> ListUpComing
        {
            get
            {
                if (listupcoming == null)
                {
                    listupcoming= new ObservableCollection<UpComingRoot>();
                }
                return listupcoming;
            }
            set { listupcoming = value;}
        }

        private IList<NowShowingRoot> listnowshowing { get; set; }

        public IList<NowShowingRoot> ListNowShowing
        {
            get
            {
                if (listnowshowing == null)
                {
                    listnowshowing = new ObservableCollection<NowShowingRoot>();
                }
                return listnowshowing;
            }
            set { listnowshowing = value; }
        }

        private IList<TopRatedRoot> listtoprated { get; set; }

        public IList<TopRatedRoot> ListTopRated
        {
            get
            {
                if (listtoprated == null)
                {
                    listtoprated = new ObservableCollection<TopRatedRoot>();
                }
                return listtoprated;
            }
            set { listtoprated = value; }
        }

        private IList<PopularRoot> listpopular { get; set; }

        public IList<PopularRoot> ListPopular
        {
            get
            {
                if (listpopular == null)
                {
                    listpopular = new ObservableCollection<PopularRoot>();
                }
                return listpopular;
            }
            set { listpopular = value; }
        }
    }
}
