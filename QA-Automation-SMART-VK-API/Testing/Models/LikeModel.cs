using Newtonsoft.Json;

namespace QA_Automation_SMART_VK_API.Testing.Models
{
    public class LikeModel
    {
        [JsonProperty("response")]
        public ResponseBody Response { get; set; }

        public class ResponseBody
        {
            [JsonProperty("liked")]
            public int Liked { get; set; }

            [JsonProperty("reposted")]
            public int Reposted { get; set; }
        }
    }
}