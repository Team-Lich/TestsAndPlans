namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.StatisticsPage
{
    using System.Linq;
    using ArtOfTest.Common.UnitTesting;
    using TeamLichTestAutomation.TestFramework.Core;
    using Telerik.TestingFramework.Controls.KendoUI;
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public static class StatisticsPageAsserter
    {
        public static void AssertChartExists(this StatisticsPage statisticsPage, HtmlDiv chart)
        {
            Assert.IsTrue(chart.IsVisible());
        }
    }
}