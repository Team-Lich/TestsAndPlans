namespace TeamLichTestAutomation.Academy.Core.Pages.UserPage
{
    using ArtOfTest.WebAii.Core;

    public partial class UserPage : BasePage
    {
        public UserPage(Browser browser)
            : base(browser)
        {
        }

        public void ClickSendMessageButtonActive()
        {
            this.SendMessageButtonActive.Click();
        }

        public void ClickSendMessageButtonInactive()
        {
            this.SendMessageButtonInactive.Click();
        }

        public void ClickAddFriendButton()
        {
            this.AddFriendButton.Click();
        }

        public void ClickRemoveFriendButton()
        {
            this.RemoveFriendButton.Click();
        }
    }
}