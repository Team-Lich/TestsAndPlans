namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.AdminDashboardPage
{
    using ArtOfTest.WebAii.Core;

    public partial class AdminDashboardPage :BasePage
    {
        public AdminDashboardPage(Browser browser) : base(browser)
        {
        }

        public void ClickUniversitiesButton()
        {
            this.UniversitiesButton.Click();
        }        
    }
}