using Aquality.Selenium.Core.Logging;
using NUnit.Framework;
using QA_Automation_SMART_VK_API.Testing.PageObjects.Forms;
using QA_Automation_SMART_VK_API.Testing.PageObjects.Pages;
using QA_Automation_SMART_VK_API.Utils;

namespace QA_Automation_SMART_VK_API.Testing.Tests
{
    public class VkTest : BaseTest
    {
        private readonly ProfilePage _profilePage = new ProfilePage();
        private readonly AuthorizationForm _authorizationForm = new AuthorizationForm();
        private readonly LeftMenuForm _leftMenuForm = new LeftMenuForm();

        [Test]
        public void VkApiTest()
        {
            Logger.Instance.Info("Step 2 - Making authorization");
            _authorizationForm.MakeAuthorization(ConfigAndDataUtils.GetCredentialsProperty("login"),
                ConfigAndDataUtils.GetCredentialsProperty("password"));

            Logger.Instance.Info("Step 3 - Going to 'My Page'");
            _leftMenuForm.OpenProfilePage();
            int userId = _leftMenuForm.GetUserId();
            var randomMessage = RandomValues.MakeRandomString(20);

            Logger.Instance.Info("Step 4 - Creating a post with randomly generated text on the wall " +
                "and get the post id from the response (using an API request)");
            var post = ApplicationRequest.PostNewPost(userId, randomMessage);

            Logger.Instance.Info("Step 5 - Without refreshing the page, check that a post with the " +
                "desired text from the correct user has appeared on the wall");
            Assert.True(_profilePage.IsPostDisplayed(_profilePage.GetPostAuthorId(userId, post.Response.Id),
                post.Response.Id), "Post isn't displayed");
            Assert.AreEqual(randomMessage, _profilePage.GetPostText(userId, post.Response.Id),
                "Text of post isn't equal");

            randomMessage = RandomValues.MakeRandomString(10);

            Logger.Instance.Info("Step 6 - Editing post - changing the text and uploading a picture " +
                "(using an API request)");
            int photoId = ApplicationRequest.EditPost(userId, post.Response.Id, randomMessage,
                ConfigAndDataUtils.GetDataProperty("pathToPhoto")).photoId;

            Logger.Instance.Info("Step 7 - Without refreshing the page, check that the message text has changed " +
                "and the uploaded picture has been added");
            Assert.AreEqual(randomMessage, _profilePage.GetPostText(userId, post.Response.Id),
                "Edited text of post isn't equal");
            Assert.IsTrue(_profilePage.isUploadedPhotoDisplayed(userId, post.Response.Id),
                "Uploaded picture has not been added");
            string pathToSavedImage = _profilePage.SavePhoto(photoId, "downloadImage", userId);
            Assert.IsTrue(ImageUtils.CompareImages(ConfigAndDataUtils.GetDataProperty("pathToPhoto"),
                pathToSavedImage), "Images aren't equal");

            var commentMessage = RandomValues.MakeRandomString(15);

            Logger.Instance.Info("Step 8 - Adding a comment to a post with random text (using an API request)");
            var comment = ApplicationRequest.AddCommentToPost(userId, post.Response.Id, commentMessage);

            Logger.Instance.Info("Step 9 - Without refreshing the page, check that a comment from the correct " +
                "user has been added to the desired post");
            Assert.True(_profilePage.IsCommentOnPostDisplayed(userId, post.Response.Id, comment.Response.Id),
                "Comment isn't displayed");
            Assert.AreEqual(userId, _profilePage.GetCommentAuthorId(userId, post.Response.Id, comment.Response.Id),
                "Comment author_id doesn't match");
            Assert.AreEqual(commentMessage, _profilePage.GetTextOfComment(userId, post.Response.Id,
                comment.Response.Id), "Comment message isn't equal");

            Logger.Instance.Info("Step 10 - Like the post through the UI");
            _profilePage.LikePost(userId, post.Response.Id);

            Logger.Instance.Info("Step 11 - Check that the post got a like from the correct user (using an API request)");
            Assert.True(ApplicationRequest.IsLiked(userId, "post", post.Response.Id, userId), "Post isn't liked");

            Logger.Instance.Info("Step 12 - Delete the created post (using an API request)");
            ApplicationRequest.DeletePostOnTheWall(userId, post.Response.Id);

            Logger.Instance.Info("Step 13 - Check that the post has been deleted without refreshing the page");
            Assert.True(_profilePage.IsPostDeleted(userId, post.Response.Id), "Post isn't deleted");
        }
    }
}