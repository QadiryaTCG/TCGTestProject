using Framework.Base;

namespace Framework.Config
{
    public class ConfigProperties
    {

       // public static BrowserType Browser { get; set; }

        public static string Environment { get; set; }

        public static string RunningAs { get; set; }

        private static bool _fileCreated = false;
        public static bool FileCreated
        {
            get
            {
                return _fileCreated;
            }
            set
            {
                _fileCreated = value;
            }
        }
    }
}
