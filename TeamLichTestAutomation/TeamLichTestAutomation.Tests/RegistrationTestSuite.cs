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

    [TestClass]
    public class RegistrationTestSuite : BaseTest
    {
        private Browser browser;
        private MainPage mainPage;
        private RegistrationPage registrationPage;

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

            #endregion

            Manager.LaunchNewBrowser(BrowserType.Chrome);
            Manager.ActiveBrowser.ClearCache(BrowserCacheType.Cookies);

            this.browser = Manager.ActiveBrowser;

            this.mainPage = new MainPage(this.browser);
            this.registrationPage = new RegistrationPage(this.browser);

            mainPage.Navigate().ClickRegistration();
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

        //Use ClassCleanup to run code after all tests in a class have run
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
        [TestCategory("Registration")]
        [TestId(48)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ilvie)]
        public void TestRegistrationWithUsernameEmpty()
        {
            TelerikUser user = new TelerikUser(string.Empty, TelerikUserData.PasswordValid,
                TelerikUserData.FirstNameValid, TelerikUserData.LastNameValid, TelerikUserData.EmailValid);

            registrationPage.RegisterTelerikUser(user);

            registrationPage.AssertErrorMessageIsDisplayedWhenUsernameIsEmpty();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(51)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ilvie)]
        public void TestRegistrationWithUsernameInvalid()
        {
            TelerikUser user = new TelerikUser(TelerikUserData.UsernameInvalidSymbols, 
                TelerikUserData.PasswordValid, TelerikUserData.FirstNameValid, 
                TelerikUserData.LastNameValid, TelerikUserData.EmailValid);

            registrationPage.RegisterTelerikUser(user);

            registrationPage.AssertErrorMessageIsDisplayedWhenEnterInvalidUsername();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(49)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ilvie)]
        public void TestRegistrationWithUsernameLengthLessThanMinimumAllowed()
        {
            TelerikUser user = new TelerikUser(TelerikUserData.UsernameInvalidLengthDown, 
                TelerikUserData.PasswordValid, TelerikUserData.FirstNameValid, 
                TelerikUserData.LastNameValid, TelerikUserData.EmailValid);

            registrationPage.RegisterTelerikUser(user);

            registrationPage.AssertErrorMessageIsDisplayedWhenLengthOfUsernameIsInccorect();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(50)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ilvie)]
        public void TestRegistrationWithUsernameLengthGreaterThanMaximumAllowed()
        {
            TelerikUser user = new TelerikUser(TelerikUserData.UsernameInvalidLengthUp, 
                TelerikUserData.PasswordValid, TelerikUserData.FirstNameValid, 
                TelerikUserData.LastNameValid, TelerikUserData.EmailValid);

            registrationPage.RegisterTelerikUser(user);

            registrationPage.AssertErrorMessageIsDisplayedWhenLengthOfUsernameIsInccorect();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(52)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ilvie)]
        public void TestRegistratioWithUsernameStartingWithNonAlphabetSymbol()
        {
            TelerikUser user = new TelerikUser(TelerikUserData.UsernameStartingInvalidSymbol,
               TelerikUserData.PasswordValid, TelerikUserData.FirstNameValid,
               TelerikUserData.LastNameValid, TelerikUserData.EmailValid);

            registrationPage.RegisterTelerikUser(user);

            registrationPage.AssertErrorMessageIsDisplayedWhenUsernameStartsWithNonAlphabetSymbol();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(52)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ilvie)]
        public void TestRegistratioWithUsernameEndingWithNonAlphabetSymbol()
        {
            TelerikUser user = new TelerikUser(TelerikUserData.UsernameEndingInvalidSymbol,
               TelerikUserData.PasswordValid, TelerikUserData.FirstNameValid,
               TelerikUserData.LastNameValid, TelerikUserData.EmailValid);

            registrationPage.RegisterTelerikUser(user);

            registrationPage.AssertErrorMessageIsDisplayedWhenUsernameEndsWithNonAlphabetSymbol();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(68)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ilvie)]
        public void TestRegistrationWithLastNameLengthLessThanMinimumAllowed()
        {
            TelerikUser user = new TelerikUser(TelerikUserData.UsernameValid,
                TelerikUserData.PasswordValid, TelerikUserData.FirstNameValid,
                TelerikUserData.LastNameInvalidLength, TelerikUserData.EmailValid);

            registrationPage.RegisterTelerikUser(user);

            registrationPage.AssertErrorMessageIsDisplayedWhenLastNameLengthIsLessThanMinimumAllowed();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(65)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ilvie)]
        public void TestRegistrationWithLastNameContainingNonCyrillicAlphabetSymbols()
        {
            TelerikUser user = new TelerikUser(TelerikUserData.UsernameValid,
                TelerikUserData.PasswordValid, TelerikUserData.FirstNameValid,
                TelerikUserData.LastNameInvalidSymbols, TelerikUserData.EmailValid);

            registrationPage.RegisterTelerikUser(user);

            registrationPage.AssertErrorMessageIsDisplayedWhenLastNameContainNonCyrillicAlphabetSymbol();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(64)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ilvie)]
        public void TestRegistrationWithLastNameEmptyField()
        {
            TelerikUser user = new TelerikUser(TelerikUserData.UsernameValid,
                TelerikUserData.PasswordValid, TelerikUserData.FirstNameValid,
                string.Empty, TelerikUserData.EmailValid);

            registrationPage.RegisterTelerikUser(user);

            registrationPage.AssertErrorMessageIsDisplayedWhenLastNameFieldIsEmpty();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(56)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ilvie)]
        public void TestRegistrationWithPasswordAgainDifferent()
        {
            TelerikUser user = new TelerikUser(TelerikUserData.UsernameValid,
               TelerikUserData.PasswordValid, TelerikUserData.FirstNameValid,
               TelerikUserData.LastNameValid, TelerikUserData.EmailValid);

            registrationPage.RegisterTelerikUser(user, TelerikUserData.PasswordAgainValid);

            registrationPage.AssertErrorMessageIsDisplayedWhenEnterDifferentPasswordInPasswordAgainField();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(57)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ilvie)]
        public void TestRegistrationWithPasswordLengthLessThanMinimumAllowed()
        {
            TelerikUser user = new TelerikUser(TelerikUserData.UsernameValid,
                TelerikUserData.PasswordInvalidLength, TelerikUserData.FirstNameValid,
                TelerikUserData.LastNameValid, TelerikUserData.EmailValid);

            registrationPage.RegisterTelerikUser(user);

            registrationPage.AssertErrorMessageIsDisplayedWhenLengthOfPasswordIsLessThanMinimumAllowed();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(55)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ilvie)]
        public void TestRegistrationWithPasswordAgainEmpty()
        {
            TelerikUser user = new TelerikUser(TelerikUserData.UsernameValid,
                 TelerikUserData.PasswordValid, TelerikUserData.FirstNameValid,
                 TelerikUserData.LastNameValid, TelerikUserData.EmailValid);

            registrationPage.RegisterTelerikUser(user, string.Empty);

            registrationPage.AssertErrorMessageIsDisplayedWhenPasswordAgainFieldIsEmpty();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(59)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ilvie)]
        public void TestRegistrationWithFirstNameContainingNonCyrillicAlphabetSymbols()
        {
            TelerikUser user = new TelerikUser(TelerikUserData.UsernameValid,
                TelerikUserData.PasswordValid, TelerikUserData.FirstNameInvalidSymbols,
                TelerikUserData.LastNameValid, TelerikUserData.EmailValid);

            registrationPage.RegisterTelerikUser(user);

            registrationPage.AssertErrorMessageIsDisplayedWhenFirstNameContainNonCyrillicAlphabetSymbol();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(63)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ilvie)]
        public void TestRegistrationWithFirstNameLengthLessThanMinimumAllowed()
        {
            TelerikUser user = new TelerikUser(TelerikUserData.UsernameValid,
                 TelerikUserData.PasswordValid, TelerikUserData.FirstNameInvalidLength,
                 TelerikUserData.LastNameValid, TelerikUserData.EmailValid);

            registrationPage.RegisterTelerikUser(user);

            registrationPage.AssertErrorMessageIsDisplayedWhenFirstNameLengthIsLessThanMinimumAllowed();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(69)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ilvie)]
        public void TestRegistrationWithEmailAddressEmpty()
        {
            TelerikUser user = new TelerikUser(TelerikUserData.UsernameValid,
                TelerikUserData.PasswordValid, TelerikUserData.FirstNameValid,
                TelerikUserData.LastNameValid, string.Empty);

            registrationPage.RegisterTelerikUser(user);

            registrationPage.AssertErrorMessageIsDisplayedWhenEmailIsEmpty();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(71)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ilvie)]
        public void TestRegistrationWithEmailAddressNotContainingAtSymbol()
        {
            TelerikUser user = new TelerikUser(TelerikUserData.UsernameValid,
                TelerikUserData.PasswordValid, TelerikUserData.FirstNameValid,
                TelerikUserData.LastNameValid, TelerikUserData.EmailMissingAtSymbol);

            registrationPage.RegisterTelerikUser(user);

            registrationPage.AssertErrorMessageIsDisplayedWhenEmailAddressNotContainSpecialSymbols();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(70)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ilvie)]
        public void TestRegistrationWithEmailAddressNotContainPointSymbol()
        {
            TelerikUser user = new TelerikUser(TelerikUserData.UsernameValid,
                TelerikUserData.PasswordValid, TelerikUserData.FirstNameValid,
                TelerikUserData.LastNameValid, TelerikUserData.EmailMissingPointSymbol);

            registrationPage.RegisterTelerikUser(user);

            registrationPage.AssertErrorMessageIsDisplayedWhenEmailAddressNotContainSpecialSymbols();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(73)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ilvie)]
        public void TestRegistrationWithTermsAndConditionsCheckboxUnchecked()
        {
            TelerikUser user = new TelerikUser(TelerikUserData.UsernameValid,
                TelerikUserData.PasswordValid, TelerikUserData.FirstNameValid,
                TelerikUserData.LastNameValid, TelerikUserData.EmailValid);

            registrationPage.RegisterTelerikUserWithUncheckedCheckbox(user);

            registrationPage.AssertErrorMessageIsDisplayedWhenCheckboxIsUnchecked();
        }
    }
}
