using MovieManiaq.Model.Root;
using System.Collections.ObjectModel;
using static MovieManiaq.Model.Response.People.CreditsModel;
using static MovieManiaq.Model.Response.People.DetailModel;

namespace MovieManiaq.Model.Detail
{
    public class DetailPeopleModel : BaseModel
    {
        public DetailPeopleModel()
        {
            
        }

        private string title = string.Empty;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
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
    }
}
