using MovieManiaq.Model.Root;
using System.Collections.ObjectModel;
using static MovieManiaq.Model.Response.People.Index.TrendingModel;

namespace MovieManiaq.Model.Home
{
    public class PeopleModel : BaseModel
    {
        public PeopleModel()
        {
            
        }

        private string title = "People";

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

        private int page = 1;

        public int Page
        {
            get { return page; }
            set { SetProperty(ref page, value); }
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
            set { listtrending = value; }
        }
    }
}
