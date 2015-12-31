namespace TeamLichTestAutomation.Academy.Core.Pages.FriendsPage
{
    using ArtOfTest.WebAii.Core;

    public partial class FriendsPage : BasePage
    {
        public FriendsPage(Browser browser)
            : base(browser)
        {
        }

        public void ClickApproveFriendshipIcon()
        {
            this.ApproveFriendshipIcon.Click();
        }

        public void ClickFriendItem()
        {
            this.FriendItem.MouseClick();
        }
    }
}
