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

        // FirstFriendUser and SecondFriendUser should be already friends
        //public void LoginFriendUser(string userName)
        //{
        //    this.UserTextBox.Text = userName;
        //    this.PassTextBox.Text = "123456";
        //    this.SubmitButton.Click();
        //}

        //public void LoginFirstTwinUser()
        //{
        //    this.UserTextBox.Text = "TeamLich_FirstTwin";
        //    this.PassTextBox.Text = "123456";
        //    this.SubmitButton.Click();
        //}
        //public void LoginSecondTwinUser()
        //{
        //    this.UserTextBox.Text = "TeamLich_SecondTwin";
        //    this.PassTextBox.Text = "123456";
        //    this.SubmitButton.Click();
        //}
    }
}