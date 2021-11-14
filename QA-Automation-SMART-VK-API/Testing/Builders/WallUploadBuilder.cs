using QA_Automation_SMART_VK_API.Utils;

namespace QA_Automation_SMART_VK_API.Testing.Builders
{
    public class WallUploadBuilder : BaseBuilder
    {
        public WallUploadBuilder()
        {
            RequestUrl = _apiUrl + ConfigAndDataUtils.GetApiProperty("wall_upload") +
                "&access_token=" + _accessToken + "&v=" + _apiVersion;
        }
    }
}