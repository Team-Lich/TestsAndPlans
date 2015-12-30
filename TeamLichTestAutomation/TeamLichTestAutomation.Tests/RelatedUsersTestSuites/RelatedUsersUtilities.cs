namespace TeamLichTestAutomation.Tests.RelatedUsersTestSuites
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;
    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.LoginPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;
    using TeamLichTestAutomation.Academy.Core.Pages.UserPage;

    public static class RelatedUsersUtilities
    {
        public static void MakeUsersFriends(Browser browser)
        {
            var homePage = LoginRelatedUser(TelerikUser.Related1, browser);
            homePage.NavigateTo(TelerikUser.Related2.Url);

            UserPage userPage = new UserPage(browser);
            if (userPage.AddFriendButton != null && userPage.AddFriendButton.IsVisible())
            {
                userPage.AddFriendButton.Click();
                homePage.LogoutButton.Click();

                homePage = LoginRelatedUser(TelerikUser.Related2, browser);
                homePage.NavigateTo("http://stage.telerikacademy.com/Friends");
                homePage.Browser.Find.ByAttributes<HtmlDiv>("class=approveFriendship").Click();
            }

            homePage.LogoutButton.Click();
        }

        public static MainPage LoginRelatedUser(TelerikUser relatedUser, Browser browser)
        {
            MainPage mainPage = new MainPage(browser);
            mainPage.Navigate().ClickLogin();

            LoginPage loginPage = new LoginPage(browser);
            loginPage.LoginUser(relatedUser);

            return mainPage;
        }
    }
}
