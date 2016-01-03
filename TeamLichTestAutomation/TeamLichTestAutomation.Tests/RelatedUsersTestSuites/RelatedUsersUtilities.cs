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
        private static readonly string LoginPageUrl = "http://stage.telerikacademy.com/Users/Auth/Login";

        private static MainPage mainPage;
        private static LoginPage loginPage;
        private static UserPage userPage;
        private static FriendsPage friendsPage;

        public static void RemoveFriend(Browser browser)
        {
            LoginUser(TelerikUser.Related1, browser);
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
            LoginUser(TelerikUser.Related1, browser);
            mainPage.NavigateTo(TelerikUser.Related2.Url);

            userPage = new UserPage(browser);
            if (userPage.AddFriendButton != null && userPage.AddFriendButton.IsVisible())
            {
                userPage.AddFriendButton.Click();
                mainPage.LogoutButton.Click();

                mainPage = LoginUser(TelerikUser.Related2, browser);
                mainPage.NavigateTo(FriendsTestSuite.FriendsPageUrl);

                friendsPage = new FriendsPage(browser);
                friendsPage.ClickApproveFriendshipIcon();
            }

            mainPage.LogoutButton.Click();
        }

        public static MainPage LoginUser(TelerikUser relatedUser, Browser browser)
        {
            mainPage = new MainPage(browser);
            mainPage.NavigateTo(LoginPageUrl);

            loginPage = new LoginPage(browser);
            loginPage.LoginUser(relatedUser);

            return mainPage;
        }
    }
}