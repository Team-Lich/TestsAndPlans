namespace TeamLichTestAutomation.Tests
{
    using System;
    using System.Net;
    using System.Threading;
    using ArtOfTest.WebAii.Controls.HtmlControls;

    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.TestTemplates;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.FacebookLoginPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;
    using TeamLichTestAutomation.Academy.Core.Pages.LoginPage;
    using TeamLichTestAutomation.Utilities;
    using TeamLichTestAutomation.Utilities.Attributes;

    /// <summary>
    /// Summary description for TelerikVSUnitTest1
    /// </summary>
    [TestClass]
    public class LoginTestSuite : BaseTest
    {
        private Browser browser;
        private MainPage mainPage;
        private LoginPage loginPage;

        #region [Setup / TearDown]

        private TestContext testContextInstance = null;
        /// <summary>
        /// Gets or sets the VS test context which provides
        /// information about and functionality for the
        /// current test run.
        ///</summary>
        ///
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
        }

        // Use TestInitialize to run code before running each test
        [TestInitialize()]
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
            Initialize(true, this.TestContext.TestLogsDir, new TestContextWriteLine(this.TestContext.WriteLine));

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
            SetTestMethod(this, (string)TestContext.Properties["TestName"]);

            #endregion          

            //Manager.Settings.Web.RecycleBrowser = true;

            Manager.LaunchNewBrowser(BrowserType.FireFox);
            Manager.ActiveBrowser.ClearCache(BrowserCacheType.Cookies);

            this.browser = Manager.ActiveBrowser;

            this.mainPage = new MainPage(this.browser);
            this.loginPage = new LoginPage(this.browser);

            mainPage.Navigate().ClickLogin();
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            #region WebAii CleanUp

            // Shuts down WebAii manager and closes all browsers currently running
            // after each test. This call is ignored if recycleBrowser is set
            this.CleanUp();

            #endregion
        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            // This will shut down all browsers if
            // recycleBrowser is turned on. Else
            // will do nothing.
            ShutDown();
        }

        #endregion

        [TestMethod]
        [TestCategory("Login")]
        [TestCategory("PriorityHigh")]
        [TestOwner(Owner.DechoDechev)]
        public void TestLoginWithValidRegularUserCredentials()
        {
            loginPage.LoginUser(TelerikUser.Regular);

            mainPage.AssertUserIsLoggedAsRegularUser();
        }

        [TestMethod]
        [TestCategory("Login")]
        [TestCategory("PriorityHigh")]
        [TestOwner(Owner.DechoDechev)]
        public void TestLoginWithEmptyFields()
        {
            TelerikUser user = new TelerikUser(string.Empty, string.Empty);
            loginPage.LoginUser(user);

            mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestCategory("Login")]
        [TestCategory("PriorityHigh")]
        [TestOwner(Owner.DechoDechev)]
        public void TestLoginWithEmptyUserField()
        {
            TelerikUser user = TelerikUser.Regular;
            user.UserName = string.Empty;
            loginPage.LoginUser(user);

            mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestCategory("Login")]
        [TestCategory("PriorityHigh")]
        [TestOwner(Owner.DechoDechev)]
        public void TestLoginRegularUserWithEmptyPasswordField()
        {
            TelerikUser user = TelerikUser.Regular;
            user.Password = string.Empty;
            loginPage.LoginUser(user);

            mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestCategory("Login")]
        [TestCategory("PriorityHigh")]
        [TestOwner(Owner.DechoDechev)]
        public void TestLoginUserWithNullFields()
        {
            TelerikUser user = new TelerikUser(null, null);
            loginPage.LoginUser(user);

            mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestCategory("Login")]
        [TestCategory("PriorityHigh")]
        [TestOwner(Owner.DechoDechev)]
        public void TestLoginUserWithNullUserField()
        {
            TelerikUser user = TelerikUser.Regular;
            user.UserName = null;
            loginPage.LoginUser(user);

            mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestCategory("Login")]
        [TestCategory("PriorityHigh")]
        [TestOwner(Owner.DechoDechev)]
        public void TestLoginRegularUserWithNullPasswordField()
        {
            TelerikUser user = TelerikUser.Regular;
            user.Password = null;
            loginPage.LoginUser(user);

            mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestCategory("Login")]
        [TestCategory("PriorityHigh")]
        [TestOwner(Owner.DechoDechev)]
        public void TestLoginAdminUserWithNullPasswordField()
        {
            TelerikUser user = TelerikUser.Admin;
            user.Password = null;
            loginPage.LoginUser(user);

            mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestCategory("Login")]
        [TestCategory("PriorityHigh")]
        [TestOwner(Owner.DechoDechev)]
        public void TestLoginAdminUserWithEmptyPasswordField()
        {
            TelerikUser user = TelerikUser.Admin;
            user.Password = string.Empty;
            loginPage.LoginUser(user);

            mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestCategory("Login")]
        [TestCategory("PriorityHigh")]
        [TestOwner(Owner.DechoDechev)]
        public void TestLoginWithValidAdminUserCredentials()
        {
            loginPage.LoginUser(TelerikUser.Admin);

            mainPage.AssertUserIsLoggedAsAdmin();
        }

        [TestMethod]
        [TestCategory("Login")]
        [TestCategory("PriorityHigh")]
        [TestOwner(Owner.DechoDechev)]
        public void TestLoginWithInvalidAdminUsername()
        {
            TelerikUser testUser = TelerikUser.Admin;
            testUser.UserName = "WrongUser";
            loginPage.LoginUser(testUser);

            mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestCategory("Login")]
        [TestCategory("PriorityHigh")]
        [TestOwner(Owner.DechoDechev)]
        public void TestLoginWithInvalidAdminPassword()
        {
            TelerikUser testUser = TelerikUser.Admin;
            testUser.Password = "WrongPass";
            loginPage.LoginUser(testUser);

            mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestCategory("Login")]
        [TestCategory("PriorityHigh")]
        [TestOwner(Owner.DechoDechev)]
        public void TestLoginWithInvalidRegularUserUsername()
        {
            TelerikUser testUser = TelerikUser.Regular;
            testUser.UserName = "WrongUser";
            loginPage.LoginUser(testUser);

            mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestCategory("Login")]
        [TestCategory("PriorityHigh")]
        [TestOwner(Owner.DechoDechev)]
        public void TestLoginWithInvalidRegularUserPassword()
        {
            TelerikUser testUser = TelerikUser.Regular;
            testUser.Password = "WrongPass";
            loginPage.LoginUser(testUser);

            mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestCategory("Login")]
        [TestCategory("PriorityMedium")]
        [TestOwner(Owner.DechoDechev)]
        public void TestLoginPersistenceRegularUserOnBrowserRestart()
        {
            loginPage.LoginUser(TelerikUser.Regular);

            mainPage.AssertUserIsLoggedAsRegularUser();

            browser.Close();
            Manager.LaunchNewBrowser(BrowserType.FireFox);
            browser = Manager.ActiveBrowser;
            mainPage = new MainPage(this.browser);
            mainPage.Navigate();

            mainPage.AssertUserIsLoggedAsRegularUser();
        }

        [TestMethod]
        [TestCategory("Login")]
        [TestCategory("PriorityMedium")]
        [TestOwner(Owner.DechoDechev)]
        public void TestLoginPersistenceAdminUserOnBrowserRestart()
        {
            loginPage.LoginUser(TelerikUser.Admin);
            mainPage.AssertUserIsLoggedAsAdmin();

            browser.Close();
            Manager.LaunchNewBrowser(BrowserType.FireFox);
            browser = Manager.ActiveBrowser;
            mainPage = new MainPage(this.browser);
            mainPage.Navigate();

            mainPage.AssertUserIsLoggedAsAdmin();
        }

        [TestMethod]
        [TestCategory("Login")]
        [TestCategory("PriorityHigh")]
        [TestOwner(Owner.DechoDechev)]
        public void TestLoginRegularUserIsNotPersistentOnCookieDeletion()
        {
            loginPage.LoginUser(TelerikUser.Regular);
            mainPage.AssertUserIsLoggedAsRegularUser();

            browser.ClearCache(BrowserCacheType.Cookies);
            browser.Refresh();

            mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestCategory("Login")]
        [TestCategory("PriorityHigh")]
        [TestOwner(Owner.DechoDechev)]
        public void TestLoginAdminUserIsNotPersistentOnCookieDeletion()
        {
            loginPage.LoginUser(TelerikUser.Admin);
            mainPage.AssertUserIsLoggedAsAdmin();

            browser.ClearCache(BrowserCacheType.Cookies);
            browser.Refresh();

            mainPage.AssertUserIsNotLogged();
        }

        [TestMethod]
        [TestCategory("Login")]
        [TestCategory("PriorityHigh")]
        [TestOwner(Owner.DechoDechev)]
        public void TestLoginUserFieldDoesNotAcceptForbiddenSymbols()
        {
            TelerikUser user = new TelerikUser(@"<script>window.alert();</script>", "123456");
            loginPage.LoginUser(user);

            this.browser.RefreshDomTree();

            loginPage.AssertIfErrorMessageForIllegalDataIsShown();
        }

        [TestMethod]
        [TestCategory("Login")]
        [TestCategory("PriorityHigh")]
        [TestOwner(Owner.DechoDechev)]
        public void TestLoginPasswordFieldDoesNotAcceptForbiddenSymbols()
        {
            TelerikUser user = new TelerikUser("TeamLichTestUser", @"<script>window.alert();</script>");
            loginPage.LoginUser(user);

            this.browser.RefreshDomTree();

            loginPage.AssertIfErrorMessageForIllegalDataIsShown();
        }
    }
}