namespace TeamLichTestAutomation.Tests.AdministrationTestSuites
{
    using System;
    using System.Threading;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.AdminPages.AdminDashboardPage;
    using TeamLichTestAutomation.Academy.Core.Pages.AdminPages.UniversitiesPage;
    using TeamLichTestAutomation.Academy.Core.Pages.LoginPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;

    using TeamLichTestAutomation.TestFramework.Core;

    using TeamLichTestAutomation.Utilities;
    using TeamLichTestAutomation.Utilities.Attributes;

    [TestClass]
    public class UniversitiesTestSuite : BaseTest
    {
        private RandomStringGenerator generator;

        private MainPage mainPage;
        private LoginPage loginPage;
        private AdminDashboardPage dashboardPage;
        private UniversitiesPage uniPage;

        [TestInitialize]
        public void ThisTestInitialize()
        {
            this.mainPage = new MainPage(this.Browser);
            this.generator = new RandomStringGenerator();

            this.loginPage = new LoginPage(this.Browser);
            this.dashboardPage = new AdminDashboardPage(this.Browser);
            this.uniPage = new UniversitiesPage(this.Browser);

            this.mainPage.NavigateTo(this.loginPage.Url);
            this.loginPage.LoginUser(TelerikUser.Admin);
            this.mainPage.NavigateTo(this.uniPage.Url);
        }

        //// These tests work only on Internet Explorer

        [TestMethod]
        [TestId(100)]
        [TestCategory("AdministrationUniversities")]
        [Priority(2)]
        [Owner("Decho")]
        public void AdminUniversityAddFunctionality()
        {
            string uniName = "LichInitUni-" + this.generator.GetString(8);
            this.uniPage.AddUniversity(uniName);
            this.uniPage.AssertUniversityIsPresentInGrid(this.uniPage.KendoTable, uniName);

            this.uniPage.DeleteRow(uniName, 1);
        }

        [TestMethod]
        [TestCategory("AdministrationUniversities")]
        [Priority(3)]
        [TestId(89)]
        [Owner("Dimitar")]
        public void AdminUniversityExportAsExcelFunctionality()
        {
            this.uniPage.ExportAsExcel();

            DateTime dateTime = DateTime.Now;
            string dateString = dateTime.ToString("yyyy-MM-dd_hh-mm");
            string fileName = "Universities_Export_" + dateString;
            string ex = FileSystemHelper.GetExpectedFileName(fileName);
            bool fileExists = FileSystemHelper.FilePresentInUserDownloadsDirectory(fileName, "xlsx");
            Assert.IsTrue(fileExists);
        }

        [TestMethod]
        [TestId(84)]
        [TestCategory("AdministrationUniversities")]
        [Priority(3)]
        [Owner("Decho")]
        public void AdminUniversityRemoveFunctionality()
        {
            string uniName = "LichInitUni-" + this.generator.GetString(8);
            this.uniPage.AddUniversity(uniName);

            this.uniPage.AssertUniversityIsPresentInGrid(this.uniPage.KendoTable, uniName);

            this.uniPage.DeleteRow(uniName, 1);
            Thread.Sleep(1000);
            this.uniPage.AssertUniversityIsNotPresentInGrid(this.uniPage.KendoTable, uniName);
        }

        [TestMethod]
        [TestCategory("AdministrationUniversities")]
        [Priority(4)]
        [TestId(269)]
        [Owner("Decho")]
        public void AdminUniversityBackToAdministrationButton()
        {
            this.uniPage.BackToAdmin();
            this.dashboardPage.AssertCurrentlyOnThePage();
        }

        [TestMethod]
        [TestId(88)]
        [TestCategory("AdministrationUniversities")]
        [Priority(3)]
        [Owner("Decho")]
        public void AdminUniversityEditName()
        {
            string initialUniversityName = "LichInitUni-" + this.generator.GetString(8);
            this.uniPage.AddUniversity(initialUniversityName);

            string newUniversityName = "LichRenamed-" + this.generator.GetString(8);
            this.uniPage.EditRow(initialUniversityName, "Name", newUniversityName, 1);

            this.uniPage.AssertUniversityIsPresentInGrid(this.uniPage.KendoTable, newUniversityName);

            this.uniPage.DeleteRow(newUniversityName, 1);
            this.uniPage.AssertUniversityIsNotPresentInGrid(this.uniPage.KendoTable, newUniversityName);
        }

        [TestMethod]
        [TestCategory("AdministrationUniversities")]
        [Priority(3)]
        [TestId(268)]
        [Owner("Dimitar")]
        public void AdminUniversityDeleteRow()
        {
            string uniName = "LichInitUni-" + this.generator.GetString(8);
            this.uniPage.AddUniversity(uniName);

            this.uniPage.AssertUniversityIsPresentInGrid(this.uniPage.KendoTable, uniName);

            this.uniPage.DeleteRow(uniName, 1);
            this.uniPage.AssertUniversityIsNotPresentInGrid(this.uniPage.KendoTable, uniName);
        }

        [TestMethod]
        [TestId(253)]
        [TestCategory("AdministrationUniversities")]
        [Priority(4)]
        [Owner("Decho")]
        public void AdminUniversitySortByNameInGrid()
        {
            this.uniPage.AddUniversity("Аграрен Университет");
            this.uniPage.AddUniversity("Среден Университет");
            this.uniPage.AddUniversity("Ямболски университет");
           
            this.uniPage.SortByName();
            Thread.Sleep(1000);
            var sortedUniversityOrder = this.uniPage.KendoTable.ValuesInColumn(1);
            this.uniPage.AssertStringColumnIsSorted(sortedUniversityOrder, true);

            this.uniPage.SortByName();
            Thread.Sleep(1000);
            sortedUniversityOrder = this.uniPage.KendoTable.ValuesInColumn(1);
            this.uniPage.AssertStringColumnIsSorted(sortedUniversityOrder, false);

            this.uniPage.DeleteRow("Аграрен Университет", 1);
            Thread.Sleep(1000);
            this.uniPage.DeleteRow("Среден Университет", 1);
            Thread.Sleep(1000);
            this.uniPage.DeleteRow("Ямболски университет", 1);
            Thread.Sleep(1000);
        }

        [TestMethod]
        [TestId(254)]
        [TestCategory("AdministrationUniversities")]
        [Priority(4)]
        [Owner("Decho")]
        public void AdminUniversitySortByIdInGrid()
        {
            this.uniPage.SortById();
            Thread.Sleep(2000);
            var sortedUniversityOrder = this.uniPage.KendoTable.ValuesInColumn(0);

            this.uniPage.AssertIntegerColumnIsSorted(sortedUniversityOrder, false);

            this.uniPage.SortById();
            Thread.Sleep(2000);
            sortedUniversityOrder = this.uniPage.KendoTable.ValuesInColumn(0);

            this.uniPage.AssertIntegerColumnIsSorted(sortedUniversityOrder, true);
        }

        [TestMethod]
        [TestCategory("FrameworkTest")]
        [Owner("Decho")]
        public void Test()
        {
            Assert.AreEqual(1, 1);
            ////KendoGrid grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");

            ////string expectedFileName = FileSystemHelper.GetExpectedFileName("Universities");
            ////bool res = FileSystemHelper.FilePresentInUserDownloadsDirectory(expectedFileName, "pdf");

            ////bool present = FileSystemHelper.FilePresentInUserDownloadsDirectory("Universities_Export_2016-01-11_10-49(1)");
            ////bool present1 = FileSystemHelper.FilePresentInUserDownloadsDirectory("Universities_Export_2016-01-11_10-49(2)");

            ////this.uniPage.SortByName();
            ////Thread.Sleep(1000);
            ////Manager manager = Manager.Current;
            ////manager.ActiveBrowser.RefreshDomTree();
            ////grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");

            ////grid.IsColumnSortDescending(1);

            ////this.uniPage.SortByName();
            ////Thread.Sleep(1000);
            ////manager.ActiveBrowser.RefreshDomTree();
            ////grid = this.uniPage.Browser.Find.ByExpression<KendoGrid>("data-role=grid");

            ////grid.IsColumnSortDescending(1);
        }
    }
}