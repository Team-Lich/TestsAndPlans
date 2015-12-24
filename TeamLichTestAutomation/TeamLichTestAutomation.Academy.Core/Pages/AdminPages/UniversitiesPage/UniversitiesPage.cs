namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.UniversitiesPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Threading;
    using System.Web;
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
            this.AddButton.Click();

            var currentManager = Manager.Current;

            currentManager.Desktop.Mouse.Click(MouseClickType.LeftDoubleClick, this.NameTextbox.GetRectangle());
            currentManager.Desktop.KeyBoard.TypeText(universityName, 50);

            currentManager.Desktop.Mouse.Click(MouseClickType.LeftClick, this.NameTextbox.GetRectangle().Right + 10, this.NameTextbox.GetRectangle().Top + 10);

            this.UpdateButton.Click();
        }

        public void DeleteRow(KendoGrid grid, string value, int searchColumn)
        {
            var rows = grid.DataItems;
            HtmlAnchor deleteButton = null;

            foreach (var row in rows)
            {
                if (row[searchColumn].InnerText == value)
                {
                    deleteButton = row.Find.ByExpression<HtmlAnchor>("class=~k-grid-delete");
                    deleteButton.ScrollToVisible();
                    this.Browser.RefreshDomTree();
                    var rec = deleteButton.GetRectangle();

                    this.Browser.Desktop.Mouse.Click(MouseClickType.LeftClick, rec);
                    Thread.Sleep(1000);


                    this.Browser.Desktop.KeyBoard.KeyPress(Keys.Return);
                    Manager.Current.Desktop.KeyBoard.KeyPress(Keys.Return);
                }
            }
        }
    }
}