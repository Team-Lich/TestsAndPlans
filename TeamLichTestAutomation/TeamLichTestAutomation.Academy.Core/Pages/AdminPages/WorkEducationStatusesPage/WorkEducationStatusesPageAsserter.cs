namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.WorkEducationStatusesPage
{
    using System.Linq;
    using ArtOfTest.Common.UnitTesting;
    using TeamLichTestAutomation.TestFramework.Core;
    using Telerik.TestingFramework.Controls.KendoUI;

    public static class WorkEducationStatusesPageAsserter
    {
        public static void AssertWorkEducationStatusIsPresentInGrid(this WorkEducationStatusesPage workEducationStatusPage, KendoGrid grid, string statusName)
        {
            var isContained = grid.ContainsValueInColumn(statusName, 1);

            Assert.IsTrue(isContained);
        }

        public static void AssertWorkEducationStatusIsNotPresentInGrid(this WorkEducationStatusesPage workEducationStatusPage, KendoGrid grid, string statusName)
        {
            var isContained = grid.ContainsValueInColumn(statusName, 1);

            Assert.IsFalse(isContained);
        }        
    }
}