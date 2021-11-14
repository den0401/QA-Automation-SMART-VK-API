using QA_Automation_SMART_VK_API.Utils;

namespace QA_Automation_SMART_VK_API.Testing.Builders
{
   public class IsLikedBuilder : BaseBuilder
   {
        public static string Type { get; set; }
        public static int ItemId { get; set; }

        public IsLikedBuilder(int userId, string type, int ownerId, int itemId)
        {
            UserId = userId;
            Type = type;
            OwnerId = ownerId;
            ItemId = itemId;
            RequestUrl = _apiUrl + ConfigAndDataUtils.GetApiProperty("likes_isLiked") +
                "user_id=" + userId + "&type=" + type + "&owner_id=" + ownerId +
                "&item_id=" +itemId + "&access_token=" + _accessToken + "&v=" + _apiVersion;
        }
   }
}