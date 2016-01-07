namespace TeamLichTestAutomation.Academy.Core.Pages.MessagesPage
{
    using ArtOfTest.Common.UnitTesting;
    using TeamLichTestAutomation.Academy.Core.Pages.UserPage;

    public static class MessagesPageAsserter
    {
        public static void AssertMessagesPageIsActive(this UserPage userPage)
        {
            Assert.AreEqual(userPage.Browser.PageTitle, "Съобщения - Телерик Академия - Студентска система");
        }

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
            Assert.IsFalse(messagesPage.SubmitByEnterCheckboxWrapper.IsVisible());
        }

        public static void AssertSendButtonIsVisible(this MessagesPage messagesPage)
        {
            Assert.IsTrue(messagesPage.SendButton.IsVisible());
        }

        public static void AssertFriendsPanelTitleIsVisible(this MessagesPage messagesPage)
        {
            Assert.IsTrue(messagesPage.FriendsPanelTitle.IsVisible());
        }

        public static void AssertSearchFieldIsVisible(this MessagesPage messagesPage)
        {
            Assert.IsTrue(messagesPage.SearchField.IsVisible());
        }

        public static void AssertFriendItemIsVisible(this MessagesPage messagesPage)
        {
            Assert.IsTrue(messagesPage.FriendItem.IsVisible());
        }

        public static void AssertFriendAvatarIsVisible(this MessagesPage messagesPage)
        {
            Assert.IsTrue(messagesPage.FriendAvatarInFriendItem.IsVisible());
        }

        public static void AssertFriendNamesAreVisible(this MessagesPage messagesPage)
        {
            Assert.IsTrue(messagesPage.FriendNames.IsVisible());
        }

        public static void AssertFriendLastMessageBeginningIsVisible(this MessagesPage messagesPage)
        {
            Assert.IsTrue(messagesPage.FriendLastMessageBeginning.IsVisible());
        }

        public static void AssertFriendLastMessageTimeIsVisible(this MessagesPage messagesPage)
        {
            Assert.IsTrue(messagesPage.FriendLastMessageTime.IsVisible());
        }

        public static void AssertMessageIsSent(this MessagesPage messagesPage, string text)
        {
            Assert.IsTrue(messagesPage.LastMessageContainerLastParagraph.BaseElement.TextContent.Equals(text));
        }

        public static void AssertMessageIsNotSent(this MessagesPage messagesPage, string text)
        {
            Assert.IsFalse(messagesPage.LastMessageContainerLastParagraph.BaseElement.TextContent.Equals(text));
        }

        public static void AssertMessageIsSentAndLineBreakIsDisplayedCorrectly(this MessagesPage messagePage, string firstLine, string secondLine)
        {
            var lastMessageWrapper = messagePage.LastMessageContainerLastParagraph.BaseElement;
            bool isFirstLineCorrect = lastMessageWrapper.ChildNodes[1].TextContent.Equals(firstLine);
            bool isBreakLineCorrect = lastMessageWrapper.ChildNodes[2].Content.Equals("<br>");
            bool isSecondLineCorrect = lastMessageWrapper.ChildNodes[3].TextContent.Equals(secondLine);

            Assert.IsTrue(isFirstLineCorrect && isBreakLineCorrect && isSecondLineCorrect);
        }

        public static void AssertLastMessageContainerContainsProperData(this MessagesPage messagesPage, string text)
        {
            Assert.IsTrue(messagesPage.UserAvatarInMessageContainer.IsLoaded());
            Assert.IsTrue(messagesPage.LastMessageContainerLastParagraph.BaseElement.TextContent.Equals(text));
            Assert.IsTrue(messagesPage.MessageSentTime.IsVisible());
            Assert.IsTrue(messagesPage.Arrow != null);
        }
    }
}