using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace QA_Automation_SMART_VK_API.Utils
{
    public static class ConfigAndDataUtils
    {
        private static readonly string _settings = "//Resources//settings.json";
        private static readonly string _testData = "//Resources//testData.json";
        private static readonly string _credentialsData = "//Resources//credentials.json";
        private static readonly string _apiData = "//Resources//api.json";

        public static string GetConfigProperties(string key) => GetSpecificProperties(_settings, key);

        public static string GetDataProperty(string key) => GetSpecificProperties(_testData, key);

        public static string GetCredentialsProperty(string key) => GetSpecificProperties(_credentialsData, key);

        public static string GetApiProperty(string key) => GetSpecificProperties(_apiData, key);

        private static string GetSpecificProperties(string propertyPath, string key)
        {
            AppDomain domain = AppDomain.CurrentDomain;
            JObject jsonObject = JObject.Parse(File.ReadAllText(domain.BaseDirectory + propertyPath));
            string jsonString = jsonObject.ToString(Newtonsoft.Json.Formatting.None);

            return JObject.Parse(jsonString)[key].ToString();
        }
    }
}