namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.RolesPage
{
    using ArtOfTest.WebAii.Core;

    public partial class RolesPage : BasePage
    {
        public RolesPage(Browser browser)
           : base(browser)
        {
        }

        public void BackToAdmin()
        {
            this.BackToAdminButton.Click();
        }

        public void AddRole(string roleName)
            {
            this.Browser.RefreshDomTree();
            this.AddButton.Click();

            var currentManager = Manager.Current;

            var nameBox = this.NameTextbox.GetRectangle();

            currentManager.Desktop.Mouse.Click(MouseClickType.LeftDoubleClick, nameBox);
            currentManager.Desktop.KeyBoard.TypeText(roleName, 50);

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
                    // I cant handle the confirm dialog on Chrome and there is some odd offset on firefox
                    // preventing me to click on the name field. Firefox problem can be resolved, i am not sure
                    // if i will be able to handle the dialog afterwards
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

        public void EditRow(KendoGrid grid, string value, string idOfEditField, string newValue, int searchColumn)
            {
            var rows = grid.DataItems;
            HtmlAnchor editButton = null;

            foreach (var row in rows)
                {
                if (row[searchColumn].InnerText == value)
                    {
                    editButton = row.Find.ByExpression<HtmlAnchor>("class=~k-grid-edit");
                    editButton.ScrollToVisible();
                    this.Browser.RefreshDomTree();
                    var rec = editButton.GetRectangle();

                    this.Browser.Desktop.Mouse.Click(MouseClickType.LeftClick, rec);
                    Thread.Sleep(1000);

                    this.Browser.RefreshDomTree();
                    var fieldToEdit = this.Browser.Find.ById(idOfEditField);

                    var rectangle = fieldToEdit.GetRectangle();

                    var currentManager = Manager.Current;

                    //// currentManager.Desktop.Mouse.Move(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Top);
                    //// currentManager.Desktop.Mouse.Move(rectangle.Right, rectangle.Top, rectangle.Left, rectangle.Bottom);

                    currentManager.Desktop.Mouse.Click(MouseClickType.LeftClick, rectangle);
                    currentManager.Desktop.KeyBoard.KeyDown(Keys.ControlKey);
                    currentManager.Desktop.KeyBoard.KeyPress(Keys.A);
                    currentManager.Desktop.KeyBoard.KeyUp(Keys.ControlKey);

                    currentManager.Desktop.KeyBoard.TypeText(newValue, 50);
                    //// currentManager.Desktop.KeyBoard.KeyPress(Keys.Return);

                    Thread.Sleep(1000);
                    this.Browser.RefreshDomTree();
                    var updateButtonPosition = this.UpdateButton.GetRectangle();
                    currentManager.Desktop.Mouse.Move(rectangle, updateButtonPosition);

                    currentManager.Desktop.Mouse.Click(MouseClickType.LeftClick, updateButtonPosition);
                    //// this.UpdateButton.Click();
                    }
                }
            }

        public void ExportAsExcel()
            {
                this.Browser.RefreshDomTree();
                this.ExprotAsExcelButton.Click();
            }

        public void SortByName(KendoGrid grid)
            {
            this.NameHeader.Click();
            }

        public void SortById(KendoGrid grid)
            {
            this.IdHeader.Click();
            }
    }
}