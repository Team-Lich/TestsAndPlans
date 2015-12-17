namespace TeamLichTestAutomation.Academy.Core.Pages.RegistrationPage
{
    using ArtOfTest.WebAii.Core;

    public partial class RegistrationPage : BasePage
    {
        public RegistrationPage(Browser browser)
            : base(browser)
        {
        }

        const string Password = "123456";

        public void RegistrationWithInvalidUsername()
        {
            string password = "123456";

            this.UsernameTextBox.Text = "user@test";
            this.PasswordTextBox.Text = Password;
            this.RepeatPasswordTextBox.Text = Password;
            this.FirstNameTextBox.Text = "ТестИме";
            this.LastNameTextBox.Text = "ТестФамилия";
            this.EmailTextBox.Text = "mailtest@test.com";
            this.TermAndConditionsCheckBox.IsEnabled = true;
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
            this.TermAndConditionsCheckBox.IsEnabled = true;
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
            this.TermAndConditionsCheckBox.IsEnabled = true;
            this.SubmitButton.Click();
        }

        public void RegistrationWithEmptyLastNameField()
        {
            this.UsernameTextBox.Text = "usertest";
            this.PasswordTextBox.Text = Password;
            this.RepeatPasswordTextBox.Text = Password;
            this.FirstNameTextBox.Text = "ТестИме";
            this.EmailTextBox.Text = "mailtest@test.com";
            this.TermAndConditionsCheckBox.IsEnabled = true;
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

        public void RegistrationWithDifferentPasswordInPasswordAgainField()
        {
            this.UsernameTextBox.Text = "usertest";
            this.PasswordTextBox.Text = Password;
            this.RepeatPasswordTextBox.Text = "12345678";
            this.FirstNameTextBox.Text = "ТестИме";
            this.LastNameTextBox.Text = "ТестФамилия";
            this.EmailTextBox.Text = "mailtest@test.com";
            this.TermAndConditionsCheckBox.IsEnabled = true;
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
            this.TermAndConditionsCheckBox.IsEnabled = true;
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
            this.TermAndConditionsCheckBox.IsEnabled = true;
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
            this.TermAndConditionsCheckBox.IsEnabled = true;
            this.SubmitButton.Click();
        }
    }
}
