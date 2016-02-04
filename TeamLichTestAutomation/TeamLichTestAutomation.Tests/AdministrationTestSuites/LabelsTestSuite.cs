namespace TeamLichTestAutomation.Tests.AdministrationTestSuites
{
    using System.Threading;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.AdminPages.AdminDashboardPage;
    using TeamLichTestAutomation.Academy.Core.Pages.AdminPages.LabelsPage;
    using TeamLichTestAutomation.Academy.Core.Pages.LoginPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;

    using TeamLichTestAutomation.Utilities.Attributes;

    using Telerik.TestingFramework.Controls.KendoUI;

    [TestClass]
    public class LabelsTestSuite : BaseTest
    {
        private MainPage mainPage;
        private LoginPage loginPage;
        private AdminDashboardPage dashboardPage;
        private LabelsPage labelsPage;

        [TestInitialize]
        public void ThisTestInitialize()
        {
            this.mainPage = new MainPage(this.Browser);
            this.mainPage.Navigate().ClickLogin();

            this.loginPage = new LoginPage(this.Browser);
            this.loginPage.LoginUser(TelerikUser.Admin);

            this.mainPage.ClickAdminNavigationDropdown();

            this.dashboardPage = new AdminDashboardPage(this.Browser);
            this.dashboardPage.ClickLabelsButton();

            this.labelsPage = new LabelsPage(this.Browser);
        }

        //// These tests work only on Internet Explorer

        [TestMethod]
        [TestCategory("AdministrationLabels")]
        [Priority(3)]
        [TestId(191)]
        [Owner("Dimitar")]
        public void AdminLabelsAddFunctionality()
        {
            this.labelsPage.AddLabel("Telerik Label");
            KendoGrid grid = this.labelsPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.labelsPage.AssertLabelIsPresentInGrid(grid, "Telerik Label");

            grid = this.labelsPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.labelsPage.DeleteRow(grid, "Telerik Label", 1);
        }

        [TestMethod]
        [TestCategory("AdministrationLabels")]
        [Priority(3)]
        [TestId(193)]
        [Owner("Dimitar")]
        public void AdminLabelsDelete()
        {
            string newLabelsName = "Telerik Label";
            this.labelsPage.AddLabel(newLabelsName);
            KendoGrid grid = this.labelsPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");

            this.Browser.RefreshDomTree();
            grid = this.labelsPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.labelsPage.DeleteRow(grid, "Telerik Label", 1);

            Thread.Sleep(1000);
            this.Browser.RefreshDomTree();
            grid = this.labelsPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");
            this.labelsPage.AssertLabelIsNotPresentInGrid(grid, "Telerik Label");
        }

        [TestMethod]
        [TestCategory("AdministrationLabels")]
        [Priority(4)]
        [TestId(258)]
        [Owner("Dimitar")]
        public void AdminLabelsBackToAdministrationButton()
        {
            this.labelsPage.BackToAdmin();
            this.dashboardPage.AssertCurrentlyOnThePage();
        }
    }
}
