using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace QA_Automation_SMART_VK_API.Testing.PageObjects.Forms
{
    public class LeftMenuForm : Form
    {
        private ILink ProfileLink => ElementFactory.GetLink(By.XPath(
            "//li[@id = 'l_pr']/a"), "Profile link");

        public LeftMenuForm() : base(By.Id("side_bar_inner"), "Left menu")
        { }

        public void OpenProfilePage() => ProfileLink.ClickAndWait();

        public int GetUserId()
        {
            string[] href = ProfileLink.Href.Split('/');
            string id = href[^1];

            return int.Parse(id.Remove(0, "id".Length));
        }
    }
}