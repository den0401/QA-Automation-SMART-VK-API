using Newtonsoft.Json;

namespace QA_Automation_SMART_VK_API.Testing.Models
{
    public class PhotoModel
    {
        [JsonProperty("response")]
        public ResponseBody[] Response { get; set; }

        public class ResponseBody
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("album_id")]
            public int AlbumId { get; set; }

            [JsonProperty("owner_id")]
            public int OwnerId { get; set; }

            [JsonProperty("user_id")]
            public int UserId { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }

            [JsonProperty("date")]
            public int Date { get; set; }
        }
    }
}