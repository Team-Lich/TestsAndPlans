namespace TeamLichTestAutomation.Academy.Core.Pages.MessagesPage
{
    using System.Threading;
    using ArtOfTest.WebAii.Core;

    public partial class MessagesPage : BasePage
    {
        private readonly string url = "http://stage.telerikacademy.com/Messages";

        public MessagesPage(Browser browser)
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

        public void EnterValidMessageLowercaseLatinAlphabet()
        {
            this.MessageToSendTextArea.Text = MessagesPageMessages.LowercaseLatinAlphabet;
        }

        public void EnterValidMessageUppercaseLatinAlphabet()
        {
            this.MessageToSendTextArea.Text = MessagesPageMessages.UppercaseLatinAlphabet;
        }

        public void EnterValidMessageLowercaseCyrilicAlphabet()
        {
            this.MessageToSendTextArea.Text = MessagesPageMessages.LowercaseCyrilicAlphabet;
        }

        public void EnterValidMessageUppercaseCyrilicAlphabet()
        {
            this.MessageToSendTextArea.Text = MessagesPageMessages.UppercaseCyrilicAlphabet;
        }

        public void EnterValidMessageDigits()
        {
            this.MessageToSendTextArea.Text = MessagesPageMessages.Digits;
        }

        public void EnterValidMessageSpecialChars()
        {
            this.MessageToSendTextArea.Text = MessagesPageMessages.SpecialChars;
        }

        public void EnterValidMessageSingleLatinChar()
        {
            this.MessageToSendTextArea.Text = MessagesPageMessages.LatinChar;
        }

        public void EnterValidMessageSingleCyrilicChar()
        {
            this.MessageToSendTextArea.Text = MessagesPageMessages.CyrilicChar;
        }

        public void EnterValidMessageSingleDigit()
        {
            this.MessageToSendTextArea.Text = MessagesPageMessages.Digit;
        }

        public void EnterValidMessageSingleSpecialChar()
        {
            this.MessageToSendTextArea.Text = MessagesPageMessages.SpecialChar;
        }

        public void EnterInvalidMessageSpacebarChar()
        {
            this.MessageToSendTextArea.Text = MessagesPageMessages.SpacebarChar;
        }

        public void ClickFriendItem()
        {
            this.FriendItem.MouseClick();
        }

        public void ClickSendButton()
        {
            this.SendButton.Click();
            this.Browser.RefreshDomTree();
            Thread.Sleep(1000);
        }
    }
}