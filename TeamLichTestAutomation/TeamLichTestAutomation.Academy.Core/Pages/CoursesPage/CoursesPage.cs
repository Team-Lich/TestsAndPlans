namespace TeamLichTestAutomation.Academy.Core.Pages.CoursesPage
{
    using ArtOfTest.WebAii.Core;

    public partial class CoursesPage : BasePage
    {
        public CoursesPage(Browser browser)
            : base(browser)
        {
        }

        public void liveSignUp()
        {
            this.CourseLiveApply.Click();
        }

        public void OnlineSignUp()
        {
            this.CourseOnlineApply.Click();
        }
    }
}
