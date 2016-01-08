namespace TeamLichTestAutomation.Academy.Core.Pages.UserProfilePage
{
    using ArtOfTest.Common.UnitTesting;

    public static class UserProfilePageAsserter
    {
        public static void AssertProperUserProfilePageIsActive(this BasePage basePage, string userName)
        {
            Assert.IsTrue(basePage.Browser.PageTitle.Equals(
                "Профилът на " + userName + " - Телерик Академия - Студентска система"));
        }

        public static void AssertMessageButtonButtonIsInactive(this UserProfilePage userPage)
        {
            Assert.IsTrue(userPage.SendMessageButtonInactive.IsVisible());
        }

        public static void AssertAddFriendButtonIsVisible(this UserProfilePage userPage)
        {
            Assert.IsTrue(userPage.AddFriendButton.IsVisible());
        }

        public static void AssertRemoveFriendButtonIsVisible(this UserProfilePage userPage)
        {
            Assert.IsTrue(userPage.RemoveFriendButton.IsVisible());
        }
    }
}