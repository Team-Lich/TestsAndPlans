namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.UniversitiesPage
{
    using System.Linq;
    using ArtOfTest.Common.UnitTesting;
    using TeamLichTestAutomation.TestFramework.Core;
    using Telerik.TestingFramework.Controls.KendoUI;

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

        public static void AssertIntegerColumnIsSorted(this UniversitiesPage uniPage, string[] sortedOrder, bool descending = true)
        {
            string[] computedSort;

            if (descending)
            {
                computedSort = sortedOrder.OrderBy(s => int.Parse(s)).ToArray();
            }
            else
            {
                computedSort = sortedOrder.OrderByDescending(s => int.Parse(s)).ToArray();
            }

            for (int i = 0; i < computedSort.Length; i++)
            {
                string expected = computedSort[i];
                string actual = sortedOrder[i];
                Assert.AreEqual(expected, actual);
            }
        }

        public static void AssertStringColumnIsSorted(this UniversitiesPage uniPage, string[] sortedOrder, bool descending = true)
        {
            string[] computedSort;

            if (descending)
            {
                computedSort = sortedOrder.OrderBy(s => s).ToArray();
            }
            else
            {
                computedSort = sortedOrder.OrderByDescending(s => s).ToArray();
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