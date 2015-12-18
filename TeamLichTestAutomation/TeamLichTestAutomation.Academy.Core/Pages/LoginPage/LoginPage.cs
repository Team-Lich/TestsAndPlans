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

        // FirstFriendUser and SecondFriendUser should be already friends
        public void LoginFriendUser(string userName)
        {
            this.UserTextBox.Text = userName;
            this.PassTextBox.Text = "123456";
            this.SubmitButton.Click();
        }

        public void LoginFirstTwinUser()
        {
            this.UserTextBox.Text = "TeamLich_FirstTwin";
            this.PassTextBox.Text = "123456";
            this.SubmitButton.Click();
        }
        public void LoginSecondTwinUser()
        {
            this.UserTextBox.Text = "TeamLich_SecondTwin";
            this.PassTextBox.Text = "123456";
            this.SubmitButton.Click();
        }

        public void LoginUser(string userName, string password)
        {
            this.UserTextBox.Text = userName;
            this.PassTextBox.Text = password;
            this.SubmitButton.Click();
        }
    }
}