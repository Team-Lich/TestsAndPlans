namespace TeamLichTestAutomation.Academy.Core.Pages.CoursesPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public partial class CoursesPage
    {
        private HtmlSpan CourseLiveApply
        {
            get
            {
                return this.Browser.Find.
                    ById<HtmlSpan>("SignUpLiveButton");
            }
        }

        private HtmlSpan CourseOnlineApply
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=SignUpOnlineButton");
                return this.Browser.Find.ById<HtmlSpan>("SignUpOnlineButton");
            }
        }

        public HtmlSpan SignOff
        {
            get
            {
                this.Browser.WaitForElement(5000, "onclick=~confirmQuitCourse");
                return this.Browser.Find.ByExpression<HtmlSpan>("onclick=~confirmQuitCourse");
            }
        }

        public HtmlSpan Title
        {
            get
            {
                return this.Browser.Find.ByXPath<HtmlSpan>(@"//*[@id='MainContent']/div/h1");
            }
        }
    }
}
