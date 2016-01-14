namespace TeamLichTestAutomation.Tests.AdministrationTestSuites
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;

    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.TestTemplates;
    using ArtOfTest.WebAii.Win32.Dialogs;

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
    using TeamLichTestAutomation.Academy.Core.Pages.AdminPages.RolesPage;

    /// <summary>
    /// Summary description for UniversitiesTestSuite
    /// </summary>
    [TestClass]
    public class RolesTestSuite : BaseTest
    {
        private Browser browser;
        private MainPage mainPage;
        private LoginPage loginPage;
        private AdminDashboardPage dashboardPage;
        private RolesPage rolesPage;

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
            // Initialize(true, this.TestContext.TestLogsDir, new TestContextWriteLine(this.TestContext.WriteLine));

            // If you need to override any other settings coming from the
            // config section you can comment the 'Initialize' line above and instead
            // use the following:

            // This will get a new Settings object. If a configuration
            // section exists, then settings from that section will be
            // loaded

            // Override the settings you want. For example:
            // settings.Web.DefaultBrowser = BrowserType.FireFox;

            Settings settings = GetSettings();
            settings.Web.RecycleBrowser = true;
            settings.AnnotateExecution = true;
            settings.AnnotationMode = AnnotationMode.All;

            // Now call Initialize again with your updated settings object
            Initialize(settings, new TestContextWriteLine(this.TestContext.WriteLine));

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
            this.loginPage = new LoginPage(this.browser);
            this.dashboardPage = new AdminDashboardPage(this.browser);
            this.rolesPage = new RolesPage(this.browser);

            this.mainPage.NavigateTo(loginPage.Url);
            this.loginPage.LoginUser(TelerikUser.Admin);
            this.mainPage.NavigateTo(rolesPage.Url);
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
            BaseTest.ShutDown();
        }

        #endregion [Setup / TearDown]

        //// These tests work only on Internet Explorer.

        [TestMethod]
        [TestCategory("AdministrationRoles")]
        [Priority(4)]
        [TestId(260)]
        [Owner("Dimitar")]
        public void AdminRolesBackToAdministrationButton()
        {
            this.rolesPage.BackToAdmin();
            this.dashboardPage.AssertCurrentlyOnThePage();
        }

        [TestMethod]
        [TestCategory("AdministrationRoles")]
        [Priority(2)]
        [TestId(267)]
        [Owner("Dimitar")]
        public void AdminRolesAddRole()
        {
            RandomStringGenerator generator = new RandomStringGenerator();
            string roleName = "LichInitRole-" + generator.GetString(7);

            this.rolesPage.AddRole(roleName);
            KendoGrid grid = this.rolesPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.rolesPage.AssertRoleIsPresentInGrid(grid, roleName);

            grid = this.rolesPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.rolesPage.DeleteRow(grid, roleName, 2);
        }

        [TestMethod]
        [TestCategory("AdministrationRoles")]
        [Priority(3)]
        [TestId(265)]
        [Owner("Dimitar")]
        public void AdminRolesExportAsExcel()
        {
            DateTime dateTime = DateTime.Now;
            string filePath = Path.GetTempPath() + "Roles_Export_" + dateTime.ToString("yyyy-MM-dd_hh-mm") + ".xlsx";

            SaveAsDialog saveAsDialog = SaveAsDialog.CreateSaveAsDialog(
                this.browser, DialogButton.SAVE, filePath, Manager.Desktop);
            Manager.DialogMonitor.AddDialog(saveAsDialog);

            this.rolesPage.ExportAsExcel();

            mainPage.LogoutButton.Focus();
            Manager.Desktop.KeyBoard.KeyDown(Keys.Shift);
            for (int i = 0; i < 9; i++)
            {
                Manager.Desktop.KeyBoard.KeyPress(Keys.Tab);
            }

            Manager.Desktop.KeyBoard.KeyUp(Keys.Shift);
            Manager.Desktop.KeyBoard.KeyPress(Keys.Down);
            Manager.Desktop.KeyBoard.KeyPress(Keys.Down);
            Manager.Desktop.KeyBoard.KeyPress(Keys.Enter);
            saveAsDialog.WaitUntilHandled(10000);
            Thread.Sleep(2000);

            Assert.IsTrue(File.Exists(filePath));
            File.Delete(filePath);
        }

        [TestMethod]
        [TestCategory("AdministrationRoles")]
        [Priority(3)]
        [TestId(266)]
        [Owner("Dimitar")]
        public void AdminRolesEditRole()
        {
            RandomStringGenerator generator = new RandomStringGenerator();
            string initialRoleName = "LichInitRole-" + generator.GetString(7);
            this.rolesPage.AddRole(initialRoleName);

            string newRoleName = "LichRenamed-" + generator.GetString(8);
            KendoGrid grid = this.rolesPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.rolesPage.EditRow(grid, initialRoleName, "Name", newRoleName, 2);

            grid = this.rolesPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.rolesPage.AssertRoleIsNotPresentInGrid(grid, initialRoleName);
            this.rolesPage.AssertRoleIsPresentInGrid(grid, newRoleName);
            this.rolesPage.DeleteRow(grid, newRoleName, 2);
        }

        [TestMethod]
        [TestCategory("AdministrationRoles")]
        [Priority(3)]
        [TestId(263)]
        [Owner("Dimitar")]
        public void AdminRolesDeleteRole()
        {
            RandomStringGenerator generator = new RandomStringGenerator();
            string roleName = "LichInitRole-" + generator.GetString(7);
            this.rolesPage.AddRole(roleName);

            KendoGrid grid = this.rolesPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.rolesPage.DeleteRow(grid, roleName, 2);

            Thread.Sleep(1000);
            this.browser.RefreshDomTree();
            grid = this.rolesPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.rolesPage.AssertRoleIsNotPresentInGrid(grid, roleName);
        }

        [TestMethod]
        [TestCategory("AdministrationRoles")]
        [Priority(4)]
        [TestId(271)]
        [Owner("Dimitar")]
        public void AdminRolesSortByName()
        {
            KendoGrid grid = this.rolesPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");

            this.rolesPage.AddRole("Роля-1");
            this.rolesPage.AddRole("Роля-2");
            this.rolesPage.AddRole("Роля-3");

            grid = this.rolesPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");

            var initialRolesOrder = grid.ValuesInColumn(1);

            this.rolesPage.SortByName(grid);

            var manager = Manager.ActiveBrowser;
            Thread.Sleep(2000);
            manager.RefreshDomTree();
            grid = this.rolesPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");

            var sortedRolesOrder = grid.ValuesInColumn(1);

            this.rolesPage.AssertColumnIsSorted(initialRolesOrder, sortedRolesOrder, true);

            this.rolesPage.SortByName(grid);

            Thread.Sleep(2000);
            manager.RefreshDomTree();
            grid = this.rolesPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");

            sortedRolesOrder = grid.ValuesInColumn(1);

            this.rolesPage.AssertColumnIsSorted(initialRolesOrder, sortedRolesOrder, false);

            grid = this.rolesPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.rolesPage.DeleteRow(grid, "Роля-1", 2);
            Thread.Sleep(1000);

            manager.RefreshDomTree();
            grid = this.rolesPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.rolesPage.DeleteRow(grid, "Роля-2", 2);

            manager.RefreshDomTree();
            grid = this.rolesPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.rolesPage.DeleteRow(grid, "Роля-3", 2);
        }

        [TestMethod]
        [TestCategory("AdministrationRoles")]
        [Priority(4)]
        [TestId(270)]
        [Owner("Dimitar")]
        public void AdminRolesSortById()
        {
            KendoGrid grid = this.rolesPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");

            var initialRolesOrder = grid.ValuesInColumn(0);

            this.rolesPage.SortById(grid);

            var manager = Manager.ActiveBrowser;
            Thread.Sleep(2000);
            manager.RefreshDomTree();
            grid = this.rolesPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");

            var sortedRolesOrder = grid.ValuesInColumn(0);

            this.rolesPage.AssertColumnIsSorted(initialRolesOrder, sortedRolesOrder, false);

            this.rolesPage.SortById(grid);

            Thread.Sleep(2000);
            manager.RefreshDomTree();
            grid = this.rolesPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");

            sortedRolesOrder = grid.ValuesInColumn(0);

            this.rolesPage.AssertColumnIsSorted(initialRolesOrder, sortedRolesOrder, true);
        }
    }
}