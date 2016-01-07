namespace TeamLichTestAutomation.Tests.RelatedUsersTestSuites
{
    using ArtOfTest.WebAii.Core;

    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.FriendsPage;
    using TeamLichTestAutomation.Academy.Core.Pages.LoginPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;
    using TeamLichTestAutomation.Academy.Core.Pages.UserProfilePage;

    /// <summary>
    /// Summary description for RelatedUsersUtilities
    /// </summary>
    public static class RelatedUsersUtilities
    {
        private static MainPage mainPage;
        private static LoginPage loginPage;
        private static UserProfilePage userPage;
        private static FriendsPage friendsPage;

        public static void RemoveFriend(Browser browser)
        {
            loginPage = new LoginPage(browser);
            loginPage.LoginUser(TelerikUser.Related1);

            mainPage = new MainPage(browser);
            mainPage.NavigateTo(TelerikUser.Related2.Url);

            userPage = new UserProfilePage(browser);
            if (userPage.RemoveFriendButton != null && userPage.RemoveFriendButton.IsVisible())
            {
                userPage.ClickRemoveFriendButton();
            }

            mainPage.ClickLogout();
            mainPage.NavigateTo(loginPage.Url);
            loginPage.LoginUser(TelerikUser.Related1);
        }

        public static void AddFriend(Browser browser)
        {
            loginPage = new LoginPage(browser);
            loginPage.LoginUser(TelerikUser.Related1);

            mainPage = new MainPage(browser);
            mainPage.NavigateTo(TelerikUser.Related2.Url);

            userPage = new UserProfilePage(browser);
            if (userPage.AddFriendButton != null && userPage.AddFriendButton.IsVisible())
            {
                userPage.ClickAddFriendButton();
                mainPage.ClickLogout();

                mainPage.NavigateTo(loginPage.Url);
                loginPage.LoginUser(TelerikUser.Related2);

                friendsPage = new FriendsPage(browser);
                mainPage.NavigateTo(friendsPage.Url);
                friendsPage.ClickApproveFriendshipIcon();
            }

            mainPage.ClickLogout();
            mainPage.NavigateTo(loginPage.Url);
            loginPage.LoginUser(TelerikUser.Related1);
        }
    }
}