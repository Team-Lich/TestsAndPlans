namespace TeamLichTestAutomation.Academy.Core.Pages.MainPage
{
    using ArtOfTest.WebAii.Core;

    public partial class MainPage
    {
        private readonly string url = "http://stage.telerikacademy.com/";

        public MainPage(Browser browser)
            : base(browser)
        {
        }

        public MainPage Navigate()
        {
            this.Browser.NavigateTo(this.url);
            this.Browser.WaitUntilReady();
            return this;
        }

        public MainPage NavigateTo(string url)
        {
            this.Browser.NavigateTo(url);
            this.Browser.WaitUntilReady();
            return this;
        }

        public void ClickLogout()
        {
            var logoutButton = this.LogoutButton;
            logoutButton.Click();
            this.Browser.WaitUntilReady();
        }

        public void ClickLogin()
        {
            var loginButton = this.LoginButton;
            loginButton.Click();
            this.Browser.WaitUntilReady();
        }

        public void ClickFacebookLogin()
        {
            var facebookLoginButton = this.FacebookLoginButton;
            facebookLoginButton.Click();
        }

        public void ClickRegistration()
        {
            var registrationButton = this.RegistrationButton;
            this.RegistrationButton.Click();
            this.Browser.WaitUntilReady();
        }

        public void ClickCoursesNavigationDropdown()
        {
            this.Browser.WaitForElement(5000, "href=/Courses/Courses/List");
            var coursesNavigation = this.CoursesNavigationDropdown;
            coursesNavigation.Click();
        }

        public void ClickAdminNavigationDropdown()
        {
            this.AdminNavigationDropdown.Click();
        }

        public void HoverUserNavigationDropdown()
        {
            this.UserNavigationDropdown.MouseHover();
        }

        public void HoverMyCoursesSpan()
        {
            this.UserNavigationDropdown.MouseHover();
            this.UserNavigationDropdownMyCoursesSpan.MouseHover();
        }

        public void MyCourseClick()
        {
            this.MyCourse.Click();
        }

        public void EvalHomeworkClick()
        {
            this.UserNavigationDropdown.MouseHover();
            this.EvalHomework.Click();
        }

        public void HoverCoursesNavigationDropdown()
        {
            this.Browser.WaitForElement(5000, "href=/Courses/Courses/List");
            var coursesNavigation = this.CoursesNavigationDropdown;
            coursesNavigation.MouseHover();
        }
    }
}