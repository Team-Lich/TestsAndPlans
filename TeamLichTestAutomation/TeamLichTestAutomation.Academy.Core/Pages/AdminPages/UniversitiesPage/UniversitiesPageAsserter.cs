namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.UniversitiesPage
{
    using System.Linq;
    using System.Threading;
    using ArtOfTest.Common.UnitTesting;
    using Telerik.TestingFramework.Controls.KendoUI;
    using TeamLichTestAutomation.TestFramework.Core;

    public static class UniversitiesPageAsserter
    {
        public static void AssertUniversityIsPresentInGrid(this UniversitiesPage uniPage, KendoGrid grid, string universityName)
        {
            var isContained = grid.ContainsValueInColumn(universityName, 1);

            Assert.IsTrue(isContained);
        }

        public static void AssertUniversityIsNotPresentInGrid(this UniversitiesPage uniPage, KendoGrid grid, string universityName)
        {
            var isContained = grid.ContainsValueInColumn(universityName, 1);

            Assert.IsFalse(isContained);
        }

        public static void AssertColumnIsSorted(this UniversitiesPage uniPage, string[] initialOrder, string[] sortedOrder, bool descending = true)
        {
            string[] computedSort;

            if (descending)
            {
                computedSort = initialOrder.OrderBy(s => s).ToArray();
            }
            else
            {
                computedSort = initialOrder.OrderByDescending(s => s).ToArray();
            }

            for (int i = 0; i < computedSort.Length; i++)
            {
                string expected = computedSort[i];
                string actual = sortedOrder[i];
                Assert.AreEqual(expected, actual);
            }
        }
    }
}