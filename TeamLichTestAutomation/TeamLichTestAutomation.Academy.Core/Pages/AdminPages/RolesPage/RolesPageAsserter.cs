namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.RolesPage
{
    using System.Linq;
    using ArtOfTest.Common.UnitTesting;
    using TeamLichTestAutomation.TestFramework.Core;
    using Telerik.TestingFramework.Controls.KendoUI;

    public static class RolesPageAsserter
    {
        public static void AssertRoleIsPresentInGrid(this RolesPage rolePage, KendoGrid grid, string roleName)
        {
            var isContained = grid.ContainsValueInColumn(roleName, 2);

            Assert.IsTrue(isContained);
        }

        public static void AssertRoleIsNotPresentInGrid(this RolesPage rolePage, KendoGrid grid, string roleName)
        {
            var isContained = grid.ContainsValueInColumn(roleName, 2);

            Assert.IsFalse(isContained);
        }

        public static void AssertColumnIsSorted(this RolesPage rolesPage, string[] initialOrder, string[] sortedOrder, bool descending = true)
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