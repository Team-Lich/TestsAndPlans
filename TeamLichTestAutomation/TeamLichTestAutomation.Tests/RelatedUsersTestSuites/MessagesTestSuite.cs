namespace TeamLichTestAutomation.Tests.RelatedUsersTestSuites
{
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.TestTemplates;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.LoginPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MessagesPage;
    using TeamLichTestAutomation.Academy.Core.Pages.UserProfilePage;

    using TeamLichTestAutomation.Utilities;
    using TeamLichTestAutomation.Utilities.Attributes;

    /// <summary>
    /// Summary description for MessagesTestSuite
    /// </summary>
    [TestClass]
    public class MessagesTestSuite : BaseTest
    {
        private Browser browser;
        private MainPage mainPage;
        private LoginPage loginPage;
        private UserProfilePage userPage;
        private MessagesPage messagesPage;

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

            Manager.LaunchNewBrowser(BrowserType.Chrome);
            Manager.ActiveBrowser.ClearCache(BrowserCacheType.Cookies);

            this.browser = Manager.ActiveBrowser;
            this.mainPage = new MainPage(this.browser);
            this.loginPage = new LoginPage(this.browser);
            this.userPage = new UserProfilePage(this.browser);
            this.messagesPage = new MessagesPage(this.browser);

            this.mainPage.NavigateTo(this.loginPage.Url);
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            //// Place any additional cleanup here

            #region WebAii CleanUp

            // Shuts down WebAii manager and closes all browsers currently running
            // after each test. This call is ignored if recycleBrowser is set
            this.CleanUp();

            #endregion WebAii CleanUp
        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            // This will shut down all browsers if
            // recycleBrowser is turned on. Else
            // will do nothing.
            BaseTest.ShutDown();
        }

        #endregion [Setup / TearDown]

        [TestMethod]
        [TestCategory("Messages")]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Yane)]
        public void SendMessageButtonShouldOpenMessagesPage()
        {
            RelatedUsersUtilities.AddFriend(this.browser);
            this.mainPage.NavigateTo(TelerikUser.Related2.Url);

            this.userPage.ClickSendMessageButtonActive();

            this.userPage.AssertMessagesPageIsActive();
        }

        [TestMethod]
        [TestCategory("Messages")]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Yane)]
        public void SendMessageButtonShouldBeInactive()
        {
            RelatedUsersUtilities.RemoveFriend(this.browser);
            this.mainPage.NavigateTo(TelerikUser.Related2.Url);

            this.userPage.AssertMessageButtonButtonIsInactive();

            this.userPage.ClickSendMessageButtonInactive();
            this.userPage.AssertProperUserProfilePageIsActive(TelerikUser.Related2.UserName);
        }

        [TestMethod]
        [TestCategory("Messages")]
        [TestId(118)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Yane)]
        public void MessagesPageElementsShouldBeDisplayedCorrectly()
        {
            RelatedUsersUtilities.AddFriend(this.browser);
            this.mainPage.NavigateTo(this.messagesPage.Url);

            this.messagesPage.AssertMessagesHeadingIsVisible();
            this.messagesPage.AssertMessagePanelTitleIsVisible();
            this.messagesPage.AssertInfoMessageIsVisible();
            this.messagesPage.AssertMessageToSendTextAreaIsVisible();
            this.messagesPage.AssertSubmitByEnterCheckboxIsNotVisible();
            this.messagesPage.AssertSendButtonIsVisible();
            this.messagesPage.AssertFriendsPanelTitleIsVisible();
            this.messagesPage.AssertFriendItemIsVisible();
        }

        [TestMethod]
        [TestCategory("Messages")]
        [TestId(119)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Yane)]
        public void FriendItemsShouldBeDisplayedCorrectly()
        {
            RelatedUsersUtilities.AddFriend(this.browser);
            this.mainPage.NavigateTo(this.messagesPage.Url);

            this.messagesPage.AssertFriendAvatarIsVisible();
            this.messagesPage.AssertFriendNamesAreVisible();
            this.messagesPage.AssertFriendLastMessageBeginningIsVisible();
        }

        [TestMethod]
        [TestCategory("Messages")]
        [TestId(120)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Yane)]
        public void SearchFieldShouldBeVisible()
        {
            RelatedUsersUtilities.AddFriend(this.browser);
            this.mainPage.NavigateTo(this.messagesPage.Url);

            this.messagesPage.AssertSearchFieldIsVisible();
        }

        [TestMethod]
        [TestCategory("Messages")]
        [TestId(125)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Yane)]
        public void MessageContainerShouldContainsProperData()
        {
            RelatedUsersUtilities.AddFriend(this.browser);
            this.mainPage.NavigateTo(this.messagesPage.Url);
            this.messagesPage.ClickFriendItem();

            this.messagesPage.Browser.ScrollBy(0, 400);
            this.messagesPage.UncheckSubmitByEnterCheckbox();
            this.messagesPage.EnterValidMessageUppercaseLatinAlphabet();
            this.messagesPage.ClickSendButton();
            this.messagesPage.HoverLastMessageWrapper();

            this.messagesPage.AssertLastMessageContainerContainsProperData(MessagesPageMessages.UppercaseLatinAlphabet);
        }

        [TestMethod]
        [TestCategory("Messages")]
        [TestId(126)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Yane)]
        public void SendValidMessage()
        {
            RelatedUsersUtilities.AddFriend(this.browser);
            this.mainPage.NavigateTo(this.messagesPage.Url);
            this.messagesPage.ClickFriendItem();
            this.messagesPage.UncheckSubmitByEnterCheckbox();

            this.messagesPage.EnterValidMessageLowercaseLatinAlphabet();
            this.messagesPage.ClickSendButton();
            this.messagesPage.AssertMessageIsSent(MessagesPageMessages.LowercaseLatinAlphabet);

            this.messagesPage.EnterValidMessageUppercaseLatinAlphabet();
            this.messagesPage.ClickSendButton();
            this.messagesPage.AssertMessageIsSent(MessagesPageMessages.UppercaseLatinAlphabet);

            this.messagesPage.EnterValidMessageLowercaseCyrilicAlphabet();
            this.messagesPage.ClickSendButton();
            this.messagesPage.AssertMessageIsSent(MessagesPageMessages.LowercaseCyrilicAlphabet);

            this.messagesPage.EnterValidMessageUppercaseCyrilicAlphabet();
            this.messagesPage.ClickSendButton();
            this.messagesPage.AssertMessageIsSent(MessagesPageMessages.UppercaseCyrilicAlphabet);

            this.messagesPage.EnterValidMessageDigits();
            this.messagesPage.ClickSendButton();
            this.messagesPage.AssertMessageIsSent(MessagesPageMessages.Digits);

            this.messagesPage.EnterValidMessageSpecialChars();
            this.messagesPage.ClickSendButton();
            this.messagesPage.AssertMessageIsSent(MessagesPageMessages.SpecialChars);

            this.messagesPage.EnterValidMessageSingleLatinChar();
            this.messagesPage.ClickSendButton();
            this.messagesPage.AssertMessageIsSent(MessagesPageMessages.LatinChar);

            this.messagesPage.EnterValidMessageSingleCyrilicChar();
            this.messagesPage.ClickSendButton();
            this.messagesPage.AssertMessageIsSent(MessagesPageMessages.CyrilicChar);

            this.messagesPage.EnterValidMessageSingleDigit();
            this.messagesPage.ClickSendButton();
            this.messagesPage.AssertMessageIsSent(MessagesPageMessages.Digit);

            this.messagesPage.EnterValidMessageSingleSpecialChar();
            this.messagesPage.ClickSendButton();
            this.messagesPage.AssertMessageIsSent(MessagesPageMessages.SpecialChar);
        }

        [TestMethod]
        [TestCategory("Messages")]
        [TestId(127)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Yane)]
        public void SendValidMessageWhenCheckboxIsUncheckedAndEnterIsPressed()
        {
            RelatedUsersUtilities.AddFriend(this.browser);
            this.mainPage.NavigateTo(this.messagesPage.Url);
            this.messagesPage.ClickFriendItem();

            this.messagesPage.UncheckSubmitByEnterCheckbox();
            this.messagesPage.Browser.ScrollBy(0, 400);
            this.messagesPage.EnterValidMessageLowercaseLatinAlphabet();
            this.messagesPage.PressEnter();
            this.messagesPage.EnterValidMessageLowercaseCyrilicAlphabet();
            this.messagesPage.ClickSendButton();

            this.messagesPage.AssertMessageIsSentAndLineBreakIsDisplayedCorrectly(
                MessagesPageMessages.LowercaseLatinAlphabet,
                MessagesPageMessages.LowercaseCyrilicAlphabet);
        }

        [TestMethod]
        [TestCategory("Messages")]
        [TestId(128)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Yane)]
        public void SendValidMessageWhenCheckboxIsCheckedAndEnterIsPressed()
        {
            RelatedUsersUtilities.AddFriend(this.browser);
            this.mainPage.NavigateTo(this.messagesPage.Url);
            this.messagesPage.ClickFriendItem();

            this.messagesPage.CheckSubmitByEnterCheckbox();
            this.messagesPage.EnterValidMessageLowercaseLatinAlphabet();
            this.messagesPage.PressEnter();

            this.messagesPage.AssertMessageIsSent(MessagesPageMessages.LowercaseLatinAlphabet);
        }

        [TestMethod]
        [TestCategory("Messages")]
        [TestId(129)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Yane)]
        public void TryToSendEmptyMessage()
        {
            RelatedUsersUtilities.AddFriend(this.browser);
            this.mainPage.NavigateTo(this.messagesPage.Url);
            this.messagesPage.ClickFriendItem();
            this.messagesPage.UncheckSubmitByEnterCheckbox();
            this.messagesPage.ClickSendButton();

            this.messagesPage.AssertMessageIsNotSent(MessagesPageMessages.SpacebarChar);

            this.messagesPage.EnterInvalidMessageSpacebarChar();
            this.messagesPage.ClickSendButton();

            this.messagesPage.AssertMessageIsNotSent(MessagesPageMessages.SpacebarChar);
        }
    }
}