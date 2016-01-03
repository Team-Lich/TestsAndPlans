namespace TeamLichTestAutomation.Academy.Core.Pages.FriendsPage
{
    using ArtOfTest.WebAii.Core;
    using System.Threading;

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

        public void ClickRemoveFriendshipIcon()
        {
            this.RemoveFriendshipIcon.Click();
        }

        public void ClickRemoveFriendshipConfirmYes()
        {
            this.RemoveFriendshipConfirmYes.Click();
            Thread.Sleep(1000);
            this.Browser.WaitForElement(2000, "id=MainContent");
        }

        public void ClickRemoveFriendshipConfirmNo()
        {
            this.RemoveFriendshipConfirmNo.Click();
            Thread.Sleep(1000);
            this.Browser.WaitForElement(2000, "id=MainContent");
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