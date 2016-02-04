namespace TeamLichTestAutomation.Tests
{
    using ArtOfTest.WebAii.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public abstract class BaseTest : ArtOfTest.WebAii.TestTemplates.BaseTest
    {
        private Browser browser;
        private Manager manager;

        protected Browser Browser
        {
            get
            {
                return this.browser;
            }

            set
            {
                this.browser = value;
            }
        }

        [TestInitialize]
        public void TestInit()
        {
            Settings settings = new Settings();
            settings.Web.DefaultBrowser = BrowserType.InternetExplorer;
            settings.Web.RecycleBrowser = false; // Does not work as expected, keep the value "false"
            settings.AnnotateExecution = false; // Change the value to "true" only if you debug

            this.manager = new Manager(settings);
            this.manager.Start();
            this.manager.LaunchNewBrowser();

            this.Browser = Manager.Current.ActiveBrowser;
            this.Browser.ClearCache(BrowserCacheType.Cookies);
            this.Browser.Window.Maximize();
            this.Browser.AutoDomRefresh = true;
            this.Browser.AutoWaitUntilReady = true;
            this.Browser.CommandTimeOut = 15000;
        }

        // Will be executed even if RecycleBrowser = true
        // Expect side effects if you change it
        [TestCleanup]
        public void TestCleanup()
        {
            this.manager.Dispose();
        }
    }
}