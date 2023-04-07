using MovieManiaq.Model.Root;
using System.Collections.ObjectModel;
using static MovieManiaq.Model.Response.Github.CommitHistoryModel;

namespace MovieManiaq.Model.Home
{
    public class GithubCommitModel : BaseModel
    {
        public GithubCommitModel()
        {
            
        }

        private string title = "Changelog";

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

        private IList<CommitHistoryRoot> listcommithostory { get; set; }

        public IList<CommitHistoryRoot> ListCommitHistory
        {
            get
            {
                if (listcommithostory == null)
                {
                    listcommithostory = new ObservableCollection<CommitHistoryRoot>();
                }
                return listcommithostory;
            }
            set { listcommithostory = value; }
        }
    }
}
