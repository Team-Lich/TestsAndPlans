namespace TeamLichTestAutomation.Tests.AdministrationTestSuites
{
    using System.Threading;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.AdminPages.AdminDashboardPage;
    using TeamLichTestAutomation.Academy.Core.Pages.AdminPages.WorkEducationStatusesPage;
    using TeamLichTestAutomation.Academy.Core.Pages.LoginPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;

    using TeamLichTestAutomation.Utilities.Attributes;

    using Telerik.TestingFramework.Controls.KendoUI;

    [TestClass]
    public class WorkEducationStatusesTestSuite : BaseTest
    {
        private MainPage mainPage;
        private LoginPage loginPage;
        private AdminDashboardPage dashboardPage;
        private WorkEducationStatusesPage workEducationStatusesPage;

        [TestInitialize]
        public void ThisTestInitialize()
        {
            this.mainPage = new MainPage(this.Browser);
            this.mainPage.Navigate().ClickLogin();

            this.loginPage = new LoginPage(this.Browser);
            this.loginPage.LoginUser(TelerikUser.Admin);

            this.mainPage.ClickAdminNavigationDropdown();

            this.dashboardPage = new AdminDashboardPage(this.Browser);
            this.dashboardPage.ClickWorkEducationStatusesButton();

            this.workEducationStatusesPage = new WorkEducationStatusesPage(this.Browser);
        }

        //// These tests work only on Internet Explorer

        [TestMethod]
        [TestCategory("AdministrationWorkEducationStatuse")]
        [Priority(4)]
        [TestId(262)]
        [Owner("Dimitar")]
        public void AdminWorkEducationStatusesBackToAdministrationButton()
        {
            this.workEducationStatusesPage.BackToAdmin();
            this.dashboardPage.AssertCurrentlyOnThePage();
        }

        [TestMethod]
        [TestCategory("AdministrationWorkEducationStatuse")]
        [Priority(2)]
        [TestId(157)]
        [Owner("Dimitar")]
        public void AdminWorkEducationStatusesAddFunctionality()
        {
            this.workEducationStatusesPage.AddStatus("Telerik Status");
            KendoGrid grid = this.workEducationStatusesPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.workEducationStatusesPage.AssertWorkEducationStatusIsPresentInGrid(grid, "Telerik Status");

            grid = this.workEducationStatusesPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.workEducationStatusesPage.DeleteRow(grid, "Telerik Status", 1);
        }

        [TestMethod]
        [TestCategory("AdministrationWorkEducationStatuses")]
        [Priority(3)]
        [TestId(156)]
        [Owner("Dimitar")]
        public void AdminWorkEducationStatusesDelete()
        {
            string newStatusName = "Telerik Status";
            this.workEducationStatusesPage.AddStatus(newStatusName);
            KendoGrid grid = this.workEducationStatusesPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");

            this.Browser.RefreshDomTree();
            grid = this.workEducationStatusesPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.workEducationStatusesPage.DeleteRow(grid, "Telerik Status", 1);

            Thread.Sleep(1000);
            this.Browser.RefreshDomTree();
            grid = this.workEducationStatusesPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.workEducationStatusesPage.AssertWorkEducationStatusIsNotPresentInGrid(grid, "Telerik Status");
        }
    }
}