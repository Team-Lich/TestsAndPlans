namespace TeamLichTestAutomation.Academy.Core.Pages.FacebookLoginPage
{
    using System;
    using ArtOfTest.WebAii.Core;

    public partial class FacebookLoginPage : BasePage
    { 
        public FacebookLoginPage(Browser browser) : base(browser)
        {
        }

        public void LoginFacebookUser()
        {
            this.EmailTextbox.Text = "tl1z3l0r@abv.bg";
            this.PasswordTextbox.Text = "teamlich";
            this.LoginButton.Click();
        }
    }
}