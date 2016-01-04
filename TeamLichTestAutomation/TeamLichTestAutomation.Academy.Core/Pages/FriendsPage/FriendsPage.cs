namespace TeamLichTestAutomation.Academy.Core.Pages.FriendsPage
{
    using System.Threading;
    using ArtOfTest.WebAii.Core;

    public partial class FriendsPage : BasePage
    {
        private readonly string url = "http://stage.telerikacademy.com/Friends";

        public FriendsPage(Browser browser)
            : base(browser)
        {
        }

        public string Url
        {
            get
            {
                return this.url;
            }
        }

        public void ClickFriendItem()
        {
            this.FriendItem.MouseClick();
        }

        public void ClickApproveFriendshipIcon()
        {
            this.Browser.WaitForElement(2000, "class=approveFriendship");
            this.ApproveFriendshipIcon.Click();
            this.Browser.Refresh();
        }

        public void ClickRemoveFriendshipIcon()
        {
            this.Browser.WaitForElement(2000, "class=removeFriendship");
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
                this.RemoveFriendshipConfirmYes.Click();
                this.Browser.RefreshDomTree();
            }
        }
    }
}