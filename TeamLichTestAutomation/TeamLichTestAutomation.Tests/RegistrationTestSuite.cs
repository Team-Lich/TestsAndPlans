namespace TeamLichTestAutomation.Tests
{
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.TestTemplates;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TeamLichTestAutomation.Academy.Core.Data;
    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;
    using TeamLichTestAutomation.Academy.Core.Pages.RegistrationPage;
    using TeamLichTestAutomation.Utilities;
    using TeamLichTestAutomation.Utilities.Attributes;

    /// <summary>
    /// Summary description for RegistrationTestSuite
    /// </summary>
    [TestClass]
    public class RegistrationTestSuite : BaseTest
    {
        private Browser browser;
        private MainPage mainPage;
        private RegistrationPage registrationPage;

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

            Manager.LaunchNewBrowser(BrowserType.Chrome);
            Manager.ActiveBrowser.ClearCache(BrowserCacheType.Cookies);

            this.browser = Manager.ActiveBrowser;

            this.mainPage = new MainPage(this.browser);
            this.registrationPage = new RegistrationPage(this.browser);

            this.mainPage.Navigate().ClickRegistration();
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
        [TestCategory("Registration")]
        [TestId(48)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void TestRegistrationWithUsernameEmpty()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.UserName = string.Empty;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenUsernameIsEmpty();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(51)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void TestRegistrationWithUsernameInvalid()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.UserName = TelerikUserData.UsernameInvalidSymbols;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenEnterInvalidUsername();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(49)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void TestRegistrationWithUsernameLengthLessThanMinimumAllowed()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.UserName = TelerikUserData.UsernameInvalidLengthDown;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenLengthOfUsernameIsIncorrect();
        }

        [TestMethod]
        [TestCategory("Registration")]
        //[TestId(49)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void TestRegistrationWithUsernameLengthAtAllowedDownBoundary()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.UserName = TelerikUserData.UsernameInvalidLengthBoundaryDown;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertNoErrorMessageIsDisplayedWhenLengthOfUsernameIsAtBoundary();
        }

        [TestMethod]
        [TestCategory("Registration")]
        //[TestId(49)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void TestRegistrationWithUsernameLengthAtAllowedUpBoundary()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.UserName = TelerikUserData.UsernameInvalidLengthBoundaryUp;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertNoErrorMessageIsDisplayedWhenLengthOfUsernameIsAtBoundary();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(50)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void TestRegistrationWithUsernameLengthGreaterThanMaximumAllowed()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.UserName = TelerikUserData.UsernameInvalidLengthUp;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenLengthOfUsernameIsIncorrect();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(52)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void TestRegistratioWithUsernameStartingWithNonAlphabetSymbol()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.UserName = TelerikUserData.UsernameStartingInvalidSymbol;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenUsernameStartsWithNonAlphabetSymbol();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(52)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void TestRegistratioWithUsernameEndingWithNonAlphabetSymbol()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.UserName = TelerikUserData.UsernameEndingInvalidSymbol;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenUsernameEndsWithNonAlphabetSymbol();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(218)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void TestRegistrationWithPasswordEmpty()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.Password = string.Empty;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenPasswordFieldIsEmpty();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(57)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void TestRegistrationWithPasswordLengthLessThanMinimumAllowed()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.Password = TelerikUserData.PasswordInvalidLength;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenLengthOfPasswordIsLessThanMinimumAllowed();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(56)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void TestRegistrationWithPasswordAgainDifferent()
        {
            TelerikUser user = new TelerikUser(
                TelerikUserData.UsernameValid,
                TelerikUserData.PasswordValid,
                TelerikUserData.FirstNameValid,
                TelerikUserData.LastNameValid,
                TelerikUserData.EmailValid);

            this.registrationPage.RegisterTelerikUser(user, TelerikUserData.PasswordAgainValid);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenEnterDifferentPasswordInPasswordAgainField();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(55)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void TestRegistrationWithPasswordAgainEmpty()
        {
            TelerikUser user = new TelerikUser(
                TelerikUserData.UsernameValid,
                TelerikUserData.PasswordValid,
                TelerikUserData.FirstNameValid,
                TelerikUserData.LastNameValid,
                TelerikUserData.EmailValid);

            this.registrationPage.RegisterTelerikUser(user, string.Empty);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenPasswordAgainFieldIsEmpty();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(64)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void TestRegistrationWithFirstNameEmptyField()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.FirstName = string.Empty;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenFirstNameFieldIsEmpty();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(59)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void TestRegistrationWithFirstNameContainingNonCyrillicAlphabetSymbols()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.FirstName = TelerikUserData.FirstNameNonCyrillicSymbols;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenFirstNameContainNonCyrillicAlphabetSymbol();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(61)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void TestRegistrationWithFirstNameStartingWithInvalidSymbols()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.FirstName = TelerikUserData.FirstNameInvalidBoundarySymbols;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenFirstNameStartsWithInvalidSymbol();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(63)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void TestRegistrationWithFirstNameLengthLessThanMinimumAllowed()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.FirstName = TelerikUserData.FirstNameInvalidLength;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenFirstNameLengthIsLessThanMinimumAllowed();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(64)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void TestRegistrationWithLastNameEmptyField()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.LastName = string.Empty;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenLastNameFieldIsEmpty();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(68)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void TestRegistrationWithLastNameLengthLessThanMinimumAllowed()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.LastName = TelerikUserData.LastNameInvalidLength;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenLastNameLengthIsLessThanMinimumAllowed();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(65)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void TestRegistrationWithLastNameContainingNonCyrillicAlphabetSymbols()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.LastName = TelerikUserData.LastNameInvalidSymbols;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenLastNameContainNonCyrillicAlphabetSymbol();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(69)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void TestRegistrationWithEmailAddressEmpty()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.Email = string.Empty;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenEmailIsEmpty();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(71)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void TestRegistrationWithEmailAddressNotContainingAtSymbol()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.Email = TelerikUserData.EmailMissingAtSymbol;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenEmailAddressNotContainSpecialSymbols();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(70)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void TestRegistrationWithEmailAddressNotContainPointSymbol()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.Email = TelerikUserData.EmailMissingPointSymbol;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenEmailAddressNotContainSpecialSymbols();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(73)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void TestRegistrationWithTermsAndConditionsCheckboxUnchecked()
        {
            TelerikUser user = TelerikUser.ValidUser;

            this.registrationPage.RegisterTelerikUserWithUncheckedCheckbox(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenCheckboxIsUnchecked();
        }
    }
}