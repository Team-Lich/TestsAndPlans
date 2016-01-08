namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.LabelsPage
{
    using ArtOfTest.Common.UnitTesting;
    using TeamLichTestAutomation.TestFramework.Core;
    using Telerik.TestingFramework.Controls.KendoUI;

    public static class LabelsPageAsserter
    {
        public static void AssertLabelIsPresentInGrid(this LabelsPage labelsPage, KendoGrid grid, string labelName)
        {
            var isContained = grid.ContainsValueInColumn(labelName, 1);

            Assert.IsTrue(isContained);
        }

        public static void AssertLabelIsNotPresentInGrid(this LabelsPage labelsPage, KendoGrid grid, string labelName)
        {
            var isContained = grid.ContainsValueInColumn(labelName, 1);

            Assert.IsFalse(isContained);
        }
    }
}