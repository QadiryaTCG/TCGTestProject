using Newtonsoft.Json;
using Framework.Base;

namespace Framework.Config
{
    [JsonObject("testSettings")]
    public class ConfigModel
    {

        //[JsonProperty("browser")]
        //public BrowserType Browser { get; set; }

        [JsonProperty("Environment")]
        public string Environment { get; set; }

        [JsonProperty("runningAs")]
        public string RunningAs { get; set; }

    }
}
