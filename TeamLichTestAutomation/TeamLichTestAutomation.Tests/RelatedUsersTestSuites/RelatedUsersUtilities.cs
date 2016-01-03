namespace TeamLichTestAutomation.Tests.RelatedUsersTestSuites
{
    using ArtOfTest.WebAii.Core;

    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.FriendsPage;
    using TeamLichTestAutomation.Academy.Core.Pages.LoginPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;
    using TeamLichTestAutomation.Academy.Core.Pages.UserPage;

    /// <summary>
    /// Summary description for RelatedUsersUtilities
    /// </summary>
    public static class RelatedUsersUtilities
    {
        private static MainPage mainPage;
        private static LoginPage loginPage;
        private static UserPage userPage;
        private static FriendsPage friendsPage;

        public static void RemoveFriend(Browser browser)
        {
            mainPage = LoginUser(TelerikUser.Related1, browser);
            mainPage.NavigateTo(TelerikUser.Related2.Url);

            userPage = new UserPage(browser);
            if (userPage.RemoveFriendButton != null && userPage.RemoveFriendButton.IsVisible())
            {
                userPage.RemoveFriendButton.Click();
            }

            mainPage.LogoutButton.Click();
        }

        public static void AddFriend(Browser browser)
        {
            var homePage = LoginUser(TelerikUser.Related1, browser);
            homePage.NavigateTo(TelerikUser.Related2.Url);

            userPage = new UserPage(browser);
            if (userPage.AddFriendButton != null && userPage.AddFriendButton.IsVisible())
            {
                userPage.AddFriendButton.Click();
                homePage.LogoutButton.Click();

                homePage = LoginUser(TelerikUser.Related2, browser);
                homePage.NavigateTo(FriendsTestSuite.friendsPageUrl);

                friendsPage = new FriendsPage(browser);
                friendsPage.ClickApproveFriendshipIcon();
            }

            homePage.LogoutButton.Click();
        }

        public static MainPage LoginUser(TelerikUser relatedUser, Browser browser)
        {
            mainPage = new MainPage(browser);
            mainPage.Navigate().ClickLogin();

            loginPage = new LoginPage(browser);
            loginPage.LoginUser(relatedUser);

            return mainPage;
        }
    }
}