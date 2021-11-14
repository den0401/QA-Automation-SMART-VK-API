using Newtonsoft.Json;

namespace QA_Automation_SMART_VK_API.Testing.Models
{
    public class UploadResponseModel
    {
        [JsonProperty("server")]
        public int Server { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }
    }
}