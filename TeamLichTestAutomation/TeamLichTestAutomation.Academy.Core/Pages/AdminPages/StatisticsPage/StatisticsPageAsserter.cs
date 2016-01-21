namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.StatisticsPage
{
    using ArtOfTest.Common.UnitTesting;
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public static class StatisticsPageAsserter
    {
        public static void AssertChartExists(this StatisticsPage statisticsPage, HtmlDiv chart)
        {
            Assert.IsTrue(chart.IsVisible());
        }
    }
}