namespace TeamLichTestAutomation.Tests.AdministrationTestSuites
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.AdminPages.AdminDashboardPage;
    using TeamLichTestAutomation.Academy.Core.Pages.AdminPages.UniversitiesPage;
    using TeamLichTestAutomation.Academy.Core.Pages.LoginPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;

    using TeamLichTestAutomation.Utilities.Attributes;

    [TestClass]
    public class UsersTestSuite : BaseTest
    {
        private MainPage mainPage;
        private LoginPage loginPage;
        private AdminDashboardPage dashboardPage;
        private UsersPage usersPage;

        [TestInitialize]
        public void ThisTestInitialize()
        {
            this.mainPage = new MainPage(this.Browser);
            this.mainPage.Navigate().ClickLogin();

            this.loginPage = new LoginPage(this.Browser);
            this.loginPage.LoginUser(TelerikUser.Admin);

            this.mainPage.ClickAdminNavigationDropdown();

            this.dashboardPage = new AdminDashboardPage(this.Browser);
            this.dashboardPage.ClickUsersButton();

            this.usersPage = new UsersPage(this.Browser);
        }

        // These tests work only on Internet Explorer
        [TestMethod]
        [TestCategory("AdministrationUsers")]
        [Priority(4)]
        [TestId(261)]
        [Owner("Dimitar")]
        public void AdminUsersBackToAdministrationButton()
        {
            this.usersPage.BackToAdmin();
            this.dashboardPage.AssertCurrentlyOnThePage();
        }
    }
}
