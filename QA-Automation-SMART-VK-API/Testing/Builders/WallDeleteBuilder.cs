using QA_Automation_SMART_VK_API.Utils;

namespace QA_Automation_SMART_VK_API.Testing.Builders
{
    public class WallDeleteBuilder : BaseBuilder
    {
        public static int PostId { get; set; }

        public WallDeleteBuilder(int ownerId, int postId)
        {
            OwnerId = ownerId;
            PostId = postId;
            RequestUrl = _apiUrl + ConfigAndDataUtils.GetApiProperty("wall_delete") +
                "owner_id=" + ownerId + "&post_id=" + postId + "&access_token=" + _accessToken +
                "&v=" + _apiVersion;
        }
    }
}