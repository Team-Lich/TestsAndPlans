namespace TeamLichTestAutomation.Tests
{
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.TestTemplates;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.LoginPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;

    using TeamLichTestAutomation.Utilities;
    using TeamLichTestAutomation.Utilities.Attributes;

    /// <summary>
    /// Summary description for LoginTestSuite
    /// </summary>
    [TestClass]
    public class LoginTestSuite : BaseTest
    {
        BrowserType browserType;
        private Browser browser;
        private MainPage mainPage;
        private LoginPage loginPage;

        #region [Setup / TearDown]

        private TestContext testContextInstance = null;

        /// <summary>
        /// Gets or sets the VS test context which provides
        /// information about and functionality for the
        /// current test run.
        /// </summary>
        public TestContext TestContext
        {
            get
            {
                return this.testContextInstance;
            }

            set
            {
                this.testContextInstance = value;
            }
        }

        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
        }

        // Use TestInitialize to run code before running each test
        [TestInitialize]
        public void MyTestInitialize()
        {
            #region WebAii Initialization

            // Initializes WebAii manager to be used by the test case.
            // If a WebAii configuration section exists, settings will be
            // loaded from it. Otherwise, will create a default settings
            // object with system defaults.
            //
            // Note: We are passing in a delegate to the VisualStudio
            // testContext.WriteLine() method in addition to the Visual Studio
            // TestLogs directory as our log location. This way any logging
            // done from WebAii (i.e. Manager.Log.WriteLine()) is
            // automatically logged to the VisualStudio test log and
            // the WebAii log file is placed in the same location as VS logs.
            //
            // If you do not care about unifying the log, then you can simply
            // initialize the test by calling Initialize() with no parameters;
            // that will cause the log location to be picked up from the config
            // file if it exists or will use the default system settings (C:\WebAiiLog\)
            // You can also use Initialize(LogLocation) to set a specific log
            // location for this test.

            // Pass in 'true' to recycle the browser between test methods
            this.Initialize(true, this.TestContext.TestLogsDir, new TestContextWriteLine(this.TestContext.WriteLine));

            // If you need to override any other settings coming from the
            // config section you can comment the 'Initialize' line above and instead
            // use the following:

            /*

            // This will get a new Settings object. If a configuration
            // section exists, then settings from that section will be
            // loaded

            Settings settings = GetSettings();

            // Override the settings you want. For example:
            settings.Web.DefaultBrowser = BrowserType.FireFox;

            // Now call Initialize again with your updated settings object
            Initialize(settings, new TestContextWriteLine(this.TestContext.WriteLine));

            */

            // Set the current test method. This is needed for WebAii to discover
            // its custom TestAttributes set on methods and classes.
            // This method should always exist in [TestInitialize()] method.
            this.SetTestMethod(this, (string)TestContext.Properties["TestName"]);

            #endregion WebAii Initialization

            this.browserType = BrowserType.InternetExplorer;
            Manager.LaunchNewBrowser(this.browserType);
            Manager.ActiveBrowser.ClearCache(BrowserCacheType.Cookies);

            this.browser = Manager.ActiveBrowser;

            this.mainPage = new MainPage(this.browser);
            this.loginPage = new LoginPage(this.browser);

            this.mainPage.Navigate().ClickLogin();
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup]
        public void MyTestCleanup()
        {
            #region WebAii CleanUp

            // Shuts down WebAii manager and closes all browsers currently running
            // after each test. This call is ignored if recycleBrowser is set
            this.CleanUp();

            #endregion WebAii CleanUp
        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup]
        public static void MyClassCleanup()
        {
            // This will shut down all browsers if
            // recycleBrowser is turned on. Else
            // will do nothing.
            BaseTest.ShutDown();
        }

        #endregion [Setup / TearDown]

        [TestMethod]
        [TestId(1)]
        [TestCategory("Login")]
        [Priority(1)]
        [Owner("Decho")]
        public void LoginWithValidRegularUserCredentials()
        {
            this.loginPage.LoginUser(TelerikUser.Regular);

            this.mainPage.AssertUserIsLoggedAsRegularUser();
        }

        [TestMethod]
        [TestId(238)]
        [TestCategory("Login")]
        [Priority(1)]
        [Owner("Decho")]
        public void LoginWithEmptyFields()
        {
            TelerikUser user = new TelerikUser(string.Empty, string.Empty);
            this.loginPage.LoginUser(user);

            this.mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestId(243)]
        [TestCategory("Login")]
        [Priority(1)]
        [Owner("Decho")]
        public void LoginWithEmptyUserField()
        {
            TelerikUser user = TelerikUser.Regular;
            user.UserName = string.Empty;
            this.loginPage.LoginUser(user);

            this.mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestId(244)]
        [TestCategory("Login")]
        [Priority(1)]
        [Owner("Decho")]
        public void LoginRegularUserWithEmptyPasswordField()
        {
            TelerikUser user = TelerikUser.Regular;
            user.Password = string.Empty;
            this.loginPage.LoginUser(user);

            this.mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestId(245)]
        [TestCategory("Login")]
        [Priority(1)]
        [Owner("Decho")]
        public void LoginUserWithNullFields()
        {
            TelerikUser user = new TelerikUser(null, null);
            this.loginPage.LoginUser(user);

            this.mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestId(246)]
        [TestCategory("Login")]
        [Priority(1)]
        [Owner("Decho")]
        public void LoginUserWithNullUserField()
        {
            TelerikUser user = TelerikUser.Regular;
            user.UserName = null;
            this.loginPage.LoginUser(user);

            this.mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestId(247)]
        [TestCategory("Login")]
        [Priority(1)]
        [Owner("Decho")]
        public void LoginRegularUserWithNullPasswordField()
        {
            TelerikUser user = TelerikUser.Regular;
            user.Password = null;
            this.loginPage.LoginUser(user);

            this.mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestId(248)]
        [TestCategory("Login")]
        [Priority(1)]
        [Owner("Decho")]
        public void LoginAdminUserWithNullPasswordField()
        {
            TelerikUser user = TelerikUser.Admin;
            user.Password = null;
            this.loginPage.LoginUser(user);

            this.mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestId(249)]
        [TestCategory("Login")]
        [Priority(1)]
        [Owner("Decho")]
        public void LoginAdminUserWithEmptyPasswordField()
        {
            TelerikUser user = TelerikUser.Admin;
            user.Password = string.Empty;
            this.loginPage.LoginUser(user);

            this.mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestId(7)]
        [TestCategory("Login")]
        [Priority(1)]
        [Owner("Decho")]
        public void LoginWithValidAdminUserCredentials()
        {
            this.loginPage.LoginUser(TelerikUser.Admin);

            this.mainPage.AssertUserIsLoggedAsAdmin();
        }

        [TestMethod]
        [TestId(30)]
        [TestCategory("Login")]
        [Priority(1)]
        [Owner("Decho")]
        public void LoginWithInvalidAdminUsername()
        {
            TelerikUser testUser = TelerikUser.Admin;
            testUser.UserName = "WrongUser";
            this.loginPage.LoginUser(testUser);

            this.mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestId(29)]
        [TestCategory("Login")]
        [Priority(1)]
        [Owner("Decho")]
        public void LoginWithInvalidAdminPassword()
        {
            TelerikUser testUser = TelerikUser.Admin;
            testUser.Password = "WrongPass";
            this.loginPage.LoginUser(testUser);

            this.mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestId(28)]
        [TestCategory("Login")]
        [Priority(1)]
        [Owner("Decho")]
        public void LoginWithInvalidRegularUserUsername()
        {
            TelerikUser testUser = TelerikUser.Regular;
            testUser.UserName = "WrongUser";
            this.loginPage.LoginUser(testUser);

            this.mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestId(2)]
        [TestCategory("Login")]
        [Priority(1)]
        [Owner("Decho")]
        public void LoginWithInvalidRegularUserPassword()
        {
            TelerikUser testUser = TelerikUser.Regular;
            testUser.Password = "WrongPass";
            this.loginPage.LoginUser(testUser);

            this.mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestId(37)]
        [TestCategory("Login")]
        [Priority(3)]
        [Owner("Decho")]
        public void LoginPersistenceRegularUserOnBrowserRestart()
        {
            this.loginPage.LoginUser(TelerikUser.Regular);

            this.mainPage.AssertUserIsLoggedAsRegularUser();

            this.browser.Close();
            Manager.LaunchNewBrowser(this.browserType);
            this.browser = Manager.ActiveBrowser;
            this.mainPage = new MainPage(this.browser);
            this.mainPage.Navigate();

            this.mainPage.AssertUserIsLoggedAsRegularUser();
        }

        [TestMethod]
        [TestId(250)]
        [TestCategory("Login")]
        [Priority(3)]
        [Owner("Decho")]
        public void LoginPersistenceAdminUserOnBrowserRestart()
        {
            this.loginPage.LoginUser(TelerikUser.Admin);
            this.mainPage.AssertUserIsLoggedAsAdmin();

            this.browser.Close();
            Manager.LaunchNewBrowser(this.browserType);
            this.browser = Manager.ActiveBrowser;
            this.mainPage = new MainPage(this.browser);
            this.mainPage.Navigate();

            this.mainPage.AssertUserIsLoggedAsAdmin();
        }

        [TestMethod]
        [TestId(41)]
        [TestCategory("Login")]
        [Priority(1)]
        [Owner("Decho")]
        public void LoginRegularUserIsNotPersistentOnCookieDeletion()
        {
            this.loginPage.LoginUser(TelerikUser.Regular);
            this.mainPage.AssertUserIsLoggedAsRegularUser();

            this.browser.ClearCache(BrowserCacheType.Cookies);
            this.browser.Refresh();

            this.mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestId(42)]
        [TestCategory("Login")]
        [Priority(1)]
        [Owner("Decho")]
        public void LoginAdminUserIsNotPersistentOnCookieDeletion()
        {
            this.loginPage.LoginUser(TelerikUser.Admin);
            this.mainPage.AssertUserIsLoggedAsAdmin();

            this.browser.ClearCache(BrowserCacheType.Cookies);
            this.browser.Refresh();

            this.mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestId(251)]
        [TestCategory("Login")]
        [Priority(1)]
        [Owner("Decho")]
        public void LoginUserFieldDoesNotAcceptForbiddenSymbols()
        {
            TelerikUser user = new TelerikUser(@"<script>window.alert();</script>", "123456");
            this.loginPage.LoginUser(user);

            this.browser.RefreshDomTree();

            this.loginPage.AssertIfErrorMessageForIllegalDataIsShown();
        }

        [TestMethod]
        [TestId(252)]
        [TestCategory("Login")]
        [Priority(1)]
        [Owner("Decho")]
        public void LoginPasswordFieldDoesNotAcceptForbiddenSymbols()
        {
            TelerikUser user = new TelerikUser("TeamLichTestUser", @"<script>window.alert();</script>");
            this.loginPage.LoginUser(user);

            this.browser.RefreshDomTree();

            this.loginPage.AssertIfErrorMessageForIllegalDataIsShown();
        }
    }
}