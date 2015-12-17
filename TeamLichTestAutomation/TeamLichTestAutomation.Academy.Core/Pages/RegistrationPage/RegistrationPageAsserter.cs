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

        public static void AssertErrorMessageIsDisplayedWhenLastNameLengthIsLessThanMinimumAllowed(this RegistrationPage registrationPage)
        {

            string lastNameExpectedErrorMessage = "Фамилията може да съдържа само букви от българската азбука " +
                                           "и знака тире. Фамилията трябва да започва и да завършва с буква. " +
                                           "Минимална дължина - 2 букви.";

            Assert.AreEqual(lastNameExpectedErrorMessage, registrationPage.LastNameErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenLastNameContainNonCyrillicAlphabetSymbol(this RegistrationPage registrationPage)
        {

            string lastNameExpectedErrorMessage = "Фамилията може да съдържа само букви от българската азбука " +
                                           "и знака тире. Фамилията трябва да започва и да завършва с буква. " +
                                           "Минимална дължина - 2 букви.";

            Assert.AreEqual(lastNameExpectedErrorMessage, registrationPage.LastNameErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenLastNameFieldIsEmpty(this RegistrationPage registrationPage)
        {
            string lastNameErrorMessage = "Фамилията на български е задължителна";

            Assert.AreEqual(lastNameErrorMessage, registrationPage.LastNameМandatoryErrorMessage.InnerText);
        }
    }
}
