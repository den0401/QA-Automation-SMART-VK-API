using QA_Automation_SMART_VK_API.Utils;

namespace QA_Automation_SMART_VK_API.Testing.Builders
{
    public class WallSavePhotoBuilder : BaseBuilder
    {
        public static string Photo { get; set; }
        public static int Server { get; set; }
        public static string Hash { get; set; }

        public WallSavePhotoBuilder(int userId, string photo, int server, string hash)
        {
            UserId = userId;
            Photo = photo;
            Server = server;
            Hash = hash;
            RequestUrl = _apiUrl + ConfigAndDataUtils.GetApiProperty("wall_savePhoto") +
                "user_id=" + userId + "&photo=" + photo + "&server=" + server +
                "&hash=" + hash + "&access_token=" + _accessToken + "&v=" + _apiVersion;
        }
    }
}