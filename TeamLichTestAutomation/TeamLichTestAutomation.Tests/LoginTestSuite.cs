namespace TeamLichTestAutomation.Tests
{
    using ArtOfTest.WebAii.Core;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.LoginPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;

    using TeamLichTestAutomation.Utilities.Attributes;

    [TestClass]
    public class LoginTestSuite : BaseTest
    {
        private MainPage mainPage;
        private LoginPage loginPage;

        [TestInitialize]
        public void ThisTestInitialize()
        {
            this.mainPage = new MainPage(this.Browser);
            this.loginPage = new LoginPage(this.Browser);

            this.mainPage.Navigate().ClickLogin();
        }

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

            this.Browser.Close();
            Manager.Current.LaunchNewBrowser();
            this.Browser = Manager.Current.ActiveBrowser;
            this.mainPage = new MainPage(this.Browser);
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

            this.Browser.Close();
            Manager.Current.LaunchNewBrowser();
            this.Browser = Manager.Current.ActiveBrowser;
            this.mainPage = new MainPage(this.Browser);
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

            this.Browser.ClearCache(BrowserCacheType.Cookies);
            this.Browser.Refresh();

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

            this.Browser.ClearCache(BrowserCacheType.Cookies);
            this.Browser.Refresh();

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

            this.Browser.RefreshDomTree();

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

            this.Browser.RefreshDomTree();

            this.loginPage.AssertIfErrorMessageForIllegalDataIsShown();
        }
    }
}