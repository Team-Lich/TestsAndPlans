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
            this.Browser.WaitForElement(3000, "id=SearchButton");
            this.CourseLiveApply.Click();
        }

        public void OnlineSignUp()
        {
            this.Browser.WaitForElement(3000, "id=SearchButton");
            this.CourseOnlineApply.Click();
        }
    }
}
