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

        public HtmlControl Title
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlControl>(@"class=sectionTitle");
            }
        }

        public HtmlControl FirstCourse
        {
            get
            {
                return this.Browser.Find.ByXPath<HtmlControl>(@"//*[@id=""MainContent""]/div/table/tbody/tr[1]/td[1]/strong");
            }
        }

        public HtmlAnchor PresentationLink
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlAnchor>("href=http://stage.telerikacademy.com/Courses/LectureResources/43/Презентация");
            }
        }

        public HtmlAnchor SendHomeworkLink
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlAnchor>("href=http://www.bgcoder.com/Contests/0");
            }
        }
    }
}