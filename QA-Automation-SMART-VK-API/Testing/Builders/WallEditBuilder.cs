using QA_Automation_SMART_VK_API.Utils;

namespace QA_Automation_SMART_VK_API.Testing.Builders
{
    public class WallEditBuilder : BaseBuilder
    {
        public static int PostId { get; set; }
        public static string Message { get; set; }

        public WallEditBuilder(int ownerId, int postId, string message, string attachment)
        {
            OwnerId = ownerId;
            Message = message;
            PostId = postId;
            RequestUrl = _apiUrl + ConfigAndDataUtils.GetApiProperty("wall_edit") +
                "owner_id=" + ownerId + "&post_id=" + postId + "&message=" + message +
                "&attachment=" + attachment + "&access_token=" + _accessToken + "&v=" + _apiVersion;
        }
    }
}