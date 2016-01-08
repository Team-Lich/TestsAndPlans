namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.UniversitiesPage
{
    using ArtOfTest.WebAii.Core;

    public partial class RolesPage : BasePage
    {
        public RolesPage(Browser browser)
           : base(browser)
        {
        }

        public void BackToAdmin()
        {
            this.BackToAdminButton.Click();
        }
    }
}