namespace TeamLichTestAutomation.TestFramework.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;

    using Telerik.TestingFramework.Controls.KendoUI;

    public static class KendoGridExtensions
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

        public static bool IsColumnSortDescending(this KendoGrid grid, int column)
        {
            string[] findExpressions =
            {
                "data-index=" + column,
                "data-role=columnsorter"
            };

            var targetColumnHeader = grid.Find.ByExpression<HtmlTableCell>(findExpressions);
            var sortAttribute = targetColumnHeader.Attributes.FirstOrDefault(a => a.Name == "aria-sort");
            bool isDescending = sortAttribute.Value == "descending";

            return isDescending;
        }
    }
}