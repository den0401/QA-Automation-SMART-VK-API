using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Logging;
using NUnit.Framework;
using QA_Automation_SMART_VK_API.Utils;

namespace QA_Automation_SMART_VK_API.Testing.Tests
{
    [TestFixture]
    public class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            var browser = AqualityServices.Browser;
            browser.Maximize();

            Logger.Instance.Info("Step 1 - Going to site with link");
            browser.GoTo(ConfigAndDataUtils.GetConfigProperties("vk_url"));
        }

        [TearDown]
        public void AfterTest()
        {
            if (AqualityServices.IsBrowserStarted)
            {
                AqualityServices.Browser.Quit();
            }
        }
    }
}