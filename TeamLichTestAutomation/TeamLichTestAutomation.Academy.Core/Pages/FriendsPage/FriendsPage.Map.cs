namespace TeamLichTestAutomation.Academy.Core.Pages.FriendsPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using Models;
    using System.Collections.Generic;

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

        public HtmlDiv FriendItem
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlDiv>("data-username=" + TelerikUser.Related2.UserName);
            }
        }

        public HtmlDiv ApproveFriendshipIcon
        {
            get
            {
                return this.Browser.Find.ByAttributes<HtmlDiv>("class=approveFriendship");
            }
        }

        public ICollection<HtmlDiv> RemoveFriendshipIconCollection
        {
            get
            {
                return this.Browser.Find.AllByAttributes<HtmlDiv>("class=removeFriendship");
            }
        }

        public HtmlAnchor RemoveFriendshipConfirmYes
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlAnchor>("class=~yesRemove");
            }
        }

        public HtmlAnchor RemoveFriendshipConfirmNo
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlAnchor>("class=~noHide");
            }
        }

        public HtmlDiv NoFriendsMessage
        {
            get
            {
                return this.Browser.Find.ByAttributes<HtmlDiv>("class=importantMessageInfo");
            }
        }
    }
}
