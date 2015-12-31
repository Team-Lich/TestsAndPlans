namespace TeamLichTestAutomation.Academy.Core.Pages.FriendsPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using Models;

    public partial class FriendsPage
    {
        public HtmlDiv FriendsListPanelHeading
        {
            get
            {
                return this.Browser.Find.ByAttributes<HtmlDiv>("class=panel-heading");
            }
        }

        public HtmlDiv FriendsListPanelBody
        {
            get
            {
                return this.Browser.Find.ById<HtmlDiv>("acceptedFriendRequests");
            }
        }

        public HtmlDiv ApproveFriendshipIcon
        {
            get
            {
                return this.Browser.Find.ByAttributes<HtmlDiv>("class=approveFriendship");
            }
        }

        public HtmlDiv FriendItem
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlDiv>("data-username=" + TelerikUser.Related2.UserName);
            }
        }
    }
}
