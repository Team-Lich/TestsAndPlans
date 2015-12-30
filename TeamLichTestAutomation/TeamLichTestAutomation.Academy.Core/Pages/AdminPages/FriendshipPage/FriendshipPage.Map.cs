namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.FriendshipPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public partial class FriendshipPage
    {
        public HtmlAnchor AddFriendshipButton 
        {
            get
            {
                return this.Browser.Find.ByContent<HtmlAnchor>("Обратно към администрацията");
            }
        }
    }
}
