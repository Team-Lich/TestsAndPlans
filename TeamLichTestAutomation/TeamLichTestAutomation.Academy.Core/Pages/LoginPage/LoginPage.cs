namespace TeamLichTestAutomation.Academy.Core.Pages.LoginPage
{
    using ArtOfTest.WebAii.Core;
    using TeamLichTestAutomation.Academy.Core.Models;

    public partial class LoginPage : BasePage
    {
        public LoginPage(Browser browser) : base(browser)
        {
        }

        public void LoginUser(TelerikUser user)
        {
            this.UserTextBox.Text = user.UserName;
            this.PassTextBox.Text = user.Password;
            this.SubmitButton.Click();
        }
    }
}