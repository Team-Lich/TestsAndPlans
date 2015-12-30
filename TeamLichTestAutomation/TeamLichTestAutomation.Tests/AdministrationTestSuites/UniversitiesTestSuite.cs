namespace TeamLichTestAutomation.Tests.AdministrationTestSuites
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;

    using System.Threading;
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Controls.HtmlControls.HtmlAsserts;
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.ObjectModel;
    using ArtOfTest.WebAii.TestAttributes;
    using ArtOfTest.WebAii.TestTemplates;
    using ArtOfTest.WebAii.Win32.Dialogs;

    using System.Windows.Forms;

    using ArtOfTest.WebAii.Silverlight;
    using ArtOfTest.WebAii.Silverlight.UI;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.AdminPages.AdminDashboardPage;
    using TeamLichTestAutomation.Academy.Core.Pages.AdminPages.UniversitiesPage;
    using TeamLichTestAutomation.Academy.Core.Pages.LoginPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;
    using Telerik.TestingFramework.Controls.KendoUI;
    using TeamLichTestAutomation.Academy.Core;
    using TeamLichTestAutomation.TestFramework.Core;
    using ArtOfTest.Common.Serialization;
    using TeamLichTestAutomation.Utilities.Attributes;
    using TeamLichTestAutomation.Utilities;

    /// <summary>
    /// Summary description for UniversitiesTestSuite
    /// </summary>
    [TestClass]
    public class UniversitiesTestSuite : BaseTest
    {
        private Browser browser;
        private MainPage mainPage;
        private LoginPage loginPage;
        private AdminDashboardPage dashboardPage;
        private UniversitiesPage uniPage;

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

            Manager.LaunchNewBrowser(BrowserType.InternetExplorer);
            this.browser = Manager.ActiveBrowser;
            this.browser.ClearCache(BrowserCacheType.Cookies);
            this.browser.Window.Maximize();

            this.mainPage = new MainPage(this.browser);
            mainPage.Navigate().ClickLogin();

            loginPage = new LoginPage(this.browser);
            this.loginPage.LoginUser(TelerikUser.Admin);

            mainPage.ClickAdminNavigationDropdown();

            dashboardPage = new AdminDashboardPage(this.browser);
            this.dashboardPage.ClickUniversitiesButton();

            uniPage = new UniversitiesPage(this.browser);

            //
            // Place any additional initialization here
            //

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


        // These tests work only on Internet Explorer.
        // I can not handle the confirmation dialog on deletion in Chrome and Firefox

        [TestMethod]
        [TestCategory("AdministrationUniversities")]
        [TestCategory("PriorityHigh")]
        [TestOwner(Owner.DechoDechev)]
        public void TestAdminUniversityAddFunctionalityWorks()
        {   
            uniPage.AddUniversity("Telerik University");
            KendoGrid grid = uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            uniPage.AssertUniversityIsPresentInGrid(grid, "Telerik University");

            grid = uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            uniPage.DeleteRow(grid, "Telerik University", 1);
        }

        [TestMethod]
        [TestCategory("AdministrationUniversities")]
        [TestCategory("PriorityMedium")]
        [TestOwner(Owner.DechoDechev)]
        public void TestAdminUniversityRemoveFunctionalityWorks()
        {
            KendoGrid grid = uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            uniPage.AddUniversity("Telerik University");
            this.browser.RefreshDomTree();
            grid = uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            uniPage.AssertUniversityIsPresentInGrid(grid, "Telerik University");

            grid = uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            uniPage.DeleteRow(grid, "Telerik University", 1);

            Thread.Sleep(1000);
            uniPage.Browser.RefreshDomTree();
            grid = uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            uniPage.AssertUniversityIsNotPresentInGrid(grid, "Telerik University");
        }

        [TestMethod]
        [TestCategory("AdministrationUniversities")]
        [TestCategory("PriorityLow")]
        [TestOwner(Owner.DechoDechev)]
        public void TestAdminUniversityBackToAdministrationButtonWorks()
        {
            uniPage.BackToAdmin();
            dashboardPage.AssertCurrentlyOnThePage();
        }

        [TestMethod]
        [TestCategory("AdministrationUniversities")]
        [TestCategory("PriorityMedium")]
        [TestOwner(Owner.DechoDechev)]
        public void TestAdminUniversityEditNameWorks()
        {
            string newUniversityName = "Telerik University";
            uniPage.AddUniversity(newUniversityName);
            KendoGrid grid = uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            uniPage.EditRow(grid, newUniversityName, "Name", "Progress University", 1);

            this.browser.RefreshDomTree();
            grid = uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            uniPage.AssertUniversityIsPresentInGrid(grid, "Progress University");
            uniPage.DeleteRow(grid, "Progress University", 1);

            Thread.Sleep(1000);
            this.browser.RefreshDomTree();
            grid = uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            uniPage.AssertUniversityIsNotPresentInGrid(grid, "Progress University");
        }
    }
}