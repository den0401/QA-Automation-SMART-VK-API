using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System.IO;
using QA_Automation_SMART_VK_API.Utils;

namespace QA_Automation_SMART_VK_API.Testing.PageObjects.Pages
{
    public class ProfilePage : Form
    {
        private ILabel Post(int userId, int postId, string elementName) =>
            ElementFactory.GetLabel(By.Id($"post{userId}_{postId}"), elementName);
        private IButton LikeBtn(int userId, int postId, string elementName) =>
            ElementFactory.GetButton(By.XPath($"//div[@class = " +
                $"'like_wrap _like_wall{userId}_{postId} ']/descendant::a"), elementName);

        private ILabel Comment(int userId, int commentedPostId, int commentId) =>
            ElementFactory.GetLabel(By.CssSelector($"#replies{userId}_{commentedPostId} " +
                $"#post{userId}_{commentId}"), $"{userId} comment");
        private ILabel PostAuthor => ElementFactory.GetLabel(
            By.XPath("//*[contains(@class,'post_author')]"), "Author of post");
        private ILink ShowNextComment() => ElementFactory.GetLink(
            By.XPath($"//span[@class='js-replies_next_label']"), "Wall post");

        private ILabel DownloadImage => ElementFactory.GetLabel(By.TagName("img"),
           "Image to download");
        private ILink WallPhoto(int userId, int photoId) => ElementFactory.GetLink(
            By.XPath($"//a[@href='/photo{userId}_{photoId}']"), "Wall photo");
        private IButton CloseWallPhotoBtn => ElementFactory.GetButton(
            By.ClassName("pv_close_btn"), "Close button");

        public ProfilePage() : base(By.Id("profile_wall"), "Profile wall")
        { }

        public bool IsPostDisplayed(int userId, int postId) =>
            Post(userId, postId, "Post").State.WaitForDisplayed();

        public bool IsPostDeleted(int userId, int postId) =>
            Post(userId, postId, "Post").State.WaitForNotDisplayed();

        public bool IsCommentOnPostDisplayed(int userId, int commentedPostId, int commentId) =>
            Comment(userId, commentedPostId, commentId).State.WaitForDisplayed();

        public void LikePost(int userId, int postId) => LikeBtn(userId,
            postId, "Like").Click();

        public string GetPostText(int userId, int postId) => Post(userId, postId,
            "Post").FindChildElement<ILabel>(By.ClassName("wall_post_text"), "Post's text").Text;

        public void ShowComment() => ShowNextComment().Click();

        private int GetAuthorId(ILabel post)
        {
            string href = post.FindChildElement<ILink>(
                By.CssSelector("a.author"), "Comment author link").Href;

            return int.Parse(href[(href.LastIndexOf("/id") + "/id".Length)..]);
        }

        public int GetCommentAuthorId(int userId, int commentedPostId, int commentId) =>
            GetAuthorId(Comment(userId, commentedPostId, commentId));

        public int GetPostAuthorId() => GetAuthorId(PostAuthor);

        public string GetTextOfComment(int userId, int commentedPostId, int commentId) =>
            Comment(userId, commentedPostId, commentId).FindChildElement<ILabel>(
                By.ClassName("wall_reply_text"), "Comment's text").Text;

        public bool IsUploadedPhotoDisplayed(int userId, int postId) =>
            Post(userId, postId, "Post").FindChildElement<ILink>(By.CssSelector("a[href*='photo']"),
                "Post image link").State.IsDisplayed;

        public string SavePhoto(int photoId, string fileName, int ownerId)
        {
            DownloadImage.State.WaitForDisplayed();

            string path = Directory.GetCurrentDirectory() + @$"\{fileName}.jpg";

            WallPhoto(ownerId, photoId).ClickAndWait();

            ImageUtils.DownloadImage(DownloadImage.GetAttribute("src"), path);

            CloseWallPhotoBtn.ClickAndWait();

            return path;
        }
    }
}