namespace TeamLichTestAutomation.Academy.Core.Pages.LoginPage
{
    using ArtOfTest.WebAii.Core;
    using TeamLichTestAutomation.Academy.Core.Models;

    public partial class LoginPage : BasePage
    {
        private readonly string url = "http://stage.telerikacademy.com/Users/Auth/Login";

        public LoginPage(Browser browser)
            : base(browser)
        {
        }

        public string Url
        {
            get
            {
                return this.url;
            }
        }

        public void LoginUser(TelerikUser user)
        {
            this.UserTextBox.Text = user.UserName;
            this.PassTextBox.Text = user.Password;
            this.SubmitButton.Click();
        }
    }
}