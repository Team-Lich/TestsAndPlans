﻿namespace TeamLichTestAutomation.Academy.Core.Pages.MainPage
{
    using ArtOfTest.WebAii.Core;

    public partial class MainPage
    {
        private string url = "http://stage.telerikacademy.com/";

        public MainPage(Browser browser)
            : base(browser)
        {
        }

        public MainPage Navigate()
        {
            this.Browser.NavigateTo(this.url);
            return this;
        }

        public void ClickLogin()
        {
            var loginButton = this.LoginButton;
            loginButton.Click();
        }

        public void ClickFacebookLogin()
        {
            var facebookLoginButton = this.FacebookLoginButton;
            facebookLoginButton.Click();
        }

        public void ClickRegistration()
        {
            var registrationButton = this.RegistrationButton;
            RegistrationButton.Click();
        }

        public void ClickCoursesNavigationDropdown()
        {
            var coursesNavigation = this.CoursesNavigationDropdown;
            coursesNavigation.Click();
        }
    }
}