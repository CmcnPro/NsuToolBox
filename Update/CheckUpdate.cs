using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace Update
{
    public class CheckUpdate
    {
        private string lastVersion;
        private string currentVersion;
        private string jsonTest;
        private string uri = "https://api.github.com/repos/CmcnPro/NsuToolBox/releases";

        public string LastVersion
        {
            get
            {
                return lastVersion;
            }

            set
            {
                lastVersion = value;
            }
        }

        public string CurrentVersion
        {
            get
            {
                return currentVersion;
            }

            set
            {
                currentVersion = value;
            }
        }

        public string JsonTest
        {
            get
            {
                return jsonTest;
            }

            set
            {
                jsonTest = value;
            }
        }

        public void getJson()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add(
            "User-Agent",
            "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
            var result = httpClient.GetStringAsync(uri).Result;
            this.JsonTest = result;
        }

        public void getLastVersion()
        {
            JArray ja = (JArray)JsonConvert.DeserializeObject(jsonTest);
            this.LastVersion = ja[0]["tag_name"].ToString();
        }
    }
}
