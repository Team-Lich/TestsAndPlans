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

        public static void AssertFriendsListPanelBodyContainsFriend(this FriendsPage friendsPage)
        {
            Assert.IsTrue(friendsPage.FriendsListPanelBody.InnerText.Contains(TelerikUser.Related2.UserName.Substring(0, 15)));
        }

        public static void AssertFriendIsRemovedFromFriendsListPanelBody(this FriendsPage friendsPage)
        {
            Assert.IsFalse(friendsPage.FriendsMainContent.InnerText.Contains(TelerikUser.Related2.UserName.Substring(0, 15)));
        }

        public static void AssertConfirmationIsVisible(this FriendsPage friendsPage)
        {
            Assert.IsTrue(friendsPage.RemoveFriendshipConfirm.IsVisible());
        }

        public static void AssertNoFriendsMessageIsVisible(this FriendsPage friendsPage)
        {
            Assert.IsTrue(friendsPage.NoFriendsMessage.InnerText.StartsWith("В момента нямате добавени приятели!"));
        }
    }
}