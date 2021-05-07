using Newtonsoft.Json;
using System.IO;
using System.Text;
namespace Moaa
{
    public struct Json_Config
    {
        [JsonProperty("Token")]
        public string Token { get; private set; }
        [JsonProperty("Prefix")]
        public string Prefix { get; private set; }
    }
    class JSON
    {
        public static Json_Config Config()
        {
            var JSON = string.Empty;

            using (var filestream = File.OpenRead(@"D:\Discord_BOT\Discord_BOT\BOT\Config.json"))
            {
                using (var streamreader = new StreamReader(filestream, new UTF8Encoding(false)))
                {
                    JSON = streamreader.ReadToEnd();
                }
            }
            var json_config = JsonConvert.DeserializeObject<Json_Config>(JSON);
            return json_config;
        }
    }
}