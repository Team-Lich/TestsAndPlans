namespace TeamLichTestAutomation.TestFramework.Core
{
    
    using System.Collections.Generic;
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

        public static string[] ValuesInColumn(this KendoGrid grid, int column)
        {
            var manager = Manager.Current;
            manager.ActiveBrowser.RefreshDomTree();

            var rowCollection = grid.DataItems;
            var result = new List<string>();

            foreach (var row in rowCollection)
            {
                result.Add(row[column].InnerText);
            }

            return result.ToArray();
        }
    }
}