namespace TeamLichTestAutomation.Tests
{
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.TestTemplates;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.CoursesPage;
    using TeamLichTestAutomation.Academy.Core.Pages.LoginPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;
    using TeamLichTestAutomation.Academy.Core.Pages.RegistrationPage;
    using TeamLichTestAutomation.Utilities;
    using TeamLichTestAutomation.Utilities.Attributes;

    /// <summary>
    /// Summary description for CourseSignUpTestSuite
    /// </summary>
    [TestClass]
    public class CourseSignUpTestSuite : BaseTest
    {
        private Browser browser;
        private RegistrationPage registrationPage;
        private MainPage mainPage;
        private CoursesPage coursesPage;
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

            Manager.LaunchNewBrowser(BrowserType.Chrome);
            Manager.ActiveBrowser.ClearCache(BrowserCacheType.Cookies);

            this.browser = Manager.ActiveBrowser;

            this.mainPage = new MainPage(this.browser);
            this.coursesPage = new CoursesPage(this.browser);
            this.loginPage = new LoginPage(this.browser);
            this.registrationPage = new RegistrationPage(this.browser);
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup]
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
        [TestCategory("CourseSignUp")]
        [TestId(221)]
        [Priority(2)]
        [Owner("Ivan")]
        public void CourseSignUp_LiveSignUp()
        {
            this.mainPage.Navigate().ClickRegistration();
            this.registrationPage.RegisterRandomUser();
            this.mainPage.NavigateTo("http://stage.telerikacademy.com/Courses/Courses/Details/265");
            this.coursesPage.LiveSignUp();

            this.coursesPage.AssertSignOffBtn();
        }

        [TestMethod]
        [TestCategory("CourseSignUp")]
        [TestId(222)]
        [Priority(2)]
        [Owner("Ivan")]
        public void CourseSignUp_OnlineSignUp()
        {
            this.mainPage.Navigate().ClickRegistration();
            this.registrationPage.RegisterRandomUser();
            this.mainPage.NavigateTo("http://stage.telerikacademy.com/Courses/Courses/Details/265");
            this.coursesPage.OnlineSignUp();

            this.coursesPage.AssertSignOffBtn();
        }

        [TestMethod]
        [TestCategory("CourseSignUp")]
        [TestId(223)]
        [Priority(2)]
        [Owner("Ivan")]
        public void CourseSignUp_SignUpWithoutLogIn()
        {
            this.mainPage.NavigateTo("http://stage.telerikacademy.com/Courses/Courses/Details/265");
            this.coursesPage.AssertPleaseLogInBtnPresent();
        }

        [TestMethod]
        [TestCategory("CourseSignUp")]
        [TestId(224)]
        [Priority(2)]
        [Owner("Ivan")]
        public void CourseSignUp_LiveSignUpFromCoursesList()
        {
            this.mainPage.Navigate().ClickRegistration();
            this.registrationPage.RegisterRandomUser();
            this.mainPage.HoverCoursesNavigationDropdown();
            this.mainPage.MyCourseClick();
            this.coursesPage.LiveSignUp();
            this.coursesPage.AssertSignOffBtn();
        }

        [TestMethod]
        [TestCategory("CourseSignUp")]
        [TestId(225)]
        [Priority(2)]
        [Owner("Ivan")]
        public void CourseSignUp_OnlineSignUpFromSignOffCourse()
        {
            this.mainPage.Navigate().ClickLogin();
            this.loginPage.LoginUser(TelerikUser.Regular);
            this.coursesPage.Navigate();
            this.coursesPage.AssertSignedOffCourse();
        }

        [TestMethod]
        [TestCategory("CourseSignUp")]
        [TestId(226)]
        [Priority(2)]
        [Owner("Ivan")]
        public void CourseSignUp_OnlineSignUpFromCoursesList()
        {
            this.mainPage.Navigate().ClickRegistration();
            this.registrationPage.RegisterRandomUser();
            this.mainPage.HoverCoursesNavigationDropdown();
            this.mainPage.MyCourseClick();
            this.coursesPage.OnlineSignUp();
            this.coursesPage.AssertSignOffBtn();
        }

        [TestMethod]
        [TestCategory("CourseSignUp")]
        [TestId(227)]
        [Priority(2)]
        [Owner("Ivan")]
        public void CourseSignUp_SignUpFromCoursesListWithoutLogIn()
        {
            this.mainPage.HoverCoursesNavigationDropdown();
            this.mainPage.MyCourseClick();
            this.coursesPage.AssertPleaseLogInBtnPresent();
        }

        [TestMethod]
        [TestCategory("CourseSignUp")]
        [TestId(228)]
        [Priority(2)]
        [Owner("Ivan")]
        public void CourseSignUp_LiveSignUpFromSignOffCourse()
        {
            this.mainPage.Navigate().ClickLogin();
            this.loginPage.LoginUser(TelerikUser.Regular);
            this.coursesPage.Navigate();
            this.coursesPage.AssertSignedOffCourse();
        }
    }
}