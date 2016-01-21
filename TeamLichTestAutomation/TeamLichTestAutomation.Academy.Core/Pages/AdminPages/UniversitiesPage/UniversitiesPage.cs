namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.UniversitiesPage
{
    using System.Threading;
    using System.Windows.Forms;

    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.Win32.Dialogs;

    public partial class UniversitiesPage : BasePage
    {
        private readonly string url = "http://stage.telerikacademy.com/Administration_Users/Universities";

        public UniversitiesPage(Browser browser)
            : base(browser)
        {
        }

        public string Url
        {
            get
            {
                return this.url;
            }
        }

        public void BackToAdmin()
        {
            this.BackToAdminButton.Click();
        }

        public void AddUniversity(string universityName)
        {
            this.Browser.RefreshDomTree();
            this.AddButton.Click();
            Thread.Sleep(1000);

            var currentManager = Manager.Current;
            var nameBox = this.NameTextbox.GetRectangle();
            currentManager.Desktop.Mouse.Click(MouseClickType.LeftClick, nameBox);
            Thread.Sleep(800);
            currentManager.Desktop.KeyBoard.TypeText(universityName);
            this.UpdateButton.Click();
            Thread.Sleep(1000);
        }

        public void DeleteRow(string value, int searchColumn)
        {
            var rows = this.KendoTable.DataItems;
            HtmlAnchor deleteButton = null;

            foreach (var row in rows)
            {
                if (row[searchColumn].InnerText == value)
                {
                    deleteButton = row.Find.ByExpression<HtmlAnchor>("class=~k-grid-delete");
                    deleteButton.ScrollToVisible();
                    this.Browser.RefreshDomTree();

                    var currentManager = Manager.Current;
                    var deleteRectangle = deleteButton.GetRectangle();

                    AlertDialog alertDialog = new AlertDialog(this.Browser, DialogButton.OK);
                    currentManager.DialogMonitor.AddDialog(alertDialog);
                    currentManager.Desktop.Mouse.Click(MouseClickType.LeftClick, deleteRectangle);
                    alertDialog.WaitUntilHandled(5000);
                }
            }
        }

        public void ExportAsExcel()
        {
            Manager manager = Manager.Current;
            this.Browser.RefreshDomTree();

            manager.Desktop.Mouse.Click(MouseClickType.LeftClick, this.ExportAsExcelButton.GetRectangle());
            Thread.Sleep(4000);

            switch (this.Browser.BrowserType)
            {
                case BrowserType.Chrome:
                    {
                        manager.Desktop.KeyBoard.KeyPress(Keys.Enter);
                        break;
                    }

                default:
                    {
                        this.Browser.Desktop.KeyBoard.KeyDown(Keys.Alt);
                        this.Browser.Desktop.KeyBoard.KeyPress(Keys.S);
                        this.Browser.Desktop.KeyBoard.KeyUp(Keys.Alt);
                        break;
                    }
            }

            // Waiting for download to finish
            Thread.Sleep(5000);
        }

        public void EditRow(string value, string idOfEditField, string newValue, int searchColumn)
        {
            var rows = this.KendoTable.DataItems;
            HtmlAnchor editButton = null;

            foreach (var row in rows)
            {
                if (row[searchColumn].InnerText == value)
                {
                    editButton = row.Find.ByExpression<HtmlAnchor>("class=~k-grid-edit");
                    editButton.ScrollToVisible();
                    editButton.Click();
                    Thread.Sleep(1000);

                    var nameBox = this.NameTextbox.GetRectangle();
                    var currentManager = Manager.Current;

                    currentManager.Desktop.Mouse.Click(MouseClickType.LeftClick, nameBox);
                    currentManager.Desktop.KeyBoard.KeyDown(Keys.ControlKey);
                    currentManager.Desktop.KeyBoard.KeyPress(Keys.A);
                    currentManager.Desktop.KeyBoard.KeyUp(Keys.ControlKey);

                    currentManager.Desktop.KeyBoard.TypeText(newValue);
                    this.UpdateButton.Click();
                    Thread.Sleep(1000);
                    break;
                }
            }
        }

        public void SortByName()
        {
            this.NameHeader.Click();
        }

        public void SortById()
        {
            this.IdHeader.Click();
        }
    }
}