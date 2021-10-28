using Newtonsoft.Json;

namespace QA_Automation_SMART_VK_API.Testing.Models
{
    public class CommentModel
    {
        [JsonProperty("response")]
        public ResponseBody Response { get; set; }

        public class ResponseBody
        {
            [JsonProperty("comment_id")]
            public int Id { get; set; }
        }
    }
}