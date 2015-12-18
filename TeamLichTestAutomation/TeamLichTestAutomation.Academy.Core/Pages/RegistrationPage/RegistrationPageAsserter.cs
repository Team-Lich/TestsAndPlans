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

        public static void AssertErrorMessageIsDisplayedWhenCheckboxIsUnchecked(this RegistrationPage registrationPage)
        {
            string errorMessage = "За да се рагистрирате трябва да приемете условията и правилата на академията на Телерик";

            Assert.AreEqual(errorMessage, registrationPage.ConditionsErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenEnterDifferentPasswordInPasswordAgainField(this RegistrationPage registrationPage)
        {
            string differentPassworErrorMessage = "Паролите не съвпадат";

            Assert.AreEqual(differentPassworErrorMessage, registrationPage.PasswordAgainErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenLengthOfPasswordIsLessThanMinimumAllowed(this RegistrationPage registrationPage)
        {
            string incorrectPasswordErrorMessage = "Паролата трябва да е повече от 6 символа";

            Assert.AreEqual(incorrectPasswordErrorMessage, registrationPage.IncorrectPasswordLengthErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenLengthOfUsernameIsInccorect(this RegistrationPage registrationPage)
        {
            string incorrectUsernameErrorMessage = "Потребителското име трябва да е между 5 и 32 символа";

            Assert.AreEqual(incorrectUsernameErrorMessage, registrationPage.IncorrectUsernameLengthErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenPasswordAgainFieldIsEmpty(this RegistrationPage registrationPage)
        {
            string mandatoryPasswordErrorMessage = "Паролата отново е задължителна";

            Assert.AreEqual(mandatoryPasswordErrorMessage, registrationPage.PasswordAgainErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenEmailIsEmpty(this RegistrationPage registrationPage)
        {
            string emailErrorMessage = "Имейлът е задължителен";

            Assert.AreEqual(emailErrorMessage, registrationPage.EmailErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenFirstNameContainNonCyrillicAlphabetSymbol(this RegistrationPage registrationPage)
        {
            string firstNameErrorMessage = "Името може да съдържа само букви от българската азбука и знака тире. " +
                                       "Името трябва да започва и да завършва с буква. Минимална дължина - 2 букви.";

            Assert.AreEqual(firstNameErrorMessage, registrationPage.FirstNameErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenFirstNameLengthIsLessThanMinimumAllowed(this RegistrationPage registrationPage)
        {
            string firstNameErrorMessage = "Името може да съдържа само букви от българската азбука и знака тире. " +
                                           "Името трябва да започва и да завършва с буква. Минимална дължина - 2 букви.";

            Assert.AreEqual(firstNameErrorMessage, registrationPage.FirstNameErrorMessage.InnerText);
        }
    }
}
