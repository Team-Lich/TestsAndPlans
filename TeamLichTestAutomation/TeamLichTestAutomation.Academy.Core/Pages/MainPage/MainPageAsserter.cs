namespace TeamLichTestAutomation.Academy.Core.Pages.MainPage
{
    using System.Linq;
    using ArtOfTest.Common.UnitTesting;

    public static class MainPageAsserter
    {
        public static void AssertUserIsLoggedAsRegularUser(this MainPage mainPage)
        {
            bool adminDropdownPresent = mainPage.NavigationBarItems.Contains("Админ");

            Assert.IsTrue(mainPage.LogoutButton.IsEnabled);
            Assert.IsFalse(adminDropdownPresent);

        }

        public static void AssertUserIsLoggedAsAdmin(this MainPage mainPage)
        {
            bool adminDropdownPresent = mainPage.NavigationBarItems.Contains("Админ");

            Assert.IsTrue(mainPage.LogoutButton.IsEnabled);
            Assert.IsTrue(adminDropdownPresent);
        }
    }
}