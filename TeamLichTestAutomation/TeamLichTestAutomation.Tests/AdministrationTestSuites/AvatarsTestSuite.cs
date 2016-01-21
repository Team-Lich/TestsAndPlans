namespace TeamLichTestAutomation.Tests.AdministrationTestSuites
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.AdminPages.AdminDashboardPage;
    using TeamLichTestAutomation.Academy.Core.Pages.AdminPages.UniversitiesPage;
    using TeamLichTestAutomation.Academy.Core.Pages.LoginPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;

    using TeamLichTestAutomation.Utilities;
    using TeamLichTestAutomation.Utilities.Attributes;

    [TestClass]
    public class AvatarsTestSuite : BaseTest
    {
        private MainPage mainPage;
        private LoginPage loginPage;
        private AdminDashboardPage dashboardPage;
        private AvatarsPage avatarsPage;

        [TestInitialize]
        public void ThisTestInitialize()
        {
            this.mainPage = new MainPage(this.Browser);
            this.mainPage.Navigate().ClickLogin();

            this.loginPage = new LoginPage(this.Browser);
            this.loginPage.LoginUser(TelerikUser.Admin);

            this.mainPage.ClickAdminNavigationDropdown();

            this.dashboardPage = new AdminDashboardPage(this.Browser);
            this.dashboardPage.ClickAvatarsButton();

            this.avatarsPage = new AvatarsPage(this.Browser);
        }

        //// These tests work only on Internet Explorer

        [TestMethod]
        [TestCategory("AdministrationAvatars")]
        [Priority(4)]
        [TestId(256)]
        [Owner("Dimitar")]
        public void AdminAvatarsBackToAdministrationButton()
        {
            this.avatarsPage.BackToAdmin();
            this.dashboardPage.AssertCurrentlyOnThePage();
        }

        [TestMethod]
        [TestCategory("AdministrationAvatars")]
        [Priority(4)]
        [TestId(301)]
        [Owner("Dimitar")]
        public void AdminAvatarsExportAsExcelFunctionallity()
        {
            this.avatarsPage.ExportAsExcel();

            ////fix date format

            string ex = FileSystemHelper.GetExpectedFileName("Avatars_Export_");
            bool fileExists = FileSystemHelper.FilePresentInUserDownloadsDirectory(ex, "xlsx");
            Assert.IsTrue(fileExists);
        }
    }
}
