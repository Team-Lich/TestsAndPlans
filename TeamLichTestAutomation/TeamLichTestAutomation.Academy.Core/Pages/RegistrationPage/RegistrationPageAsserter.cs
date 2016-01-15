namespace TeamLichTestAutomation.Academy.Core.Pages.RegistrationPage
{
    using ArtOfTest.Common.UnitTesting;
    using TeamLichTestAutomation.Academy.Core.Pages.RegistrationPage.RegistrationPageConstants;

    public static class RegistrationPageAsserter
    {
        public static void AssertErrorMessageIsDisplayedWhenUsernameIsEmpty(this RegistrationPage registrationPage)
        {
            Assert.AreEqual(
                RegistrationPageErrorMessages.UsernameMissing,
                registrationPage.UsernameErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenEnterInvalidUsername(this RegistrationPage registrationPage)
        {
            Assert.IsTrue(
                registrationPage.UsernameErrorMessage.InnerText
                .Contains(RegistrationPageErrorMessages.UsernameInvalid));
        }

        public static void AssertErrorMessageIsDisplayedWhenUsernameStartsWithNonAlphabetSymbol(this RegistrationPage registrationPage)
        {
            Assert.IsTrue(
                registrationPage.UsernameErrorMessage.InnerText
                .Contains(RegistrationPageErrorMessages.UsernameInvalidInitialSymbol));
        }

        public static void AssertErrorMessageIsDisplayedWhenUsernameEndsWithNonAlphabetSymbol(this RegistrationPage registrationPage)
        {
            Assert.IsTrue(
                registrationPage.UsernameErrorMessage.InnerText
                .Contains(RegistrationPageErrorMessages.UsernameInvalidInitialSymbol));
        }

        public static void AssertErrorMessageIsDisplayedWhenLengthOfUsernameIsIncorrect(this RegistrationPage registrationPage)
        {
            Assert.IsTrue(
                registrationPage.UsernameErrorMessage.InnerText
                .Contains(RegistrationPageErrorMessages.UsernameInvalidLength));
        }

        public static void AssertNoErrorMessageIsDisplayedWhenLengthOfUsernameIsAtBoundary(this RegistrationPage registrationPage)
        {
            Assert.IsFalse(
                registrationPage.ValidationSummaryErrors.InnerText
                .Contains(RegistrationPageErrorMessages.UsernameInvalidLength));
        }

        public static void AssertErrorMessageIsDisplayedWhenLastNameLengthIsLessThanMinimumAllowed(this RegistrationPage registrationPage)
        {
            Assert.IsTrue(
                registrationPage.LastNameErrorMessage.InnerText
                .Contains(RegistrationPageErrorMessages.NameInvalidLength));
        }

        public static void AssertErrorMessageIsDisplayedWhenLastNameContainNonCyrillicAlphabetSymbol(this RegistrationPage registrationPage)
        {
            Assert.IsTrue(
                registrationPage.LastNameErrorMessage.InnerText
                .Contains(RegistrationPageErrorMessages.LastNameInvalid));
        }

        public static void AssertErrorMessageIsDisplayedWhenLastNameFieldIsEmpty(this RegistrationPage registrationPage)
        {
            Assert.AreEqual(
                RegistrationPageErrorMessages.LastNameMissing,
                registrationPage.LastNameErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenFirstNameFieldIsEmpty(this RegistrationPage registrationPage)
        {
            Assert.AreEqual(
                RegistrationPageErrorMessages.FirstNameMissing,
                registrationPage.FirstNameErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenFirstNameStartsWithInvalidSymbol(this RegistrationPage registrationPage)
        {
            Assert.IsTrue(
                registrationPage.FirstNameErrorMessage.InnerText
                .Contains(RegistrationPageErrorMessages.FirstNameInvalidBoundarySymbols));
        }

        public static void AssertErrorMessageIsDisplayedWhenLastNameStartsWithInvalidSymbol(this RegistrationPage registrationPage)
        {
            Assert.IsTrue(
                registrationPage.LastNameErrorMessage.InnerText
                .Contains(RegistrationPageErrorMessages.LastNameInvalidBoundarySymbols));
        }

        public static void AssertErrorMessageIsDisplayedWhenCheckboxIsUnchecked(this RegistrationPage registrationPage)
        {
            Assert.AreEqual(
                RegistrationPageErrorMessages.TermsAndConditionsUnaccepted,
                registrationPage.ConditionsErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenEnterDifferentPasswordInPasswordAgainField(this RegistrationPage registrationPage)
        {
            Assert.AreEqual(
                RegistrationPageErrorMessages.PasswordAgainDifferent,
                registrationPage.PasswordAgainErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenLengthOfPasswordIsLessThanMinimumAllowed(this RegistrationPage registrationPage)
        {
            Assert.AreEqual(
                RegistrationPageErrorMessages.PasswordInvalidLength,
                registrationPage.PasswordErrorMessage.InnerText);
        }

        public static void AssertNoErrorMessageIsDisplayedWhenLengthOfPasswordIsAllowedBoundary(this RegistrationPage registrationPage)
        {
            Assert.IsFalse(
                registrationPage.ValidationSummaryErrors.InnerText
                .Contains(RegistrationPageErrorMessages.PasswordInvalidLength));
        }

        public static void AssertErrorMessageIsDisplayedWhenPasswordAgainFieldIsEmpty(this RegistrationPage registrationPage)
        {
            Assert.AreEqual(
                RegistrationPageErrorMessages.PasswordAgainMissing,
                registrationPage.PasswordAgainErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenPasswordFieldIsEmpty(this RegistrationPage registrationPage)
        {
            Assert.IsTrue(
                registrationPage.PasswordErrorMessage.InnerText
                .Contains(RegistrationPageErrorMessages.PasswordMissing));
        }

        public static void AssertErrorMessageIsDisplayedWhenEmailIsEmpty(this RegistrationPage registrationPage)
        {
            Assert.AreEqual(
                RegistrationPageErrorMessages.EmailAddressMissing,
                registrationPage.EmailErrorMessage.InnerText);
        }

        public static void AssertErrorMessageIsDisplayedWhenFirstNameContainNonCyrillicAlphabetSymbol(this RegistrationPage registrationPage)
        {
            Assert.IsTrue(
                registrationPage.FirstNameErrorMessage.InnerText
                .Contains(RegistrationPageErrorMessages.FirstNameNonCyrillicSymbol));
        }

        public static void AssertErrorMessageIsDisplayedWhenFirstNameLengthIsLessThanMinimumAllowed(this RegistrationPage registrationPage)
        {
            Assert.IsTrue(
                registrationPage.FirstNameErrorMessage.InnerText
                .Contains(RegistrationPageErrorMessages.NameInvalidLength));
        }

        public static void AssertErrorMessageIsDisplayedWhenEmailAddressNotContainSpecialSymbols(this RegistrationPage registrationPage)
        {
            Assert.AreEqual(
                RegistrationPageErrorMessages.EmailAddressInvalid,
                registrationPage.EmailErrorMessage.InnerText);
        }
    }
}