using MovieManiaq.Model.Root;
using System.Collections.ObjectModel;
using static MovieManiaq.Model.Response.Movie.CreditsModel;
using static MovieManiaq.Model.Response.Movie.DetailModel;
using static MovieManiaq.Model.Response.Movie.ImagesModel;
using static MovieManiaq.Model.Response.Movie.KeywordModel;
using static MovieManiaq.Model.Response.Movie.RecommendationsModel;
using static MovieManiaq.Model.Response.Movie.ReviewModel;
using static MovieManiaq.Model.Response.Movie.SimiliarModel;
using static MovieManiaq.Model.Response.Movie.VideoModel;

namespace MovieManiaq.Model.Detail
{
    public class DetailMovieModel : BaseModel
    {

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

        private IList<VideoRoot> listvideo { get; set; }

        public IList<VideoRoot> ListVideo
        {
            get
            {
                if (listvideo == null)
                {
                    listvideo = new ObservableCollection<VideoRoot>();
                }

                return listvideo;
            }
            set { listvideo = value; }
        }

        private IList<RecommendationsRoot> listrecommendations { get; set; }

        public IList<RecommendationsRoot> ListRecommendations
        {
            get
            {
                if (listrecommendations == null)
                {
                    listrecommendations = new ObservableCollection<RecommendationsRoot>();
                }

                return listrecommendations;
            }
            set { listrecommendations = value; }
        }

        private IList<SimiliarRoot> listsimiliar { get; set; }

        public IList<SimiliarRoot> ListSimiliar
        {
            get
            {
                if (listsimiliar == null)
                {
                    listsimiliar = new ObservableCollection<SimiliarRoot>();
                }

                return listsimiliar;
            }
            set { listsimiliar = value; }
        }

        private IList<ReviewRoot> listreview { get; set; }

        public IList<ReviewRoot> ListReview
        {
            get
            {
                if (listreview == null)
                {
                    listreview = new ObservableCollection<ReviewRoot>();
                }

                return listreview;
            }
            set { listreview = value; }
        }
    }
}
