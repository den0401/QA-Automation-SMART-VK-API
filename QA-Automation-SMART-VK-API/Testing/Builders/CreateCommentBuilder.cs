using QA_Automation_SMART_VK_API.Utils;

namespace QA_Automation_SMART_VK_API.Testing.Builders
{
    public class CreateCommentBuilder : BaseBuilder
    {
        public static string Message { get; set; }

        public CreateCommentBuilder(int ownerId, int postId, string message)
        {
            OwnerId = ownerId;
            Message = message;
            RequestUrl = _apiUrl + ConfigAndDataUtils.GetApiProperty("wall_create_comment") +
                "owner_id=" + ownerId + "&post_id=" + postId + "&message=" + message +
                "&access_token=" + _accessToken + "&v=" + _apiVersion;
        }
    }
}