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
    using TeamLichTestAutomation.Academy.Core.Pages.AdminPages.RolesPage;
    using TeamLichTestAutomation.Academy.Core.Pages.LoginPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;

    using TeamLichTestAutomation.TestFramework.Core;

    using TeamLichTestAutomation.Utilities;
    using TeamLichTestAutomation.Utilities.Attributes;

    using Telerik.TestingFramework.Controls.KendoUI;

    [TestClass]
    public class RolesTestSuite : BaseTest
    {
        private MainPage mainPage;
        private LoginPage loginPage;
        private AdminDashboardPage dashboardPage;
        private RolesPage rolesPage;

        [TestInitialize]
        public void ThisTestInitialize()
        {
            this.mainPage = new MainPage(this.Browser);
            this.loginPage = new LoginPage(this.Browser);
            this.dashboardPage = new AdminDashboardPage(this.Browser);
            this.rolesPage = new RolesPage(this.Browser);

            this.mainPage.NavigateTo(this.loginPage.Url);
            this.loginPage.LoginUser(TelerikUser.Admin);
            this.mainPage.NavigateTo(this.rolesPage.Url);
        }

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
        [Priority(3)]
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
                this.Browser, DialogButton.SAVE, filePath, Manager.Desktop);
            Manager.DialogMonitor.AddDialog(saveAsDialog);

            this.rolesPage.ExportAsExcel();

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
            this.Browser.RefreshDomTree();
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