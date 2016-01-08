namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.UniversitiesPage
{
    using ArtOfTest.WebAii.Core;

    public partial class AvatarsPage : BasePage
    {
        public AvatarsPage(Browser browser)
           : base(browser)
        {
        }

        public void BackToAdmin()
        {
            this.BackToAdminButton.Click();
        }
    }
}