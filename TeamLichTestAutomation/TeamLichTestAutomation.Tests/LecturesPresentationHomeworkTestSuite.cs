namespace TeamLichTestAutomation.Tests
{
    using ArtOfTest.WebAii.Controls.HtmlControls;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.CoursesPage;
    using TeamLichTestAutomation.Academy.Core.Pages.LoginPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;
    using TeamLichTestAutomation.Academy.Core.Pages.RegistrationPage;

    using TeamLichTestAutomation.Utilities.Attributes;

    [TestClass]
    public class LecturesPresentationHomeworkTestSuite : BaseTest
    {
        private MainPage mainPage;
        private CoursesPage coursesPage;
        private LoginPage loginPage;
        private RegistrationPage registrationPage;

        [TestInitialize]
        public void ThisTestInitialize()
        {
            this.mainPage = new MainPage(this.Browser);
            this.coursesPage = new CoursesPage(this.Browser);
            this.loginPage = new LoginPage(this.Browser);
            this.registrationPage = new RegistrationPage(this.Browser);
        }

        [TestMethod]
        [TestCategory("LecturesPresentationsHomework")]
        [TestId(230)]
        [Priority(2)]
        [Owner("Ivan")]
        public void LecturesPresentationHomeworkCoursesListAccessWithoutLogin()
        {
            this.mainPage.Navigate().ClickCoursesNavigationDropdown();
            this.coursesPage.AssertCoursesFound();
        }

        [TestMethod]
        [TestCategory("LecturesPresentationsHomework")]
        [TestId(231)]
        [Priority(2)]
        [Owner("Ivan")]
        public void LecturesPresentationHomeworkCoursesListAccessWithLogin()
        {
            this.mainPage.Navigate().ClickLogin();
            this.loginPage.LoginUser(TelerikUser.Regular);
            this.mainPage.Navigate().ClickCoursesNavigationDropdown();
            this.coursesPage.AssertCoursesFound();
        }

        [TestMethod]
        [TestCategory("LecturesPresentationsHomework")]
        [TestId(232)]
        [Priority(2)]
        [Owner("Ivan")]
        public void LecturesPresentationHomeworkCoursesAccessFromUserDropdown()
        {
            this.mainPage.Navigate().ClickLogin();
            this.loginPage.LoginUser(TelerikUser.Regular);
            this.mainPage.HoverMyCoursesSpan();
            this.mainPage.MyCourseClick();

            this.coursesPage.AssertLecturePresent();
        }

        [TestMethod]
        [TestCategory("LecturesPresentationsHomework")]
        [TestId(233)]
        [Priority(2)]
        [Owner("Ivan")]
        public void LecturesPresentationHomeworkPressentationAccess()
        {
            this.mainPage.Navigate().ClickLogin();
            this.loginPage.LoginUser(TelerikUser.Regular);
            this.coursesPage.Navigate();
            this.coursesPage.AssertPresentationLinkPresent();
        }

        [TestMethod]
        [TestCategory("LecturesPresentationsHomework")]
        [TestId(234)]
        [Priority(2)]
        [Owner("Ivan")]
        public void LecturesPresentationHomeworkHomeworkAccess()
        {
            this.mainPage.Navigate().ClickLogin();
            this.loginPage.LoginUser(TelerikUser.Regular);
            this.coursesPage.Navigate();
            this.coursesPage.AssertSendHomeworkLinkPresent();
        }

        [TestMethod]
        [TestCategory("LecturesPresentationsHomework")]
        [TestId(235)]
        [Priority(2)]
        [Owner("Ivan")]
        public void LecturesPresentationHomeworkHomeworkEvalAccess()
        {
            this.mainPage.Navigate().ClickLogin();
            this.loginPage.LoginUser(TelerikUser.Regular);
            this.mainPage.EvalHomeworkClick();
            var actualTitle = this.Browser.Find.ByExpression<HtmlControl>(@"class=sectionTitle").GetValue<string>("innerText");
            var title = "ќцен€ване на домашно";
            Assert.AreEqual(title, actualTitle);
        }

        [TestMethod]
        [TestCategory("LecturesPresentationsHomework")]
        [TestId(236)]
        [Priority(2)]
        [Owner("Ivan")]
        public void LecturesPresentationHomeworkSendHomework()
        {
            this.mainPage.Navigate().ClickRegistration();
            this.registrationPage.RegisterRandomUser();
            this.coursesPage.Navigate();
            this.coursesPage.LiveSignUp();
            this.coursesPage.SendHomework();
        }

        [TestMethod]
        [TestCategory("LecturesPresentationsHomework")]
        [TestId(237)]
        [Priority(2)]
        [Owner("Ivan")]
        public void LecturesPresentationHomeworkDownloadLastHomeworkLinkPresent()
        {
            this.mainPage.Navigate().ClickRegistration();
            this.registrationPage.RegisterRandomUser();
            this.coursesPage.Navigate();
            this.coursesPage.LiveSignUp();
            this.coursesPage.SendHomework();
            this.coursesPage.AssertDownloadLastHwPresent();
        }

        [TestMethod]
        [TestCategory("LecturesPresentationsHomework")]
        [TestId(239)]
        [Priority(2)]
        [Owner("Ivan")]
        public void LecturesPresentationHomeworkHomeworkEvalFromCoursesPanel()
        {
            this.mainPage.Navigate().ClickLogin();
            this.loginPage.LoginUser(TelerikUser.Regular);
            this.coursesPage.Navigate();
            this.coursesPage.SendHomework();
            this.coursesPage.AssertHomewrokEvalBtnPresent();
        }

        [TestMethod]
        [TestCategory("LecturesPresentationsHomework")]
        [TestId(240)]
        [Priority(2)]
        [Owner("Ivan")]
        public void LecturesPresentationHomeworkPresentationsAccessWithoutLogin()
        {
            this.coursesPage.Navigate();
            this.coursesPage.AssertPresentationLinkPresent();
        }

        [TestMethod]
        [TestCategory("LecturesPresentationsHomework")]
        [TestId(241)]
        [Priority(2)]
        [Owner("Ivan")]
        public void LecturesPresentationHomeworkHomeworkAccessWithoutLogIn()
        {
            this.coursesPage.Navigate();

            this.coursesPage.AssertSendHomeworkLinkNotPresent();
        }

        [TestMethod]
        [TestCategory("LecturesPresentationsHomework")]
        [TestId(242)]
        [Priority(2)]
        [Owner("Ivan")]
        public void LecturesPresentationHomeworkCoursesAccessWihtoutLogIn()
        {
            this.coursesPage.Navigate();
            this.coursesPage.AssertTestCourse2Title();
        }
    }
}