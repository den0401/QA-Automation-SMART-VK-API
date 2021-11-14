using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace QA_Automation_SMART_VK_API.Testing.PageObjects.Forms
{
    public class AuthorizationForm : Form
    {
        private ITextBox EmailTextBox=> ElementFactory.GetTextBox(By.Id("index_email"), "Email textbox");
        private ITextBox PasswordTextBox => ElementFactory.GetTextBox(By.Id("index_pass"), "Password textbox");
        private IButton SignInBtn => ElementFactory.GetButton(By.Id("index_login_button"), "SignIn button");

        public AuthorizationForm() : base(By.XPath("//form[@id='index_login_form']"), "Authorization form")
        {
        }

        public void MakeAuthorization(string email, string password)
        {
            EmailTextBox.Type(email);
            PasswordTextBox.Type(password);
            SignInBtn.ClickAndWait();
        }
    }
}