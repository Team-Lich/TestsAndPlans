namespace TeamLichTestAutomation.Academy.Core.Pages.MainPage
{
    using ArtOfTest.Common.UnitTesting;

    public static class MainPageAsserter
    {
        public static void AssertUserIsLoggedAsRegularUser(this MainPage mainPage)
        {
            bool adminDropdownPresent = mainPage.AdminDropdownEnabled;

            Assert.IsTrue(mainPage.LogoutButton.IsEnabled);
            Assert.IsFalse(adminDropdownPresent);
        }

        public static void AssertUserIsLoggedAsAdmin(this MainPage mainPage)
        {
            bool adminDropdownPresent = mainPage.AdminDropdownEnabled;

            Assert.IsTrue(mainPage.LogoutButton.IsEnabled);
            Assert.IsTrue(adminDropdownPresent);
        }

        public static void AssertUserIsNotLogged(this MainPage mainPage)
        {
            Assert.IsTrue(mainPage.LoginButton.IsEnabled);
        }
    }
}