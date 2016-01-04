namespace TeamLichTestAutomation.Tests.AdministrationTestSuites
{
    using System.Threading;

    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.TestTemplates;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.AdminPages.AdminDashboardPage;
    using TeamLichTestAutomation.Academy.Core.Pages.AdminPages.UniversitiesPage;
    using TeamLichTestAutomation.Academy.Core.Pages.LoginPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;

    using TeamLichTestAutomation.TestFramework.Core;

    using TeamLichTestAutomation.Utilities;
    using TeamLichTestAutomation.Utilities.Attributes;

    using Telerik.TestingFramework.Controls.KendoUI;

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

            #endregion WebAii Initialization

            Manager.LaunchNewBrowser(BrowserType.InternetExplorer);
            this.browser = Manager.ActiveBrowser;
            this.browser.ClearCache(BrowserCacheType.Cookies);
            this.browser.Window.Maximize();

            this.mainPage = new MainPage(this.browser);
            this.mainPage.Navigate().ClickLogin();

            this.loginPage = new LoginPage(this.browser);
            this.loginPage.LoginUser(TelerikUser.Admin);

            this.mainPage.ClickAdminNavigationDropdown();

            this.dashboardPage = new AdminDashboardPage(this.browser);
            this.dashboardPage.ClickUniversitiesButton();

            this.uniPage = new UniversitiesPage(this.browser);

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

        // These tests work only on Internet Explorer.
        // I can not handle the confirmation dialog on deletion in Chrome and Firefox

        [TestMethod]
        [TestCategory("AdministrationUniversities")]
        [TestCategory("PriorityHigh")]
        [TestOwner(Owner.DechoDechev)]
        public void TestAdminUniversityAddFunctionalityWorks()
        {
            this.uniPage.AddUniversity("Telerik University");
            KendoGrid grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.uniPage.AssertUniversityIsPresentInGrid(grid, "Telerik University");

            grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.uniPage.DeleteRow(grid, "Telerik University", 1);
        }

        [TestMethod]
        [TestCategory("AdministrationUniversities")]
        [TestCategory("PriorityMedium")]
        [TestOwner(Owner.Dimitar)]
        public void TestAdminUniversityExportAsExcelFunctionalityWorks()
        {
            this.uniPage.ExportAsExcel();
        }

        [TestMethod]
        [TestCategory("AdministrationUniversities")]
        [TestCategory("PriorityMedium")]
        [TestOwner(Owner.DechoDechev)]
        public void TestAdminUniversityRemoveFunctionalityWorks()
        {
            KendoGrid grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.uniPage.AddUniversity("Telerik University");
            this.browser.RefreshDomTree();
            grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.uniPage.AssertUniversityIsPresentInGrid(grid, "Telerik University");

            grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.uniPage.DeleteRow(grid, "Telerik University", 1);

            Thread.Sleep(1000);
            this.uniPage.Browser.RefreshDomTree();
            grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.uniPage.AssertUniversityIsNotPresentInGrid(grid, "Telerik University");
        }

        [TestMethod]
        [TestCategory("AdministrationUniversities")]
        [TestCategory("PriorityLow")]
        [TestOwner(Owner.DechoDechev)]
        public void TestAdminUniversityBackToAdministrationButtonWorks()
        {
            this.uniPage.BackToAdmin();
            this.dashboardPage.AssertCurrentlyOnThePage();
        }

        [TestMethod]
        [TestCategory("AdministrationUniversities")]
        [TestCategory("PriorityMedium")]
        [TestOwner(Owner.DechoDechev)]
        public void TestAdminUniversityEditNameWorks()
        {
            string newUniversityName = "Telerik University";
            this.uniPage.AddUniversity(newUniversityName);
            KendoGrid grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.uniPage.EditRow(grid, newUniversityName, "Name", "Progress University", 1);

            this.browser.RefreshDomTree();
            grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.uniPage.AssertUniversityIsPresentInGrid(grid, "Progress University");
            this.uniPage.DeleteRow(grid, "Progress University", 1);

            Thread.Sleep(1000);
            this.browser.RefreshDomTree();
            grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.uniPage.AssertUniversityIsNotPresentInGrid(grid, "Progress University");
        }

        [TestMethod]
        [TestCategory("AdministrationUniversities")]
        [TestCategory("PriorityMedium")]
        [TestOwner(Owner.Dimitar)]
        public void TestAdminUniversityDeleteWorks()
        {
        string newUniversityName = "Telerik University";
        this.uniPage.AddUniversity(newUniversityName);
        KendoGrid grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");

        this.browser.RefreshDomTree();
        grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
        this.uniPage.AssertUniversityIsPresentInGrid(grid, "Telerik University");
        this.uniPage.DeleteRow(grid, "Telerik University", 1);

        Thread.Sleep(1000);
        this.browser.RefreshDomTree();
        grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
        this.uniPage.AssertUniversityIsNotPresentInGrid(grid, "Telerik University");
        }


        [TestMethod]
        [TestCategory("AdministrationUniversities")]
        [TestCategory("PriorityLow")]
        [TestOwner(Owner.DechoDechev)]
        public void TestSortByNameInUniversityGridWorks()
        {
            KendoGrid grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");

            this.uniPage.AddUniversity("Аграрен Университет");
            this.uniPage.AddUniversity("Среден Университет");
            this.uniPage.AddUniversity("Ямболски университет");

            grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");

            var initialUniversityOrder = grid.ValuesInColumn(1);

            this.uniPage.SortByName(grid);

            var manager = Manager.ActiveBrowser;
            Thread.Sleep(2000);
            manager.RefreshDomTree();
            grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");

            var sortedUniversityOrder = grid.ValuesInColumn(1);

            this.uniPage.AssertColumnIsSorted(initialUniversityOrder, sortedUniversityOrder, true);

            this.uniPage.SortByName(grid);

            Thread.Sleep(2000);
            manager.RefreshDomTree();
            grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");

            sortedUniversityOrder = grid.ValuesInColumn(1);

            this.uniPage.AssertColumnIsSorted(initialUniversityOrder, sortedUniversityOrder, false);

            grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.uniPage.DeleteRow(grid, "Аграрен Университет", 1);
            Thread.Sleep(1000);

            manager.RefreshDomTree();
            grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.uniPage.DeleteRow(grid, "Среден Университет", 1);

            manager.RefreshDomTree();
            grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.uniPage.DeleteRow(grid, "Ямболски университет", 1);
        }

        [TestMethod]
        [TestCategory("AdministrationUniversities")]
        [TestCategory("PriorityLow")]
        [TestOwner(Owner.DechoDechev)]
        public void TestSortByIdInUniversityGridWorks()
        {
            KendoGrid grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");

            var initialUniversityOrder = grid.ValuesInColumn(0);

            this.uniPage.SortById(grid);

            var manager = Manager.ActiveBrowser;
            Thread.Sleep(2000);
            manager.RefreshDomTree();
            grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");

            var sortedUniversityOrder = grid.ValuesInColumn(0);

            this.uniPage.AssertColumnIsSorted(initialUniversityOrder, sortedUniversityOrder, false);

            this.uniPage.SortById(grid);

            Thread.Sleep(2000);
            manager.RefreshDomTree();
            grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");

            sortedUniversityOrder = grid.ValuesInColumn(0);

            this.uniPage.AssertColumnIsSorted(initialUniversityOrder, sortedUniversityOrder, true);
        }

        [TestMethod]
        [TestCategory("AdministrationUniversities")]
        [TestCategory("PriorityLow")]
        [TestOwner(Owner.DechoDechev)]
        public void Test()
        {
            KendoGrid grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");

            this.uniPage.SortByName(grid);
            Thread.Sleep(1000);
            Manager manager = Manager.Current;
            manager.ActiveBrowser.RefreshDomTree();
            grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");

            grid.IsColumnSortDescending(1);

            this.uniPage.SortByName(grid);
            Thread.Sleep(1000);
            manager.ActiveBrowser.RefreshDomTree();
            grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");

            grid.IsColumnSortDescending(1);
        }
    }
}