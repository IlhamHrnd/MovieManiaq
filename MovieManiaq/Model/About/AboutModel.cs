using MovieManiaq.Model.Root;

namespace MovieManiaq.Model.About
{
    public class AboutModel : BaseModel
    {
        public AboutModel()
        {
            
        }

        private string name = AppInfo.Current.Name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string version = AppInfo.Current.VersionString;

        public string Version
        {
            get { return version; }
            set { SetProperty(ref version, value); }
        }

        private string build = AppInfo.Current.BuildString;

        public string Build
        {
            get { return build; }
            set { SetProperty(ref build, value); }
        }
    }
}
