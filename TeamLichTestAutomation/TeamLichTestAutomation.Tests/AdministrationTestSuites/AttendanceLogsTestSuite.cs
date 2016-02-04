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
    public class AttendanceLogsTestSuite : BaseTest
    {
        private MainPage mainPage;
        private LoginPage loginPage;
        private AdminDashboardPage dashboardPage;
        private AttendanceLogsPage attendanceLogsPage;

        [TestInitialize]
        public void ThisTestInitialize()
        {
            this.mainPage = new MainPage(this.Browser);
            this.mainPage.Navigate().ClickLogin();

            this.loginPage = new LoginPage(this.Browser);
            this.loginPage.LoginUser(TelerikUser.Admin);

            this.mainPage.ClickAdminNavigationDropdown();

            this.dashboardPage = new AdminDashboardPage(this.Browser);
            this.dashboardPage.ClickAttendanceLogsButton();

            this.attendanceLogsPage = new AttendanceLogsPage(this.Browser);
        }

        //// These tests work only on Internet Explorer

        [TestMethod]
        [TestCategory("AdministrationAttendanceLogs")]
        [Priority(4)]
        [TestId(255)]
        [Owner("Dimitar")]
        public void AdminAttendanceLogsBackToAdministrationButton()
        {
            this.attendanceLogsPage.BackToAdmin();
            this.dashboardPage.AssertCurrentlyOnThePage();
        }

        [TestMethod]
        [TestCategory("AdministrationAttendanceLogs")]
        [Priority(4)]
        [TestId(300)]
        [Owner("Dimitar")]
        public void AdminAttendanceLogsExportAsExcelFunctionallity()
        {
            this.attendanceLogsPage.ExportAsExcel();

            ////fix date format

            string ex = FileSystemHelper.GetExpectedFileName("AttendanceLogs_Export_");
            bool fileExists = FileSystemHelper.FilePresentInUserDownloadsDirectory(ex, "xlsx");
            Assert.IsTrue(fileExists);
        }
    }
}
