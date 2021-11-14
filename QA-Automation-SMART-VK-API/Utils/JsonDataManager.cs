using Newtonsoft.Json;

namespace QA_Automation_SMART_VK_API.Utils
{
    public static class JsonDataManager
    {
        public static T MakeDeserialization<T>(string json) => JsonConvert.DeserializeObject<T>(json);

        public static string MakeSerialization<T>(T obj) => JsonConvert.SerializeObject(obj);
    }
}