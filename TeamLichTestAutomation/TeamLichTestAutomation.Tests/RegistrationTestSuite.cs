namespace TeamLichTestAutomation.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TeamLichTestAutomation.Academy.Core.Data;
    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;
    using TeamLichTestAutomation.Academy.Core.Pages.RegistrationPage;
    using TeamLichTestAutomation.Utilities.Attributes;

    [TestClass]
    public class RegistrationTestSuite : BaseTest
    {
        private MainPage mainPage;
        private RegistrationPage registrationPage;

        [TestInitialize]
        public void ThisTestInitialize()
        {
            this.mainPage = new MainPage(this.Browser);
            this.registrationPage = new RegistrationPage(this.Browser);

            this.mainPage.Navigate().ClickRegistration();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(48)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistrationWithUsernameEmpty()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.UserName = string.Empty;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenUsernameIsEmpty();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(51)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistrationWithUsernameInvalid()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.UserName = TelerikUserData.UsernameInvalidSymbols;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenEnterInvalidUsername();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(49)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistrationWithUsernameLengthLessThanMinimumAllowed()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.UserName = TelerikUserData.UsernameInvalidLengthDown;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenLengthOfUsernameIsIncorrect();
        }

        [TestMethod]
        [TestCategory("Registration")]
        ////[TestId(49)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistrationWithUsernameLengthAtAllowedDownBoundary()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.UserName = TelerikUserData.UsernameInvalidLengthBoundaryDown;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertNoErrorMessageIsDisplayedWhenLengthOfUsernameIsAtBoundary();
        }

        [TestMethod]
        [TestCategory("Registration")]
        ////[TestId(49)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistrationWithUsernameLengthAtAllowedUpBoundary()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.UserName = TelerikUserData.UsernameInvalidLengthBoundaryUp;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertNoErrorMessageIsDisplayedWhenLengthOfUsernameIsAtBoundary();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(50)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistrationWithUsernameLengthGreaterThanMaximumAllowed()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.UserName = TelerikUserData.UsernameInvalidLengthUp;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenLengthOfUsernameIsIncorrect();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(52)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistratioWithUsernameStartingWithNonAlphabetSymbol()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.UserName = TelerikUserData.UsernameStartingInvalidSymbol;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenUsernameStartsWithNonAlphabetSymbol();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(52)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistratioWithUsernameEndingWithNonAlphabetSymbol()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.UserName = TelerikUserData.UsernameEndingInvalidSymbol;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenUsernameEndsWithNonAlphabetSymbol();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(218)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistrationWithPasswordEmpty()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.Password = string.Empty;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenPasswordFieldIsEmpty();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(57)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistrationWithPasswordLengthLessThanMinimumAllowed()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.Password = TelerikUserData.PasswordInvalidLength;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenLengthOfPasswordIsLessThanMinimumAllowed();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(57)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistrationWithPasswordLengthAtAllowedBoundary()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.Password = TelerikUserData.PasswordValidBoundary;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertNoErrorMessageIsDisplayedWhenLengthOfPasswordIsAllowedBoundary();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(56)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistrationWithPasswordAgainDifferent()
        {
            TelerikUser user = new TelerikUser(
                TelerikUserData.UsernameValid,
                TelerikUserData.PasswordValid,
                TelerikUserData.FirstNameValid,
                TelerikUserData.LastNameValid,
                TelerikUserData.EmailValid);

            this.registrationPage.RegisterTelerikUser(user, TelerikUserData.PasswordAgainValid);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenEnterDifferentPasswordInPasswordAgainField();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(55)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistrationWithPasswordAgainEmpty()
        {
            TelerikUser user = new TelerikUser(
                TelerikUserData.UsernameValid,
                TelerikUserData.PasswordValid,
                TelerikUserData.FirstNameValid,
                TelerikUserData.LastNameValid,
                TelerikUserData.EmailValid);

            this.registrationPage.RegisterTelerikUser(user, string.Empty);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenPasswordAgainFieldIsEmpty();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(64)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistrationWithFirstNameEmptyField()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.FirstName = string.Empty;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenFirstNameFieldIsEmpty();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(59)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistrationWithFirstNameContainingNonCyrillicAlphabetSymbols()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.FirstName = TelerikUserData.FirstNameNonCyrillicSymbols;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenFirstNameContainNonCyrillicAlphabetSymbol();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(61)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistrationWithFirstNameStartingWithInvalidSymbols()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.FirstName = TelerikUserData.FirstNameInvalidBoundarySymbols;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenFirstNameStartsWithInvalidSymbol();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(63)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistrationWithFirstNameLengthLessThanMinimumAllowed()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.FirstName = TelerikUserData.FirstNameInvalidLength;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenFirstNameLengthIsLessThanMinimumAllowed();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(64)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistrationWithLastNameEmptyField()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.LastName = string.Empty;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenLastNameFieldIsEmpty();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(68)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistrationWithLastNameLengthLessThanMinimumAllowed()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.LastName = TelerikUserData.LastNameInvalidLength;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenLastNameLengthIsLessThanMinimumAllowed();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(65)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistrationWithLastNameContainingNonCyrillicAlphabetSymbols()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.LastName = TelerikUserData.LastNameInvalidSymbols;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenLastNameContainNonCyrillicAlphabetSymbol();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(61)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistrationWithLastNameStartingWithInvalidSymbols()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.FirstName = TelerikUserData.LastNameInvalidBoundarySymbols;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenLastNameStartsWithInvalidSymbol();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(69)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistrationWithEmailAddressEmpty()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.Email = string.Empty;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenEmailIsEmpty();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(71)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistrationWithEmailAddressNotContainingAtSymbol()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.Email = TelerikUserData.EmailMissingAtSymbol;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenEmailAddressNotContainSpecialSymbols();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(70)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistrationWithEmailAddressNotContainPointSymbol()
        {
            TelerikUser user = TelerikUser.ValidUser;
            user.Email = TelerikUserData.EmailMissingPointSymbol;

            this.registrationPage.RegisterTelerikUser(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenEmailAddressNotContainSpecialSymbols();
        }

        [TestMethod]
        [TestCategory("Registration")]
        [TestId(73)]
        [Priority(2)]
        [Owner("Ilvie")]
        public void RegistrationWithTermsAndConditionsCheckboxUnchecked()
        {
            TelerikUser user = TelerikUser.ValidUser;

            this.registrationPage.RegisterTelerikUserWithUncheckedCheckbox(user);

            this.registrationPage.AssertErrorMessageIsDisplayedWhenCheckboxIsUnchecked();
        }
    }
}