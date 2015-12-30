namespace TeamLichTestAutomation.Academy.Core.Pages.LoginPage
{
    using ArtOfTest.Common.UnitTesting;

    public static class LoginPageAsserter
    {
        public static void AssertIfErrorMessageForIllegalDataIsShown(this LoginPage loginPage)
        {
            var list = loginPage.ErrorsShown;

            bool errorPresent = false;

            foreach (var item in list)
            {
                if (item.InnerText.Contains("Невалидни данни за достъп!"))
                {
                    errorPresent = true;
                    break;
                }
            }

            Assert.IsTrue(errorPresent);
        }
    }
}