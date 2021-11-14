using RestSharp;

namespace QA_Automation_SMART_VK_API.Utils
{
    public static class APIUtils
    {
        public static string SendGetRequest(string url)
        {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest();
            var response = client.Get(request);
            return response.Content.ToString();
        }

        public static string SendPostRequest(string url, object body)
        {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(body);
            var response = client.Execute(request);
            return response.Content;
        }

        public static string SendPostRequest(string url, string name, string path)
        {
            RestClient client = new RestClient(url);
            var request = new RestRequest(url, Method.POST)
                .AddFile($"{name}", $"{path}")
                .AddHeader("Content-Type", "multipart/form-data");
            var response = client.Execute(request);
            return response.Content;
        }
    }
}