namespace TeamLichTestAutomation.Academy.Core.Pages.RegistrationPage
{
    using System;
    using ArtOfTest.WebAii.Core;

    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Utilities;

    public partial class RegistrationPage : BasePage
    {
        public RegistrationPage(Browser browser)
            : base(browser)
        {
        }

        public void RegisterRandomUser()
        {
            RandomStringGenerator generator = new RandomStringGenerator();

            this.UsernameTextBox.Text = generator.GetString(8);
            this.PasswordTextBox.Text = "123456";
            this.RepeatPasswordTextBox.Text = "123456";
            this.FirstNameTextBox.Text = "ТестИме";
            this.LastNameTextBox.Text = "ТестФамилия";
            this.EmailTextBox.Text = generator.GetString(8) + "@test.com";
            this.TermAndConditionsCheckBox.MouseClick(MouseClickType.LeftClick);
            this.SubmitButton.Click();
        }

        public void RegisterTelerikUser(TelerikUser user)
        {
            this.UsernameTextBox.Text = user.UserName;
            this.PasswordTextBox.Text = user.Password;
            this.RepeatPasswordTextBox.Text = user.Password;
            this.FirstNameTextBox.Text = user.FirstName;
            this.LastNameTextBox.Text = user.LastName;
            this.EmailTextBox.Text = user.Email;
            this.TermAndConditionsCheckBox.Checked = true;
            this.SubmitButton.Click();
        }

        public void RegisterTelerikUser(TelerikUser user, string passwordAgain)
        {
            this.UsernameTextBox.Text = user.UserName;
            this.PasswordTextBox.Text = user.Password;
            this.RepeatPasswordTextBox.Text = passwordAgain;
            this.FirstNameTextBox.Text = user.FirstName;
            this.LastNameTextBox.Text = user.LastName;
            this.EmailTextBox.Text = user.Email;
            this.TermAndConditionsCheckBox.Checked = true;
            this.SubmitButton.Click();
        }

        public void RegisterTelerikUserWithUncheckedCheckbox(TelerikUser user)
        {
            string uniqueAddition = this.GetUniqueAddition();

            this.UsernameTextBox.Text = user.UserName + uniqueAddition;
            this.PasswordTextBox.Text = user.Password;
            this.RepeatPasswordTextBox.Text = user.Password;
            this.FirstNameTextBox.Text = user.FirstName;
            this.LastNameTextBox.Text = user.LastName;
            this.EmailTextBox.Text = uniqueAddition + user.Email;
            this.SubmitButton.Click();
        }

        private string GetUniqueAddition()
        {
            var dateTime = DateTime.Now;
            string uniqueAddition = dateTime.ToString("ssmmhhddMMyyyy");
            return uniqueAddition;
        }
    }
}