namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.UniversitiesPage
{
    using System.Linq;
    using System.Threading;
    using ArtOfTest.Common.UnitTesting;
    using Telerik.TestingFramework.Controls.KendoUI;

    public static class UniversitiesPageAsserter
    {
        public static void AssertUniversityIsPresentInTable(this UniversitiesPage uniPage, string universityName)
        {
            var element = uniPage.KendoTable;
            Thread.Sleep(2000);

            var isContained = element.InnerText.Contains(universityName);

            Assert.IsTrue(isContained);

            //KendoGrid kendoGrid = new KendoGrid(element);
            //kendoGrid.FindItems(k => k.InnerText == universityName);

            //foreach (var item in kendoGrid.DataItems)
            //{
            //    item
            //}
        }
    }
}