namespace TeamLichTestAutomation.Academy.Core.Pages.RegistrationPage
{
    using ArtOfTest.WebAii.Core;

    public partial class RegistrationPage : BasePage
    {
        public RegistrationPage(Browser browser)
            : base(browser)
        {
        }

        public void RegistrationWithInvalidUsername()
        {
            string password = "123456";

            this.UsernameTextBox.Text = "user@test";
            this.PasswordTextBox.Text = password;
            this.RepeatPasswordTextBox.Text = password;
            this.FirstNameTextBox.Text = "ТестИме";
            this.LastNameTextBox.Text = "ТестФамилия";
            this.EmailTextBox.Text = "mailtest@test.com";
            this.TermAndConditionsCheckBox.IsEnabled = true;
            this.SubmitButton.Click();
        }
    }
}
