namespace TeamLichTestAutomation.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.CoursesPage;
    using TeamLichTestAutomation.Academy.Core.Pages.LoginPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;
    using TeamLichTestAutomation.Academy.Core.Pages.RegistrationPage;

    using TeamLichTestAutomation.Utilities.Attributes;

    [TestClass]
    public class CourseSignUpTestSuite : BaseTest
    {
        private RegistrationPage registrationPage;
        private MainPage mainPage;
        private CoursesPage coursesPage;
        private LoginPage loginPage;

        [TestInitialize]
        public void ThisTestInitialize()
        {
            this.mainPage = new MainPage(this.Browser);
            this.coursesPage = new CoursesPage(this.Browser);
            this.loginPage = new LoginPage(this.Browser);
            this.registrationPage = new RegistrationPage(this.Browser);
        }

        [TestMethod]
        [TestCategory("CourseSignUp")]
        [TestId(221)]
        [Priority(2)]
        [Owner("Ivan")]
        public void CourseSignUpLiveSignUp()
        {
            this.mainPage.Navigate().ClickRegistration();
            this.registrationPage.RegisterRandomUser();
            this.mainPage.NavigateTo("http://stage.telerikacademy.com/Courses/Courses/Details/265");
            this.coursesPage.LiveSignUp();

            this.coursesPage.AssertSignOffBtn();
        }

        [TestMethod]
        [TestCategory("CourseSignUp")]
        [TestId(222)]
        [Priority(2)]
        [Owner("Ivan")]
        public void CourseSignUpOnlineSignUp()
        {
            this.mainPage.Navigate().ClickRegistration();
            this.registrationPage.RegisterRandomUser();
            this.mainPage.NavigateTo("http://stage.telerikacademy.com/Courses/Courses/Details/265");
            this.coursesPage.OnlineSignUp();

            this.coursesPage.AssertSignOffBtn();
        }

        [TestMethod]
        [TestCategory("CourseSignUp")]
        [TestId(223)]
        [Priority(2)]
        [Owner("Ivan")]
        public void CourseSignUpSignUpWithoutLogIn()
        {
            this.mainPage.NavigateTo("http://stage.telerikacademy.com/Courses/Courses/Details/265");
            this.coursesPage.AssertPleaseLogInBtnPresent();
        }

        [TestMethod]
        [TestCategory("CourseSignUp")]
        [TestId(224)]
        [Priority(3)]
        [Owner("Ivan")]
        public void CourseSignUpLiveSignUpFromCoursesList()
        {
            this.mainPage.Navigate().ClickRegistration();
            this.registrationPage.RegisterRandomUser();
            this.mainPage.HoverCoursesNavigationDropdown();
            this.mainPage.MyCourseClick();
            this.coursesPage.LiveSignUp();
            this.coursesPage.AssertSignOffBtn();
        }

        [TestMethod]
        [TestCategory("CourseSignUp")]
        [TestId(225)]
        [Priority(3)]
        [Owner("Ivan")]
        public void CourseSignUpOnlineSignUpFromSignOffCourse()
        {
            this.mainPage.Navigate().ClickLogin();
            this.loginPage.LoginUser(TelerikUser.Regular);
            this.coursesPage.Navigate();
            this.coursesPage.AssertSignedOffCourse();
        }

        [TestMethod]
        [TestCategory("CourseSignUp")]
        [TestId(226)]
        [Priority(3)]
        [Owner("Ivan")]
        public void CourseSignUpOnlineSignUpFromCoursesList()
        {
            this.mainPage.Navigate().ClickRegistration();
            this.registrationPage.RegisterRandomUser();
            this.mainPage.HoverCoursesNavigationDropdown();
            this.mainPage.MyCourseClick();
            this.coursesPage.OnlineSignUp();
            this.coursesPage.AssertSignOffBtn();
        }

        [TestMethod]
        [TestCategory("CourseSignUp")]
        [TestId(227)]
        [Priority(3)]
        [Owner("Ivan")]
        public void CourseSignUpSignUpFromCoursesListWithoutLogIn()
        {
            this.mainPage.HoverCoursesNavigationDropdown();
            this.mainPage.MyCourseClick();
            this.coursesPage.AssertPleaseLogInBtnPresent();
        }

        [TestMethod]
        [TestCategory("CourseSignUp")]
        [TestId(228)]
        [Priority(3)]
        [Owner("Ivan")]
        public void CourseSignUpLiveSignUpFromSignOffCourse()
        {
            this.mainPage.Navigate().ClickLogin();
            this.loginPage.LoginUser(TelerikUser.Regular);
            this.coursesPage.Navigate();
            this.coursesPage.AssertSignedOffCourse();
        }
    }
}