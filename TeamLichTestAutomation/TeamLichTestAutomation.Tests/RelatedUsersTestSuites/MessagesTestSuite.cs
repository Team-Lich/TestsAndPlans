namespace TeamLichTestAutomation.Tests.RelatedUsersTestSuites
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.LoginPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MessagesPage;
    using TeamLichTestAutomation.Academy.Core.Pages.UserProfilePage;

    using TeamLichTestAutomation.Utilities.Attributes;

    [TestClass]
    public class MessagesTestSuite : BaseTest
    {
        private MainPage mainPage;
        private LoginPage loginPage;
        private UserProfilePage userPage;
        private MessagesPage messagesPage;

        [TestInitialize]
        public void ThisTestInitialize()
        {
            this.mainPage = new MainPage(this.Browser);
            this.loginPage = new LoginPage(this.Browser);
            this.userPage = new UserProfilePage(this.Browser);
            this.messagesPage = new MessagesPage(this.Browser);

            this.mainPage.NavigateTo(this.loginPage.Url);
        }

        [TestMethod]
        [TestCategory("Messages")]
        [Priority(3)]
        [Owner("Yane")]
        public void SendMessageButtonShouldOpenMessagesPage()
        {
            RelatedUsersUtilities.AddFriend(this.Browser);
            this.mainPage.NavigateTo(TelerikUser.Related2.Url);

            this.userPage.ClickSendMessageButtonActive();

            this.userPage.AssertMessagesPageIsActive();
        }

        [TestMethod]
        [TestCategory("Messages")]
        [Priority(3)]
        [Owner("Yane")]
        public void SendMessageButtonShouldBeInactive()
        {
            RelatedUsersUtilities.RemoveFriend(this.Browser);
            this.mainPage.NavigateTo(TelerikUser.Related2.Url);

            this.userPage.AssertMessageButtonButtonIsInactive();

            this.userPage.ClickSendMessageButtonInactive();
            this.userPage.AssertProperUserProfilePageIsActive(TelerikUser.Related2.UserName);
        }

        [TestMethod]
        [TestCategory("Messages")]
        [TestId(118)]
        [Priority(3)]
        [Owner("Yane")]
        public void MessagesPageElementsShouldBeDisplayedCorrectly()
        {
            RelatedUsersUtilities.AddFriend(this.Browser);
            this.mainPage.NavigateTo(this.messagesPage.Url);

            this.messagesPage.AssertMessagesHeadingIsVisible();
            this.messagesPage.AssertMessagePanelTitleIsVisible();
            this.messagesPage.AssertInfoMessageIsVisible();
            this.messagesPage.AssertMessageToSendTextAreaIsVisible();
            this.messagesPage.AssertSubmitByEnterCheckboxIsNotVisible();
            this.messagesPage.AssertSendButtonIsVisible();
            this.messagesPage.AssertFriendsPanelTitleIsVisible();
            this.messagesPage.AssertFriendItemIsVisible();
        }

        [TestMethod]
        [TestCategory("Messages")]
        [TestId(119)]
        [Priority(3)]
        [Owner("Yane")]
        public void FriendItemsShouldBeDisplayedCorrectly()
        {
            RelatedUsersUtilities.AddFriend(this.Browser);
            this.mainPage.NavigateTo(this.messagesPage.Url);

            this.messagesPage.AssertFriendAvatarIsVisible();
            this.messagesPage.AssertFriendNamesAreVisible();
            this.messagesPage.AssertFriendLastMessageBeginningIsVisible();
        }

        [TestMethod]
        [TestCategory("Messages")]
        [TestId(120)]
        [Priority(3)]
        [Owner("Yane")]
        public void SearchFieldShouldBeVisible()
        {
            RelatedUsersUtilities.AddFriend(this.Browser);
            this.mainPage.NavigateTo(this.messagesPage.Url);

            this.messagesPage.AssertSearchFieldIsVisible();
        }

        [TestMethod]
        [TestCategory("Messages")]
        [TestId(125)]
        [Priority(3)]
        [Owner("Yane")]
        public void MessageContainerShouldContainsProperData()
        {
            RelatedUsersUtilities.AddFriend(this.Browser);
            this.mainPage.NavigateTo(this.messagesPage.Url);
            this.messagesPage.ClickFriendItem();

            this.messagesPage.Browser.ScrollBy(0, 400);
            this.messagesPage.UncheckSubmitByEnterCheckbox();
            this.messagesPage.EnterValidMessageUppercaseLatinAlphabet();
            this.messagesPage.ClickSendButton();
            this.messagesPage.HoverLastMessageWrapper();

            this.messagesPage.AssertLastMessageContainerContainsProperData(MessagesPageMessages.UppercaseLatinAlphabet);
        }

        [TestMethod]
        [TestCategory("Messages")]
        [TestId(126)]
        [Priority(3)]
        [Owner("Yane")]
        public void SendValidMessage()
        {
            RelatedUsersUtilities.AddFriend(this.Browser);
            this.mainPage.NavigateTo(this.messagesPage.Url);
            this.messagesPage.ClickFriendItem();
            this.messagesPage.Browser.ScrollBy(0, 400);
            this.messagesPage.UncheckSubmitByEnterCheckbox();

            this.messagesPage.EnterValidMessageLowercaseLatinAlphabet();
            this.messagesPage.ClickSendButton();
            this.messagesPage.AssertMessageIsSent(MessagesPageMessages.LowercaseLatinAlphabet);

            this.messagesPage.EnterValidMessageUppercaseLatinAlphabet();
            this.messagesPage.ClickSendButton();
            this.messagesPage.AssertMessageIsSent(MessagesPageMessages.UppercaseLatinAlphabet);

            this.messagesPage.EnterValidMessageLowercaseCyrilicAlphabet();
            this.messagesPage.ClickSendButton();
            this.messagesPage.AssertMessageIsSent(MessagesPageMessages.LowercaseCyrilicAlphabet);

            this.messagesPage.EnterValidMessageUppercaseCyrilicAlphabet();
            this.messagesPage.ClickSendButton();
            this.messagesPage.AssertMessageIsSent(MessagesPageMessages.UppercaseCyrilicAlphabet);

            this.messagesPage.EnterValidMessageDigits();
            this.messagesPage.ClickSendButton();
            this.messagesPage.AssertMessageIsSent(MessagesPageMessages.Digits);

            this.messagesPage.EnterValidMessageSpecialChars();
            this.messagesPage.ClickSendButton();
            this.messagesPage.AssertMessageIsSent(MessagesPageMessages.SpecialChars);

            this.messagesPage.EnterValidMessageSingleLatinChar();
            this.messagesPage.ClickSendButton();
            this.messagesPage.AssertMessageIsSent(MessagesPageMessages.LatinChar);

            this.messagesPage.EnterValidMessageSingleCyrilicChar();
            this.messagesPage.ClickSendButton();
            this.messagesPage.AssertMessageIsSent(MessagesPageMessages.CyrilicChar);

            this.messagesPage.EnterValidMessageSingleDigit();
            this.messagesPage.ClickSendButton();
            this.messagesPage.AssertMessageIsSent(MessagesPageMessages.Digit);

            this.messagesPage.EnterValidMessageSingleSpecialChar();
            this.messagesPage.ClickSendButton();
            this.messagesPage.AssertMessageIsSent(MessagesPageMessages.SpecialChar);
        }

        [TestMethod]
        [TestCategory("Messages")]
        [TestId(127)]
        [Priority(3)]
        [Owner("Yane")]
        public void SendValidMessageWhenCheckboxIsUncheckedAndEnterIsPressed()
        {
            RelatedUsersUtilities.AddFriend(this.Browser);
            this.mainPage.NavigateTo(this.messagesPage.Url);
            this.messagesPage.ClickFriendItem();

            this.messagesPage.Browser.ScrollBy(0, 400);
            this.messagesPage.UncheckSubmitByEnterCheckbox();
            this.messagesPage.EnterValidMessageLowercaseLatinAlphabet();
            this.messagesPage.PressEnter();
            this.messagesPage.EnterValidMessageLowercaseCyrilicAlphabet();
            this.messagesPage.ClickSendButton();

            this.messagesPage.AssertMessageIsSentAndLineBreakIsDisplayedCorrectly(
                MessagesPageMessages.LowercaseLatinAlphabet,
                MessagesPageMessages.LowercaseCyrilicAlphabet);
        }

        [TestMethod]
        [TestCategory("Messages")]
        [TestId(128)]
        [Priority(3)]
        [Owner("Yane")]
        public void SendValidMessageWhenCheckboxIsCheckedAndEnterIsPressed()
        {
            RelatedUsersUtilities.AddFriend(this.Browser);
            this.mainPage.NavigateTo(this.messagesPage.Url);
            this.messagesPage.ClickFriendItem();

            this.messagesPage.CheckSubmitByEnterCheckbox();
            this.messagesPage.EnterValidMessageLowercaseLatinAlphabet();
            this.messagesPage.PressEnter();

            this.messagesPage.AssertMessageIsSent(MessagesPageMessages.LowercaseLatinAlphabet);
        }

        [TestMethod]
        [TestCategory("Messages")]
        [TestId(129)]
        [Priority(3)]
        [Owner("Yane")]
        public void TryToSendEmptyMessage()
        {
            RelatedUsersUtilities.AddFriend(this.Browser);
            this.mainPage.NavigateTo(this.messagesPage.Url);
            this.messagesPage.ClickFriendItem();
            this.messagesPage.UncheckSubmitByEnterCheckbox();
            this.messagesPage.ClickSendButton();

            this.messagesPage.AssertMessageIsNotSent(MessagesPageMessages.SpacebarChar);

            this.messagesPage.EnterInvalidMessageSpacebarChar();
            this.messagesPage.ClickSendButton();

            this.messagesPage.AssertMessageIsNotSent(MessagesPageMessages.SpacebarChar);
        }
    }
}