using Aquality.Selenium.Core.Logging;
using System.IO;
using QA_Automation_SMART_VK_API.Testing.Builders;
using QA_Automation_SMART_VK_API.Testing.Models;

namespace QA_Automation_SMART_VK_API.Utils
{
    public static class ApplicationRequest
    {
        public static WallPostResponseModel PostNewPost(int ownerId, string message)
        {
            Logger.Instance.Info("Creating new post");

            var response = APIUtils.SendGetRequest(new WallPostBuilder(ownerId, message).RequestUrl);

            return JsonDataManager.MakeDeserialization<WallPostResponseModel>(response);
        }

        public static CommentModel AddCommentToPost(int ownerId, int postId, string message)
        {
            Logger.Instance.Info("Adding comment on post");

            var response = APIUtils.SendGetRequest(new CreateCommentBuilder(ownerId, postId, message).RequestUrl);

            return JsonDataManager.MakeDeserialization<CommentModel>(response);
        }

        public static (WallPostResponseModel wallPostResponseModel, int photoId) EditPost(
            int userId, int postId, string message, string pathToImage)
        {
            Logger.Instance.Info("Editing post");

            var wallUploadResponse = APIUtils.SendGetRequest(new WallUploadBuilder().RequestUrl);
            string url = JsonDataManager.MakeDeserialization<UploadServerModel>(wallUploadResponse).Response.UploadUrl;

            var path = Path.GetFullPath(@pathToImage);
            var postPhotoRequest = APIUtils.SendPostRequest(url, "photo", path);
            var parameters = JsonDataManager.MakeDeserialization<UploadResponseModel>(postPhotoRequest);

            var photoResponse = APIUtils.SendGetRequest(new WallSavePhotoBuilder(
                userId, parameters.Photo, parameters.Server, parameters.Hash).RequestUrl);
            var photoId = JsonDataManager.MakeDeserialization<PhotoModel>(photoResponse).Response[0].Id;

            Logger.Instance.Info("Uploading photo.");

            var response = APIUtils.SendGetRequest(new WallEditBuilder(
                userId, postId, message, "photo" + userId +"_" + photoId).RequestUrl);
            
            return (JsonDataManager.MakeDeserialization<WallPostResponseModel>(response), photoId);
        }

        public static bool IsLiked(int userId, string type, int likedItemId, int ownerId)
        {
            Logger.Instance.Info($"Checking if {type} is liked");

            var isLiked = APIUtils.SendGetRequest(new IsLikedBuilder(userId, type, ownerId, likedItemId).RequestUrl);

            return JsonDataManager.MakeDeserialization<LikeModel>(isLiked).Response.Liked == 1;
        }

        public static string DeletePostOnTheWall(int ownerId, int postId)
        {
            Logger.Instance.Info("Deleting post");

            return APIUtils.SendGetRequest(new WallDeleteBuilder(ownerId,postId).RequestUrl);
        }
    }
}