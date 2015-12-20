namespace TeamLichTestAutomation.Academy.Core.Pages.RegistrationPage
{
    using System.Threading;
    using ArtOfTest.WebAii.Core;
    using TeamLichTestAutomation.Utilities;

    public partial class RegistrationPage : BasePage
    {

        public const string Password = "123456";

        public RegistrationPage(Browser browser)
            : base(browser)
        {
        }

        public void RegisterRandomUser()
        {
            RandomStringGenerator generator = new RandomStringGenerator();

            this.UsernameTextBox.Text = generator.GetString(8);
            this.PasswordTextBox.Text = Password;
            this.RepeatPasswordTextBox.Text = Password;
            this.FirstNameTextBox.Text = "ТестИме";
            this.LastNameTextBox.Text = "ТестФамилия";
            this.EmailTextBox.Text = generator.GetString(8) + "@test.com";
            this.TermAndConditionsCheckBox.Checked = true;
            this.SubmitButton.Click();
        }

        public void RegistrationWithInvalidUsername()
        {
            this.UsernameTextBox.Text = "user@test";
            this.PasswordTextBox.Text = Password;
            this.RepeatPasswordTextBox.Text = Password;
            this.FirstNameTextBox.Text = "ТестИме";
            this.LastNameTextBox.Text = "ТестФамилия";
            this.EmailTextBox.Text = "mailtest@test.com";
            this.TermAndConditionsCheckBox.Checked = true;
            this.SubmitButton.Click();
        }

        public void RegistrationWithLengthOfUsernameLessThanMinimumAllowed()
        {
            this.UsernameTextBox.Text = "user";
            this.PasswordTextBox.Text = Password;
            this.RepeatPasswordTextBox.Text = Password;
            this.FirstNameTextBox.Text = "ТестИме";
            this.LastNameTextBox.Text = "ТестФамилия";
            this.EmailTextBox.Text = "mailtest@test.com";
            this.TermAndConditionsCheckBox.Checked = true;
            this.SubmitButton.Click();
        }

        public void RegistrationWithLengthOfUsernameGreaterThanMaximumAllowed()
        {
            this.UsernameTextBox.Text = "useruseruseruseruseruseruseruserus";
            this.PasswordTextBox.Text = Password;
            this.RepeatPasswordTextBox.Text = Password;
            this.FirstNameTextBox.Text = "ТестИме";
            this.LastNameTextBox.Text = "ТестФамилия";
            this.EmailTextBox.Text = "mailtest@test.com";
            this.TermAndConditionsCheckBox.Checked = true;
            this.SubmitButton.Click();
        }

        public void RegistratioWithUsernameStartingWithNonAlphabetSymbol()
        {
            this.UsernameTextBox.Text = "1usertest";
            this.PasswordTextBox.Text = Password;
            this.RepeatPasswordTextBox.Text = Password;
            this.FirstNameTextBox.Text = "имеТест";
            this.LastNameTextBox.Text = "Фамилия";
            this.EmailTextBox.Text = "mailtest@test.com";
            this.TermAndConditionsCheckBox.Checked = true;
            this.SubmitButton.Click();
        }

        public void RegistrationWithDifferentPasswordInPasswordAgainField()
        {
            this.UsernameTextBox.Text = "usertest";
            this.PasswordTextBox.Text = Password;
            this.RepeatPasswordTextBox.Text = "12345678";
            this.FirstNameTextBox.Text = "ТестИме";
            this.LastNameTextBox.Text = "ТестФамилия";
            this.EmailTextBox.Text = "mailtest@test.com";
            this.TermAndConditionsCheckBox.Checked = true;
            this.SubmitButton.Click();
        }

        public void RegistrationWithLengthOfPasswordLessThanMinimumAllowed()
        {
            string incorrectPassword = "123";

            this.UsernameTextBox.Text = "usertest";
            this.PasswordTextBox.Text = incorrectPassword;
            this.RepeatPasswordTextBox.Text = incorrectPassword;
            this.FirstNameTextBox.Text = "ТестИме";
            this.LastNameTextBox.Text = "ТестФамилия";
            this.EmailTextBox.Text = "mailtest@test.com";
            this.TermAndConditionsCheckBox.Checked = true;
            Thread.Sleep(1000);
            this.SubmitButton.Click();
        }

        public void RegistrationWithEmptyPasswordAgainField()
        {
            this.UsernameTextBox.Text = "usertest";
            this.PasswordTextBox.Text = Password;
            this.FirstNameTextBox.Text = "ТестИме";
            this.LastNameTextBox.Text = "ТестФамилия";
            this.EmailTextBox.Text = "mailtest@test.com";
            this.TermAndConditionsCheckBox.Checked = true;
            this.SubmitButton.Click();
        }

        public void RegistrationWithNonCyrillicAlphabetSymbolsInFirsttNameField()
        {
            this.UsernameTextBox.Text = "usertest";
            this.PasswordTextBox.Text = Password;
            this.RepeatPasswordTextBox.Text = Password;
            this.FirstNameTextBox.Text = "testИме";
            this.LastNameTextBox.Text = "фамилия";
            this.EmailTextBox.Text = "mailtest@test.com";
            this.TermAndConditionsCheckBox.Checked = true;
            this.SubmitButton.Click();
        }

        public void RegistrationWithLengthOfFirstNameLessThanMinimumAllowed()
        {
            this.UsernameTextBox.Text = "usertest";
            this.PasswordTextBox.Text = Password;
            this.RepeatPasswordTextBox.Text = Password;
            this.FirstNameTextBox.Text = "и";
            this.LastNameTextBox.Text = "Фамилия";
            this.EmailTextBox.Text = "mailtest@test.com";
            this.TermAndConditionsCheckBox.Checked = true;
            this.SubmitButton.Click();
        }

        public void RegistrationWithLengthOfLastNameLessThanMinimumAllowed()
        {
            this.UsernameTextBox.Text = "usertest";
            this.PasswordTextBox.Text = Password;
            this.RepeatPasswordTextBox.Text = Password;
            this.FirstNameTextBox.Text = "ТестИме";
            this.LastNameTextBox.Text = "Ф";
            this.EmailTextBox.Text = "mailtest@test.com";
            this.TermAndConditionsCheckBox.Checked = true;
            this.SubmitButton.Click();
        }

        public void RegistrationWithNonCyrillicAlphabetSymbolsInLastNameField()
        {
            this.UsernameTextBox.Text = "usertest";
            this.PasswordTextBox.Text = Password;
            this.RepeatPasswordTextBox.Text = Password;
            this.FirstNameTextBox.Text = "ТестИме";
            this.LastNameTextBox.Text = "testфамилия";
            this.EmailTextBox.Text = "mailtest@test.com";
            this.TermAndConditionsCheckBox.Checked = true;
            this.SubmitButton.Click();
        }

        public void RegistrationWithEmptyLastNameField()
        {
            this.UsernameTextBox.Text = "usertest";
            this.PasswordTextBox.Text = Password;
            this.RepeatPasswordTextBox.Text = Password;
            this.FirstNameTextBox.Text = "ТестИме";
            this.EmailTextBox.Text = "mailtest@test.com";
            this.TermAndConditionsCheckBox.Checked = true;
            this.SubmitButton.Click();
        }

        public void RegistrationWithEmptyEmail()
        {
            this.UsernameTextBox.Text = "usertest";
            this.PasswordTextBox.Text = Password;
            this.RepeatPasswordTextBox.Text = Password;
            this.FirstNameTextBox.Text = "ТестИме";
            this.LastNameTextBox.Text = "ТестФамилия";
            this.TermAndConditionsCheckBox.Checked = true;
            this.SubmitButton.Click();
        }

        public void RegistrationWithEmailAddressNotContainingAtSymbol()
        {
            this.UsernameTextBox.Text = "usertest";
            this.PasswordTextBox.Text = Password;
            this.RepeatPasswordTextBox.Text = Password;
            this.FirstNameTextBox.Text = "имеТест";
            this.LastNameTextBox.Text = "Фамилия";
            this.EmailTextBox.Text = "mailtest.com";
            this.TermAndConditionsCheckBox.Checked = true;
            this.SubmitButton.Click();
        }

        public void RegistrationWithEmailAddressNotContainingPointSymbol()
        {
            this.UsernameTextBox.Text = "usertest";
            this.PasswordTextBox.Text = Password;
            this.RepeatPasswordTextBox.Text = Password;
            this.FirstNameTextBox.Text = "имеТест";
            this.LastNameTextBox.Text = "Фамилия";
            this.EmailTextBox.Text = "mailtest@testcom";
            this.TermAndConditionsCheckBox.Checked = true;
            this.SubmitButton.Click();
        }

        public void RegistrationWithUncheckedTermsAndConditionsCheckbox()
        {
            this.UsernameTextBox.Text = "usertest";
            this.PasswordTextBox.Text = Password;
            this.RepeatPasswordTextBox.Text = Password;
            this.FirstNameTextBox.Text = "ТестИме";
            this.LastNameTextBox.Text = "ТестФамилия";
            this.EmailTextBox.Text = "mailtest@test.com";
            this.SubmitButton.Click();
        }
    }
}
