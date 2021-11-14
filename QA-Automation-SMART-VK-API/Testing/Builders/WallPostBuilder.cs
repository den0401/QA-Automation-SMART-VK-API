using QA_Automation_SMART_VK_API.Utils;

namespace QA_Automation_SMART_VK_API.Testing.Builders
{
    public class WallPostBuilder : BaseBuilder
    {
        public static string Message { get; set; }

        public WallPostBuilder (int ownerId, string message)
        { 
            OwnerId = ownerId; 
            Message = message;
            RequestUrl = _apiUrl + ConfigAndDataUtils.GetApiProperty("wall_post") +
                "owner_id=" + ownerId + "&message=" + message + "&access_token=" + _accessToken +
                "&v=" + _apiVersion;
        }
    }
}