namespace TeamLichTestAutomation.Academy.Core.Pages.UserPage
{
    using ArtOfTest.Common.UnitTesting;

    public static class UserPageAsserter
    {
        public static void AssertMessagesPageIsOpenedWhenSendMessageButtonIsClicked(this UserPage userPage)
        {
            Assert.AreEqual(userPage.Browser.PageTitle, "Съобщения - Телерик Академия - Студентска система");
        }

        public static void AssertFriendIsRemovedWhenRemoveFriendButtonIsClicked(this UserPage userPage)
        {
            Assert.IsTrue(userPage.AddFriendButton.IsVisible());
        }
    }
}
