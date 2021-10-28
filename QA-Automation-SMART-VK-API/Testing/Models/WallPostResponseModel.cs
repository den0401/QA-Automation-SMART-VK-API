using Newtonsoft.Json;

namespace QA_Automation_SMART_VK_API.Testing.Models
{
    public class WallPostResponseModel
    {
        [JsonProperty("response")]
        public ResponseBody Response { get; set; }

        public class ResponseBody
        {
            [JsonProperty("post_id")]
            public int Id { get; set; }
        }
    }
}