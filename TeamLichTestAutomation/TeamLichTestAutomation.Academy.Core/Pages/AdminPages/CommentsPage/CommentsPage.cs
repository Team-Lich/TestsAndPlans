namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.UniversitiesPage
{
    using ArtOfTest.WebAii.Core;

    public partial class CommentsPage : BasePage
    {
        public CommentsPage(Browser browser)
           : base(browser)
        {
        }

        public void BackToAdmin()
        {
            this.BackToAdminButton.Click();
        }
    }
}