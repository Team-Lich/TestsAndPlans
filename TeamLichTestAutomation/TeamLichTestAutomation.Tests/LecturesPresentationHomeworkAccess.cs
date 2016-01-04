namespace TeamLichTestAutomation.Tests
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
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
    /// Summary description for LecturesPresentationHomeworkAccess
    /// </summary>
    [TestClass]
    public class LecturesPresentationHomeworkAccess : BaseTest
    {
        private Browser browser;
        private MainPage mainPage;
        private CoursesPage coursesPage;
        private LoginPage loginPage;
        public RegistrationPage registrationPage;

        private void LoginWithRegularUser()
        {
            this.mainPage.Navigate().ClickLogin();
            TelerikUser user = TelerikUser.Regular;
            this.loginPage.LoginUser(user);
        }

        private void RegNewUser()
        {
            //TelerikUser user = TelerikUser.Regular;
            this.mainPage = new MainPage(this.browser);
            this.registrationPage = new RegistrationPage(this.browser);
            this.mainPage.Navigate().ClickRegistration();
            this.registrationPage.RegisterRandomUser();
        }

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
            Initialize(false, this.TestContext.TestLogsDir, new TestContextWriteLine(this.TestContext.WriteLine));

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

            Manager.LaunchNewBrowser(BrowserType.Chrome);
            Manager.ActiveBrowser.ClearCache(BrowserCacheType.Cookies);

            this.browser = Manager.ActiveBrowser;

            this.mainPage = new MainPage(this.browser);
            this.coursesPage = new CoursesPage(this.browser);
            this.loginPage = new LoginPage(this.browser);
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
        [TestCategory("LecturesPresentationsHomework")]
        ////[TestId(101)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ivan)]
        public void CoursesListAccessWithoutLogin()
        {
            this.mainPage.Navigate().ClickCoursesNavigationDropdown();
            this.coursesPage.AssertCoursesFound();
        }

        [TestMethod]
        [TestCategory("LecturesPresentationsHomework")]
        ////[TestId(101)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ivan)]
        public void CoursesListAccessWithLogin()
        {
            LoginWithRegularUser();

            this.mainPage.Navigate().ClickCoursesNavigationDropdown();
            this.coursesPage.AssertCoursesFound();
        }

        [TestMethod]
        [TestCategory("LecturesPresentationsHomework")]
        ////[TestId(101)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ivan)]
        public void CoursesAccessFromUserDropdown()
        {
            this.LoginWithRegularUser();

            this.mainPage.HoverMyCoursesSpan();
            this.mainPage.MyCourseClick();

            this.coursesPage.AssertLecturePresent();
        }

        [TestMethod]
        [TestCategory("LecturesPresentationsHomework")]
        ////[TestId(101)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ivan)]
        public void PressentationAccess()
        {
            this.LoginWithRegularUser();
            this.coursesPage.Navigate();

            this.coursesPage.AssertPresentationLinkPresent();
        }

        [TestMethod]
        [TestCategory("LecturesPresentationsHomework")]
        ////[TestId(101)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ivan)]
        public void HomeworkAccess()
        {
            this.LoginWithRegularUser();

            this.coursesPage.Navigate();

            this.coursesPage.AssertSendHomeworkLinkPresent();
        }

        [TestMethod]
        [TestCategory("LecturesPresentationsHomework")]
        ////[TestId(101)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ivan)]
        public void HomeworkEvalAccess()
        {
            this.LoginWithRegularUser();
            this.mainPage.EvalHomeworkClick();

            var actualTitle = this.browser.Find.ByExpression<HtmlControl>(@"class=sectionTitle").GetValue<string>("innerText");
            var title = "ќцен€ване на домашно";

            Assert.AreEqual(title, actualTitle);
        }

        [TestMethod]
        [TestCategory("LecturesPresentationsHomework")]
        ////[TestId(101)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ivan)]
        public void SendHomework()
        {
            this.RegNewUser();
            this.coursesPage.Navigate();
            this.coursesPage.LiveSignUp();
            this.coursesPage.SendHomework();
        }

        [TestMethod]
        [TestCategory("LecturesPresentationsHomework")]
        ////[TestId(101)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ivan)]
        public void DownloadLastHomeworkLinkPresent()
        {
            this.RegNewUser();
            this.coursesPage.Navigate();
            //this.coursesPage.LiveSignUp();
            this.coursesPage.SendHomework();
            this.coursesPage.AssertDownloadLastHwPresent();
        }

        [TestMethod]
        [TestCategory("LecturesPresentationsHomework")]
        ////[TestId(101)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ivan)]
        public void HomeworkEvalFromCoursesPanel()
        {
            this.LoginWithRegularUser();
            this.coursesPage.Navigate();
            this.coursesPage.SendHomework();
            this.coursesPage.AssertHomewrokEvalBtnPresent();
        }

        [TestMethod]
        [TestCategory("LecturesPresentationsHomework")]
        ////[TestId(101)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ivan)]
        public void PresentationsAccessWithoutLogin()
        {
            this.coursesPage.Navigate();
            this.coursesPage.AssertPresentationLinkPresent();

        }

        [TestMethod]
        [TestCategory("LecturesPresentationsHomework")]
        ////[TestId(101)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ivan)]
        public void HomeworkAccessWithoutLogIn()
        {
            this.coursesPage.Navigate();

            this.coursesPage.AssertSendHomeworkLinkNotPresent();
        }

        [TestMethod]
        [TestCategory("LecturesPresentationsHomework")]
        ////[TestId(101)]
        [TestPriority(Priority.High)]
        [TestOwner(Owner.Ivan)]
        public void CoursesAccessWihtouLogIn()
        {
            this.coursesPage.Navigate();

        }
    }
}