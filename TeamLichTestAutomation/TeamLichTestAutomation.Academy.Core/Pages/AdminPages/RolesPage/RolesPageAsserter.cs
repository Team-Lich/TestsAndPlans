namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.RolesPage
{
    public static class RolesPageAsserter
    {
<<<<<<< HEAD
        public static void AssertRoleIsPresentInGrid(this RolesPage rolePage, KendoGrid grid, string roleName)
        {
            var isContained = grid.ContainsValueInColumn(roleName, 1);

            Assert.IsTrue(isContained);
        }

        public static void AssertRoleIsNotPresentInGrid(this RolesPage rolePage, KendoGrid grid, string roleName)
        {
            var isContained = grid.ContainsValueInColumn(roleName, 1);

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
=======
>>>>>>> origin/master
    }
}