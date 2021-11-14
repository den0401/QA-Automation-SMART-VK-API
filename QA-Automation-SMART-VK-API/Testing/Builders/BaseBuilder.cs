using QA_Automation_SMART_VK_API.Utils;

namespace QA_Automation_SMART_VK_API.Testing.Builders
{
    public class BaseBuilder
    {
        protected static readonly string _apiUrl = ConfigAndDataUtils.GetApiProperty("api_url");
        protected static readonly string _apiVersion = ConfigAndDataUtils.GetApiProperty("api_version");
        protected static readonly string _accessToken = ConfigAndDataUtils.GetCredentialsProperty("access_token");

        public string RequestUrl { get; set; }
        public static int UserId { get; set; }
        public static int OwnerId { get; set; }
    }
}