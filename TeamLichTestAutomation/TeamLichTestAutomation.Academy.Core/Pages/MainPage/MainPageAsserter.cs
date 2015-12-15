namespace TeamLichTestAutomation.Academy.Core.Pages.MainPage
{
    using ArtOfTest.Common.UnitTesting;

    public static class MainPageAsserter
    {
        public static void AssertUserIsLogged(this MainPage mainPage)
        {
            Assert.IsTrue(mainPage.LogoutButton.IsEnabled);
        }
    }
}