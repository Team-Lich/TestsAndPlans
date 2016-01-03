namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.AdminDashboardPage
{
    using ArtOfTest.Common.UnitTesting;
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public static class AdminDashboardPageAsserter
    {
        public static void AssertCurrentlyOnThePage(this AdminDashboardPage page)
        {
            var mainContainer = page.Browser.Find.ById<HtmlDiv>("MainContainer");
            var heading = mainContainer.Find.ByExpression("tagname=h1").InnerText;

            Assert.AreEqual("Администрация", heading);
        }
    }
}