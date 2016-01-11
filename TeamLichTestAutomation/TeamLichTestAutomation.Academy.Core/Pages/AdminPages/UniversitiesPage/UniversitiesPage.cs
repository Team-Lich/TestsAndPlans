﻿namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.UniversitiesPage
{
    using System;
    using System.Threading;
    using System.Windows.Forms;
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.Win32.Dialogs;

    using Telerik.TestingFramework.Controls.KendoUI;

    public partial class UniversitiesPage : BasePage
    {
        public UniversitiesPage(Browser browser)
            : base(browser)
        {
        }

        public void BackToAdmin()
        {
            this.BackToAdminButton.Click();
        }

        public void AddUniversity(string universityName)
        {
            this.Browser.RefreshDomTree();
            this.AddButton.Click();

            var currentManager = Manager.Current;

            var nameBox = this.NameTextbox.GetRectangle();

            currentManager.Desktop.Mouse.Click(MouseClickType.LeftDoubleClick, nameBox);
            currentManager.Desktop.KeyBoard.TypeText(universityName, 50);

            currentManager.Desktop.Mouse.Click(MouseClickType.LeftClick, nameBox.Right + 10, nameBox.Top + 10);

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
                    this.Browser.RefreshDomTree();
                    var rec = editButton.GetRectangle();

                    this.Browser.Desktop.Mouse.Click(MouseClickType.LeftClick, rec);
                    Thread.Sleep(1000);

                    this.Browser.RefreshDomTree();
                    var fieldToEdit = this.Browser.Find.ById(idOfEditField);

                    var rectangle = fieldToEdit.GetRectangle();

                    var currentManager = Manager.Current;

                    currentManager.Desktop.Mouse.Click(MouseClickType.LeftClick, rectangle);
                    currentManager.Desktop.KeyBoard.KeyDown(Keys.ControlKey);
                    currentManager.Desktop.KeyBoard.KeyPress(Keys.A);
                    currentManager.Desktop.KeyBoard.KeyUp(Keys.ControlKey);

                    currentManager.Desktop.KeyBoard.TypeText(newValue, 50);

                    Thread.Sleep(1000);
                    this.Browser.RefreshDomTree();
                    var updateButtonPosition = this.UpdateButton.GetRectangle();
                    currentManager.Desktop.Mouse.Move(rectangle, updateButtonPosition);

                    currentManager.Desktop.Mouse.Click(MouseClickType.LeftClick, updateButtonPosition);
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