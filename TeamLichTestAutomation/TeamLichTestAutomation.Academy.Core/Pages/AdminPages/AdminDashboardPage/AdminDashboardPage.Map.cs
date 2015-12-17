namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.AdminDashboardPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public partial class AdminDashboardPage
    {
        private HtmlAnchor UniversitiesButton
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlAnchor>("href=/Administration_Users/Universities");
            }
        }

        private HtmlAnchor RolesButton
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlAnchor>("href=/Administration_Users/Roles");
            }
        }
    }
}