namespace TeamLichTestAutomation.Academy.Core.Pages.UserProfilePage
{
    using ArtOfTest.WebAii.Core;

    public partial class UserProfilePage : BasePage
    {
        public UserProfilePage(Browser browser)
            : base(browser)
        {
        }

        public void ClickSendMessageButtonActive()
        {
            this.SendMessageButtonActive.Click();
            this.Browser.WaitUntilReady();
        }

        public void ClickSendMessageButtonInactive()
        {
            this.SendMessageButtonInactive.Click();
        }

        public void ClickAddFriendButton()
        {
            this.Browser.WaitForElement(2000, "id=AddFriendButton");
            this.AddFriendButton.Click();
            this.Browser.RefreshDomTree();
        }

        public void ClickRemoveFriendButton()
        {
            this.Browser.WaitForElement(2000, "id=UnfriendButton");
            this.RemoveFriendButton.Click();
            this.Browser.RefreshDomTree();
        }
    }
}