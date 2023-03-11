using MovieManiaq.Model.Root;
using System.Collections.ObjectModel;
using static MovieManiaq.Model.Response.People.SearchModel;

namespace MovieManiaq.Model.Search
{
    public class SearchPeopleModel : BaseModel
    {
        public SearchPeopleModel()
        {
            
        }

        private int page = 1;

        public int Page
        {
            get { return page; }
            set { SetProperty(ref page, value); }
        }

        private string peoplename = string.Empty;

        public string PeopleName
        {
            get { return peoplename; }
            set { SetProperty(ref peoplename, value); }
        }

        private int peopleid = 0;

        public int PeopleID
        {
            get { return peopleid; }
            set { SetProperty(ref peopleid, value); }
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
    }
}
