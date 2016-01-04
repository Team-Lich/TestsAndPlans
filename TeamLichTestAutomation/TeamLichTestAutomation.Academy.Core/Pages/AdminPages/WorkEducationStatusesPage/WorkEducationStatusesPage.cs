namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.WorkEducationStatusesPage
{
    using System.Threading;
    using System.Windows.Forms;

    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.Win32.Dialogs;

    using Telerik.TestingFramework.Controls.KendoUI;

    public partial class WorkEducationStatusesPage : BasePage
    {
        public WorkEducationStatusesPage(Browser browser)
           : base(browser)
        {
        }

        public void AddStatus(string labelName)
        {
            this.Browser.RefreshDomTree();
            this.AddButton.Click();

            var currentManager = Manager.Current;

            var nameBox = this.NameTextbox.GetRectangle();

            currentManager.Desktop.Mouse.Click(MouseClickType.LeftDoubleClick, nameBox);
            currentManager.Desktop.KeyBoard.TypeText(labelName, 50);

            currentManager.Desktop.Mouse.Click(MouseClickType.LeftClick, nameBox.Right + 10, nameBox.Top + 10);

            this.UpdateButton.Click();
            Thread.Sleep(1000);
        }

        public void DeleteRow(KendoGrid grid, string value, int searchColumn)
        {
            var rows = grid.DataItems;
            HtmlAnchor deleteButton = null;

            foreach (var row in rows)
            {
                if (row[searchColumn].InnerText == value)
                {
                    // It works only on Internet Explorer on my machine
                    deleteButton = row.Find.ByExpression<HtmlAnchor>("class=~k-grid-delete");
                    deleteButton.ScrollToVisible();

                    this.Browser.RefreshDomTree();
                    var deleteRectangle = deleteButton.GetRectangle();

                    var currentManager = Manager.Current;

                    AlertDialog alertDialog = new AlertDialog(this.Browser, DialogButton.OK);
                    currentManager.DialogMonitor.AddDialog(alertDialog);

                    currentManager.Desktop.Mouse.Click(MouseClickType.LeftClick, deleteRectangle);

                    this.Browser.Desktop.KeyBoard.KeyPress(Keys.Return);
                }
            }
        }

        public void BackToAdmin()
        {
            this.BackToAdminButton.Click();
        }
    }
}