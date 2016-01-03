namespace TeamLichTestAutomation.Tests.RelatedUsersTestSuites
{
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.TestTemplates;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.FriendsPage;
    using TeamLichTestAutomation.Academy.Core.Pages.UserPage;

    using TeamLichTestAutomation.Utilities;
    using TeamLichTestAutomation.Utilities.Attributes;

    /// <summary>
    /// Summary description for FriendsTestSuite
    /// </summary>
    [TestClass]
    public class FriendsTestSuite : BaseTest
    {
        public static readonly string friendsPageUrl = "http://stage.telerikacademy.com/Friends";

        private Browser browser;
        private UserPage userPage;
        private FriendsPage friendsPage;

        #region [Setup / TearDown]

        private TestContext testContextInstance = null;

        /// <summary>
        ///Gets or sets the VS test context which provides
        ///information about and functionality for the
        ///current test run.
        ///</summary>
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

        //Use ClassInitialize to run code before running the first test in the class
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

            #endregion WebAii Initialization

            //
            // Place any additional initialization here
            //

            Manager.LaunchNewBrowser(BrowserType.Chrome);
            Manager.ActiveBrowser.ClearCache(BrowserCacheType.Cookies);

            this.browser = Manager.ActiveBrowser;
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            //
            // Place any additional cleanup here
            //

            #region WebAii CleanUp

            // Shuts down WebAii manager and closes all browsers currently running
            // after each test. This call is ignored if recycleBrowser is set
            this.CleanUp();

            #endregion WebAii CleanUp
        }

        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            // This will shut down all browsers if
            // recycleBrowser is turned on. Else
            // will do nothing.
            ShutDown();
        }

        #endregion [Setup / TearDown]

        [TestMethod]
        [TestCategory("Friends")]
        [TestId(106)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Yane)]
        public void AddFriendButtonShoudBeVisible()
        {
            RelatedUsersUtilities.RemoveFriend(this.browser);
            RelatedUsersUtilities.LoginUser(TelerikUser.Related1, this.browser).NavigateTo(TelerikUser.Related2.Url);
            userPage = new UserPage(this.browser);

            userPage.AssertAddFriendButtonIsVisible();
        }

        [TestMethod]
        [TestCategory("Friends")]
        [TestId(107)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Yane)]
        public void RemoveFriendButtonShoudBeVisible()
        {
            RelatedUsersUtilities.AddFriend(this.browser);
            RelatedUsersUtilities.LoginUser(TelerikUser.Related1, this.browser).NavigateTo(TelerikUser.Related2.Url);
            userPage = new UserPage(this.browser);

            userPage.AssertRemoveFriendButtonIsVisible();
        }

        [TestMethod]
        [TestCategory("Friends")]
        [TestId(108)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Yane)]
        public void TestAddFriendButton()
        {
            RelatedUsersUtilities.RemoveFriend(this.browser);
            RelatedUsersUtilities.LoginUser(TelerikUser.Related1, this.browser).NavigateTo(TelerikUser.Related2.Url);
            userPage = new UserPage(this.browser);
            userPage.ClickAddFriendButton();
            userPage.Browser.WaitForElement(2000, "id=UnfriendButton");

            userPage.AssertFriendIsAddedWhenAddFriendButtonIsClicked();
        }

        [TestMethod]
        [TestCategory("Friends")]
        [TestId(109)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Yane)]
        public void TestRemoveFriendButton()
        {
            RelatedUsersUtilities.AddFriend(this.browser);
            RelatedUsersUtilities.LoginUser(TelerikUser.Related1, this.browser).NavigateTo(TelerikUser.Related2.Url);
            userPage = new UserPage(this.browser);
            userPage.ClickRemoveFriendButton();
            userPage.Browser.WaitForElement(2000, "id=AddFriendButton");

            userPage.AssertFriendIsRemovedWhenRemoveFriendButtonIsClicked();
        }

        [TestMethod]
        [TestCategory("Friends")]
        [TestId(110)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Yane)]
        public void FriendsListShouldContainNoFriends()
        {
            RelatedUsersUtilities.LoginUser(TelerikUser.Related1, this.browser).NavigateTo(friendsPageUrl);
            friendsPage = new FriendsPage(this.browser);
            friendsPage.RemoveAllFriends();
            friendsPage.Browser.Refresh();

            friendsPage.AssertNoFriendsMessageIsVisible();
        }

        [TestMethod]
        [TestCategory("Friends")]
        [TestId(111)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Yane)]
        public void FriendsListShouldContainFriends()
        {
            RelatedUsersUtilities.AddFriend(this.browser);
            RelatedUsersUtilities.LoginUser(TelerikUser.Related1, this.browser).NavigateTo(friendsPageUrl);
            friendsPage = new FriendsPage(this.browser);

            friendsPage.AssertFriendsListPanelHasProperHeading();
            friendsPage.AssertFriendsListPanelBodyContainsFriend();
        }

        [TestMethod]
        [TestCategory("Friends")]
        [TestId(112)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Yane)]
        public void RemoveFriendConfirmationShouldBeVisible()
        {
            RelatedUsersUtilities.AddFriend(this.browser);
            RelatedUsersUtilities.LoginUser(TelerikUser.Related1, this.browser).NavigateTo(friendsPageUrl);
            friendsPage = new FriendsPage(this.browser);
            friendsPage.ClickRemoveFriendshipIcon();

            friendsPage.AssertConfirmationIsVisible();
        }

        [TestMethod]
        [TestCategory("Friends")]
        [TestId(113)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Yane)]
        public void RemoveFriendAfterConfirmYes()
        {
            RelatedUsersUtilities.AddFriend(this.browser);
            RelatedUsersUtilities.LoginUser(TelerikUser.Related1, this.browser).NavigateTo(friendsPageUrl);
            friendsPage = new FriendsPage(this.browser);
            friendsPage.ClickRemoveFriendshipIcon();
            friendsPage.ClickRemoveFriendshipConfirmYes();

            friendsPage.AssertFriendIsRemovedFromFriendsListPanelBody();
        }

        [TestMethod]
        [TestCategory("Friends")]
        [TestId(114)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Yane)]
        public void KeepFriendAfterConfirmNo()
        {
            RelatedUsersUtilities.AddFriend(this.browser);
            RelatedUsersUtilities.LoginUser(TelerikUser.Related1, this.browser).NavigateTo(friendsPageUrl);
            friendsPage = new FriendsPage(this.browser);
            friendsPage.ClickRemoveFriendshipIcon();
            friendsPage.ClickRemoveFriendshipConfirmNo();

            friendsPage.AssertFriendsListPanelBodyContainsFriend();
        }

        [TestMethod]
        [TestCategory("Friends")]
        [TestId(115)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Yane)]
        public void ClickOnFriendShouldOpenHisProfile()
        {
            RelatedUsersUtilities.AddFriend(this.browser);
            RelatedUsersUtilities.LoginUser(TelerikUser.Related1, this.browser).NavigateTo(friendsPageUrl);
            friendsPage = new FriendsPage(this.browser);
            friendsPage.ClickFriendItem();
            friendsPage.Browser.WaitUntilReady();
            friendsPage.Browser.RefreshDomTree();

            friendsPage.AssertCorrespondingProfilePageIsOpened();
        }
    }
}