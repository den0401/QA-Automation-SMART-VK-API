using Newtonsoft.Json;

namespace QA_Automation_SMART_VK_API.Testing.Models
{
    public class UploadServerModel
    {
        [JsonProperty("response")]
        public ResponseBody Response { get; set; }

        public class ResponseBody
        {
            [JsonProperty("album_id")]
            public int AlbumId { get; set; }

            [JsonProperty("upload_url")]
            public string UploadUrl { get; set; }

            [JsonProperty("user_id")]
            public int UserId { get; set; }
        }
    }
}