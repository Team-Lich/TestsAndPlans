namespace TeamLichTestAutomation.Academy.Core.Pages.RegistrationPage
{
    using System.Linq;
    using ArtOfTest.Common.UnitTesting;

    public static class RegistrationPageAsserter
    {
        public static void AssertErrorMessageIsDisplayedWhenUsernameIsEmpty(this RegistrationPage registrationPage)
        {
            Assert.AreEqual(RegistrationPageErrorMessages.UsernameMissing,
                registrationPage.UsernameErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenEnterInvalidUsername(this RegistrationPage registrationPage)
        {
            Assert.AreEqual(RegistrationPageErrorMessages.UsernameInvalid, 
                registrationPage.UsernameErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenLastNameLengthIsLessThanMinimumAllowed(this RegistrationPage registrationPage)
        {
            Assert.AreEqual(RegistrationPageErrorMessages.LastNameInvalid,
                registrationPage.LastNameErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenLastNameContainNonCyrillicAlphabetSymbol(this RegistrationPage registrationPage)
        {
            Assert.AreEqual(RegistrationPageErrorMessages.LastNameInvalid, 
                registrationPage.LastNameErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenLastNameFieldIsEmpty(this RegistrationPage registrationPage)
        {
            Assert.AreEqual(RegistrationPageErrorMessages.LastNameMissing,
                registrationPage.LastNameМandatoryErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenCheckboxIsUnchecked(this RegistrationPage registrationPage)
        {
            Assert.AreEqual(RegistrationPageErrorMessages.TermsAndConditionsUnaccepted,
                registrationPage.ConditionsErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenEnterDifferentPasswordInPasswordAgainField(this RegistrationPage registrationPage)
        {
            Assert.AreEqual(RegistrationPageErrorMessages.PasswordAgainDifferent,
                registrationPage.PasswordAgainErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenLengthOfPasswordIsLessThanMinimumAllowed(this RegistrationPage registrationPage)
        {
            Assert.AreEqual(RegistrationPageErrorMessages.PasswordInvalidLength, 
                registrationPage.IncorrectPasswordLengthErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenLengthOfUsernameIsInccorect(this RegistrationPage registrationPage)
        {
            Assert.AreEqual(RegistrationPageErrorMessages.UsernameInvalidLength, 
                registrationPage.IncorrectUsernameLengthErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenPasswordAgainFieldIsEmpty(this RegistrationPage registrationPage)
        {
            Assert.AreEqual(RegistrationPageErrorMessages.PasswordAgainMissing,
                registrationPage.PasswordAgainErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenEmailIsEmpty(this RegistrationPage registrationPage)
        {
            Assert.AreEqual(RegistrationPageErrorMessages.EmailAddressMissing,
                registrationPage.EmailErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenFirstNameContainNonCyrillicAlphabetSymbol(this RegistrationPage registrationPage)
        {
            Assert.AreEqual(RegistrationPageErrorMessages.FirstNameInvalid,
                registrationPage.FirstNameErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenFirstNameLengthIsLessThanMinimumAllowed(this RegistrationPage registrationPage)
        {
            Assert.AreEqual(RegistrationPageErrorMessages.FirstNameInvalid, 
                registrationPage.FirstNameErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenUsernameStartsWithNonAlphabetSymbol(this RegistrationPage registrationPage)
        {
            Assert.AreEqual(RegistrationPageErrorMessages.UsernameInvalid, 
                registrationPage.UsernameErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenEmailAddressNotContainSpecialSymbols(this RegistrationPage registrationPage)
        {
            Assert.AreEqual(RegistrationPageErrorMessages.EmailAddressInvalid,
                registrationPage.EmailErrorMessage.InnerText);
        }
    }
}
