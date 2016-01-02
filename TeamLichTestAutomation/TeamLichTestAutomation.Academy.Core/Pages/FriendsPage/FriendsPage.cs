namespace TeamLichTestAutomation.Academy.Core.Pages.FriendsPage
{
    using ArtOfTest.WebAii.Core;

    public partial class FriendsPage : BasePage
    {
        public FriendsPage(Browser browser)
            : base(browser)
        {
        }

        public void ClickFriendItem()
        {
            this.FriendItem.MouseClick();
        }

        public void ClickApproveFriendshipIcon()
        {
            this.ApproveFriendshipIcon.Click();
        }

        public void RemoveAllFriends()
        {
            foreach (var friend in this.RemoveFriendshipIconCollection)
            {
                friend.Click();
                RemoveFriendshipConfirmYes.Click();
                this.Browser.RefreshDomTree();
            }
        }
    }
}
