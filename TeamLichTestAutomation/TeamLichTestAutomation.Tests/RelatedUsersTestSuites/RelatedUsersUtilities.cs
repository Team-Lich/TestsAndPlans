namespace TeamLichTestAutomation.Tests.RelatedUsersTestSuites
{
    using Academy.Core.Pages.FriendsPage;
    using ArtOfTest.WebAii.Core;
    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.LoginPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;
    using TeamLichTestAutomation.Academy.Core.Pages.UserPage;

    public static class RelatedUsersUtilities
    {
        public static void RemoveFriend(Browser browser)
        {
            var homePage = LoginUser(TelerikUser.Related1, browser);
            homePage.NavigateTo(TelerikUser.Related2.Url);

            UserPage userPage = new UserPage(browser);
            if (userPage.RemoveFriendButton != null && userPage.RemoveFriendButton.IsVisible())
            {
                userPage.RemoveFriendButton.Click();
            }

            homePage.LogoutButton.Click();
        }

        public static void AddFriend(Browser browser)
        {
            var homePage = LoginUser(TelerikUser.Related1, browser);
            homePage.NavigateTo(TelerikUser.Related2.Url);

            UserPage userPage = new UserPage(browser);
            if (userPage.AddFriendButton != null && userPage.AddFriendButton.IsVisible())
            {
                userPage.AddFriendButton.Click();
                homePage.LogoutButton.Click();

                homePage = LoginUser(TelerikUser.Related2, browser);
                homePage.NavigateTo(FriendsTestSuite.friendsPageUrl);

                FriendsPage friendsPage = new FriendsPage(browser);
                friendsPage.ClickApproveFriendshipIcon();
            }

            homePage.LogoutButton.Click();
        }

        public static MainPage LoginUser(TelerikUser relatedUser, Browser browser)
        {
            MainPage mainPage = new MainPage(browser);
            mainPage.Navigate().ClickLogin();

            LoginPage loginPage = new LoginPage(browser);
            loginPage.LoginUser(relatedUser);

            return mainPage;
        }
    }
}
