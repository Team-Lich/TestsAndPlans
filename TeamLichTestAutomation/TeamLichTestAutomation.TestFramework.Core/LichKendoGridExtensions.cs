namespace TeamLichTestAutomation.TestFramework.Core
{
    using Telerik.TestingFramework.Controls.KendoUI;

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
    }
}