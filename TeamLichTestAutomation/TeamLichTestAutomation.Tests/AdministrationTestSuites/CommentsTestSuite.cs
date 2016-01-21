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
    public class CommentsTestSuite : BaseTest
    {
        private MainPage mainPage;
        private LoginPage loginPage;
        private AdminDashboardPage dashboardPage;
        private CommentsPage commentsPage;

        [TestInitialize]
        public void ThisTestInitialize()
        {
            this.mainPage = new MainPage(this.Browser);
            this.mainPage.Navigate().ClickLogin();

            this.loginPage = new LoginPage(this.Browser);
            this.loginPage.LoginUser(TelerikUser.Admin);

            this.mainPage.ClickAdminNavigationDropdown();

            this.dashboardPage = new AdminDashboardPage(this.Browser);
            this.dashboardPage.ClickCommentsButton();

            this.commentsPage = new CommentsPage(this.Browser);
        }

        //// These tests work only on Internet Explorer

        [TestMethod]
        [TestCategory("AdministrationComments")]
        [Priority(4)]
        [TestId(257)]
        [Owner("Dimitar")]
        public void AdminCommentsBackToAdministrationButton()
        {
            this.commentsPage.BackToAdmin();
            this.dashboardPage.AssertCurrentlyOnThePage();
        }

        [TestMethod]
        [TestCategory("AdministrationComments")]
        [Priority(4)]
        [TestId(302)]
        [Owner("Dimitar")]
        public void AdminCommentsExportAsExcelFunctionallity()
        {
            this.commentsPage.ExportAsExcel();

            ////fix date format

            string ex = FileSystemHelper.GetExpectedFileName("Comments_Export_");
            bool fileExists = FileSystemHelper.FilePresentInUserDownloadsDirectory(ex, "xlsx");
            Assert.IsTrue(fileExists);
        }
    }
}
