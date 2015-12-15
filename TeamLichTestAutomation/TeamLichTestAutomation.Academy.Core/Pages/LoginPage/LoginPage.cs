namespace TeamLichTestAutomation.Academy.Core.Pages.LoginPage
{
    using ArtOfTest.WebAii.Core;

    public partial class LoginPage : BasePage
    {
        public LoginPage(Browser browser) : base(browser)
        {
        }

        public void LoginRegularUser()
        {
            this.UserTextBox.Text = "TeamLichTestUser";
            this.PassTextBox.Text = "123456";
            this.SubmitButton.Click();
        }

        public void LoginAdminUser()
        {
            this.UserTextBox.Text = "TeamLichTestAdmin";
            this.PassTextBox.Text = "123456";
            this.SubmitButton.Click();
        }
    }
}