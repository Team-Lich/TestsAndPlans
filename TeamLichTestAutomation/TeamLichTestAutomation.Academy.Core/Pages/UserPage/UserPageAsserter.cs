namespace TeamLichTestAutomation.Academy.Core.Pages.UserPage
{
    using ArtOfTest.Common.UnitTesting;

    public static class UserPageAsserter
    {
        public static void AssertProperUserProfilePageIsActive(this BasePage basePage, string userName)
        {
            Assert.IsTrue(basePage.Browser.PageTitle.Equals(
                "Профилът на " + userName + " - Телерик Академия - Студентска система"));
        }

        public static void AssertMessageButtonButtonIsInactive(this UserPage userPage)
        {
            Assert.IsTrue(userPage.SendMessageButtonInactive.IsVisible());
        }

        public static void AssertAddFriendButtonIsVisible(this UserPage userPage)
        {
            Assert.IsTrue(userPage.AddFriendButton.IsVisible());
        }

        public static void AssertRemoveFriendButtonIsVisible(this UserPage userPage)
        {
            Assert.IsTrue(userPage.RemoveFriendButton.IsVisible());
        }
    }
}