namespace TeamLichTestAutomation.TestFramework.Core
{
    
    using System.Threading;
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;
    using Telerik.TestingFramework.Controls.KendoUI;
    using ArtOfTest.WebAii.TestTemplates;
    using System.Web;
    using System.Drawing;


    public static class LichKendoGridExtensions
    {
        public static bool ContainsValueInColumn(this KendoGrid grid, string value, int searchColumn)
        {
            var rows = grid.DataItems;

            foreach (var row in rows)
            {
                if (row[searchColumn].InnerText == value)
                {
                    return true;
                }
            }

            return false;
        }

        public static void DeleteRowWithValueInColumn(this KendoGrid grid, string value, int searchColumn, Browser browser)
        {
            var rows = grid.DataItems;
            HtmlAnchor deleteButton = null;   
         
            foreach (var row in rows)
            {
                if (row[searchColumn].InnerText == value)
                {
                    deleteButton = row.Find.ByExpression<HtmlAnchor>("class=~k-grid-delete");
                    deleteButton.ScrollToVisible();
                    browser.RefreshDomTree();
                    var rec = deleteButton.GetRectangle();

                    browser.Desktop.Mouse.Click(MouseClickType.LeftClick, rec);
                    Thread.Sleep(1000);

                    
                    browser.Desktop.KeyBoard.KeyPress(System.Windows.Forms.Keys.Return);
                    //Manager.Current.Desktop.KeyBoard.KeyPress(System.Windows.Forms.Keys.Return);
                }
            }
        }
    }
}