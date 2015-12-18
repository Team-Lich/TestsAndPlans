namespace TeamLichTestAutomation.Academy.Core.Pages.UserPage
{
    using System.Threading;
    using ArtOfTest.Common.UnitTesting;

    public static class UserPageAsserter
    {
        public static void AssertMessagesPageIsOpenedWhenSendMessageButtonIsClicked(this UserPage userPage)
        {
            userPage.Browser.WaitUntilReady();
            Assert.AreEqual(userPage.Browser.PageTitle, "Съобщения - Телерик Академия - Студентска система");
        }

        public static void AssertFriendIsRemovedWhenRemoveFriendButtonIsClicked(this UserPage userPage)
        {
            Assert.IsTrue(userPage.AddFriendButton.IsVisible());
        }
    }
}
