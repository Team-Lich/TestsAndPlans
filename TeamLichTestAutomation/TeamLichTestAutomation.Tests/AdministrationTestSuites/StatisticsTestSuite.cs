namespace TeamLichTestAutomation.Tests.AdministrationTestSuites
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.AdminPages.AdminDashboardPage;
    using TeamLichTestAutomation.Academy.Core.Pages.AdminPages.StatisticsPage;
    using TeamLichTestAutomation.Academy.Core.Pages.LoginPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;

    using TeamLichTestAutomation.Utilities.Attributes;

    [TestClass]
    public class StatisticsTestSuite : BaseTest
    {
        private MainPage mainPage;
        private LoginPage loginPage;
        private AdminDashboardPage dashboardPage;
        private StatisticsPage statisticsPage;

        [TestInitialize]
        public void ThisTestInitialize()
        {
            this.mainPage = new MainPage(this.Browser);
            this.mainPage.Navigate().ClickLogin();

            this.loginPage = new LoginPage(this.Browser);
            this.loginPage.LoginUser(TelerikUser.Admin);

            this.mainPage.ClickAdminNavigationDropdown();

            this.dashboardPage = new AdminDashboardPage(this.Browser);
            this.dashboardPage.ClickStatisticsButton();

            this.statisticsPage = new StatisticsPage(this.Browser);
        }

        //// These tests work only on Internet Explorer

        [TestMethod]
        [TestCategory("AdministrationStatistics")]
        [Priority(4)]
        [TestId(305)]
        [Owner("Dimitar")]
        public void AdminStatisticsGenderChartExists()
        {
            this.statisticsPage.AssertChartExists(this.statisticsPage.GetGenderChart);
        }

        [TestMethod]
        [TestCategory("AdministrationStatistics")]
        [Priority(4)]
        [TestId(306)]
        [Owner("Dimitar")]
        public void AdminStatisticsCitiesChartExists()
        {
            this.statisticsPage.AssertChartExists(this.statisticsPage.GetCitiesChart);
        }

        [TestMethod]
        [TestCategory("AdministrationStatistics")]
        [Priority(4)]
        [TestId(307)]
        [Owner("Dimitar")]
        public void AdminStatisticsMonthlyRegistrationsChartExists()
        {
            this.statisticsPage.AssertChartExists(this.statisticsPage.GetMonthlyRegistrationsChart);
        }

        [TestMethod]
        [TestCategory("AdministrationStatistics")]
        [Priority(4)]
        [TestId(308)]
        [Owner("Dimitar")]
        public void AdminStatisticsLastSixtyDaysRegistrationsChartExists()
        {
            this.statisticsPage.AssertChartExists(this.statisticsPage.GetLastSixtyDaysRegistrationsChart);
        }
    }
}
