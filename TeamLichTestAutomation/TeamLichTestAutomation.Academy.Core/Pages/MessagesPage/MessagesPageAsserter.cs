namespace TeamLichTestAutomation.Academy.Core.Pages.MessagesPage
{
    using ArtOfTest.Common.UnitTesting;

    public static class MessagesPageAsserter
    {
        public static void AssertMessagesHeadingIsVisible(this MessagesPage messagesPage)
        {
            Assert.IsTrue(messagesPage.MessagesHeading.IsVisible());
        }

        public static void AssertMessagePanelTitleIsVisible(this MessagesPage messagesPage)
        {
            Assert.IsTrue(messagesPage.MessagePanelTitle.IsVisible());
        }

        public static void AssertInfoMessageIsVisible(this MessagesPage messagesPage)
        {
            Assert.IsTrue(messagesPage.InfoMessage.IsVisible());
        }

        public static void AssertMessageToSendTextAreaIsVisible(this MessagesPage messagesPage)
        {
            Assert.IsTrue(messagesPage.MessageToSendTextArea.IsVisible());
        }

        public static void AssertSubmitByEnterCheckboxIsNotVisible(this MessagesPage messagesPage)
        {
            Assert.IsFalse(messagesPage.SubmitByEnterCheckbox.IsVisible());
        }

        public static void AssertSendButtonIsVisible(this MessagesPage messagesPage)
        {
            Assert.IsTrue(messagesPage.SendButton.IsVisible());
        }

        public static void AssertFriendsPanelTitleIsVisible(this MessagesPage messagesPage)
        {
            Assert.IsTrue(messagesPage.FriendsPanelTitle.IsVisible());
        }

        public static void AssertFriendSearchInputIsVisible(this MessagesPage messagesPage)
        {
            Assert.IsTrue(messagesPage.FriendSearchInput.IsVisible());
        }

        public static void AssertFriendItemIsVisible(this MessagesPage messagesPage)
        {
            Assert.IsTrue(messagesPage.FriendItem().IsVisible());
        }
    }
}
