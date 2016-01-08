namespace TeamLichTestAutomation.Academy.Core.Pages.FriendsPage
{
    using System.Collections.Generic;

    using ArtOfTest.WebAii.Controls.HtmlControls;
    using TeamLichTestAutomation.Academy.Core.Models;

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

        public HtmlDiv RemoveFriendshipIcon
        {
            get
            {
                return this.Browser.Find.ByAttributes<HtmlDiv>("class=removeFriendship");
            }
        }

        public ICollection<HtmlDiv> RemoveFriendshipIconCollection
        {
            get
            {
                return this.Browser.Find.AllByAttributes<HtmlDiv>("class=removeFriendship");
            }
        }

        public HtmlDiv RemoveFriendshipConfirm
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlDiv>("class=~sureOption");
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

        public HtmlContainerControl FriendsMainContent
        {
            get
            {
                return this.Browser.Find.ById<HtmlContainerControl>("MainContent");
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