namespace TeamLichTestAutomation.Academy.Core.Pages.RegistrationPage
{
    using System.Linq;
    using ArtOfTest.Common.UnitTesting;

    public static class RegistrationPageAsserter
    {
        public static void AssertErrorMessageIsDisplayedWhenEnterInvalidUsername(this RegistrationPage registrationPage)
        {

            string invalidUsernameErrorMessage = "Потребителското име може да съдържа само малки и " +
                                                 "главни латински букви, цифри и знаците точка и долна черта. " +
                                                 "Потребителското име трябва да започва с буква и да завършва с буква или цифра.";

            Assert.AreEqual(invalidUsernameErrorMessage, registrationPage.UsernameErrorMessage.InnerText);
        }
    }
}
