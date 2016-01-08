namespace TeamLichTestAutomation.Academy.Core.Pages.UserProfilePage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public partial class UserProfilePage
    {
        public HtmlSpan SendMessageButtonInactive
        {
            get
            {
                return this.Browser.Find.ByAttributes<HtmlSpan>("class=~btn-default");
            }
        }

        public HtmlAnchor SendMessageButtonActive
        {
            get
            {
                return this.Browser.Find.ByAttributes<HtmlAnchor>("class=~btn-success");
            }
        }

        public HtmlAnchor AddFriendButton
        {
            get
            {
                return this.Browser.Find.ById<HtmlAnchor>("AddFriendButton");
            }
        }

        public HtmlAnchor RemoveFriendButton
        {
            get
            {
                return this.Browser.Find.ById<HtmlAnchor>("UnfriendButton");
            }
        }
    }
}