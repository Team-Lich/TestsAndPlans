namespace TeamLichTestAutomation.Tests.AdministrationTestSuites
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;

    using ArtOfTest.WebAii.Win32.Dialogs;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.AdminPages.AdminDashboardPage;
    using TeamLichTestAutomation.Academy.Core.Pages.AdminPages.UniversitiesPage;
    using TeamLichTestAutomation.Academy.Core.Pages.LoginPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;

    using TeamLichTestAutomation.Utilities.Attributes;

    [TestClass]
    public class ProvincesTestSuite : BaseTest
    {
        private MainPage mainPage;
        private LoginPage loginPage;
        private AdminDashboardPage dashboardPage;
        private ProvincesPage provincesPage;

        [TestInitialize]
        public void ThisTestInitialize()
        {
            this.mainPage = new MainPage(this.Browser);
            this.mainPage.Navigate().ClickLogin();

            this.loginPage = new LoginPage(this.Browser);
            this.loginPage.LoginUser(TelerikUser.Admin);

            this.mainPage.ClickAdminNavigationDropdown();

            this.dashboardPage = new AdminDashboardPage(this.Browser);
            this.dashboardPage.ClickProvincesButton();

            this.provincesPage = new ProvincesPage(this.Browser);
        }

        //// These tests work only on Internet Explorer

        [TestMethod]
        [TestCategory("AdministrationProvinces")]
        [Priority(4)]
        [TestId(259)]
        [Owner("Dimitar")]
        public void AdminProvincesBackToAdministrationButton()
        {
            this.provincesPage.BackToAdmin();
            this.dashboardPage.AssertCurrentlyOnThePage();
        }

        [TestMethod]
        [TestCategory("AdministrationProvinces")]
        [Priority(4)]
        [TestId(303)]
        [Owner("Dimitar")]
        public void AdminProvincesExportAsExcelFunctionallity()
        {
            DateTime dateTime = DateTime.Now;
            string filePath = Path.GetTempPath() + "Roles_Export_" + dateTime.ToString("yyyy-MM-dd_hh-mm") + ".xlsx";

            SaveAsDialog saveAsDialog = SaveAsDialog.CreateSaveAsDialog(
                this.Browser, DialogButton.SAVE, filePath, Manager.Desktop);
            Manager.DialogMonitor.AddDialog(saveAsDialog);

            this.provincesPage.ExportAsExcel();

            this.mainPage.LogoutButton.Focus();
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
    }
}
