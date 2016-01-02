namespace TeamLichTestAutomation.Academy.Core.Pages.FriendsPage
{
    using ArtOfTest.Common.UnitTesting;
    using Models;

    public static class FriendsPageAsserter
    {
        public static void AssertFriendsListPanelHasProperHeading(this FriendsPage friendsPage)
        {
            Assert.IsTrue(friendsPage.FriendsListPanelHeading.InnerText.Contains("Списък с приятели"));
        }

        public static void AssertFriendsListPanelBodyContainsFriends(this FriendsPage friendsPage)
        {
            Assert.IsTrue(friendsPage.FriendsListPanelBody.InnerText.Contains(TelerikUser.Related2.UserName.Substring(0, 15)));
        }

        public static void AssertCorrespondingProfilePageIsOpenedWhenFriendItemIsClicked(this FriendsPage friendsPage)
        {
            Assert.IsTrue(friendsPage.Browser.PageTitle.Equals(
                "Профилът на " + TelerikUser.Related2.UserName + " - Телерик Академия - Студентска система"));
        }

        public static void AssertNoFriendsMessageShouldBeVisible(this FriendsPage friendsPage)
        {
            Assert.IsTrue(friendsPage.NoFriendsMessage.InnerText.StartsWith("В момента нямате добавени приятели!"));
        }
    }
}
