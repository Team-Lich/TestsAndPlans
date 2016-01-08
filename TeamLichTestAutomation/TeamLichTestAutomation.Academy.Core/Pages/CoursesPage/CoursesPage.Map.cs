namespace TeamLichTestAutomation.Academy.Core.Pages.CoursesPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public partial class CoursesPage
    {
        internal HtmlSpan SignOff
        {
            get
            {
                this.Browser.WaitForElement(5000, "onclick=~confirmQuitCourse");
                var signOffBtn = this.Browser.Find.ByExpression<HtmlSpan>("onclick=~confirmQuitCourse");
                return signOffBtn;
            }
        }

        internal HtmlControl Title
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlControl>(@"class=sectionTitle");
            }
        }

        internal HtmlControl FirstCourse
        {
            get
            {
                return this.Browser.Find.ByXPath<HtmlControl>(@"//*[@id=""MainContent""]/div/table/tbody/tr[1]/td[1]/strong");
            }
        }

        internal HtmlAnchor PresentationLink
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlAnchor>("href=http://stage.telerikacademy.com/Courses/LectureResources/43/Презентация");
            }
        }

        internal HtmlAnchor SendHomeworkLink
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlAnchor>("href=http://www.bgcoder.com/Contests/0");
            }
        }

        internal HtmlAnchor EvalHomeworkBtn
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlAnchor>("href=/Courses/HomeworkEvaluations/Evaluate/2223");
            }
        }

        internal HtmlAnchor PleaseLogInBtn
        {
            get
            {
                var btn = this.Browser.Find.ByExpression<HtmlAnchor>("href=/Users/Auth/Login?ReturnUrl=%2fCourses%2fCourses%2fList");
                return btn;
            }
        }

        internal HtmlSpan CourseParticipationInfo
        {
            get
            {
                return this.Browser.Find.ByXPath<HtmlSpan>(@"//*[@id=""MainContent""]/div/div[3]/div[2]/div[5]/div/div/span");
            }
        }

        internal HtmlControl TestCourse2Title
        {
            get
            {
                return this.Browser.Find.ById<HtmlControl>("panel-title");
            }
        }

        private HtmlSpan CourseLiveApply
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=SignUpLiveButton");
                var btn = this.Browser.Find.ById<HtmlSpan>("SignUpLiveButton");
                return btn;
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

        private HtmlAnchor DownloadLastSendedHW
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlAnchor>("href=/Courses/Homework/Download/190873");
            }
        }

        private HtmlInputFile ChooseFileToSend
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=homeworkFile");
                return this.Browser.Find.ById<HtmlInputFile>("homeworkFile");
            }
        }

        private HtmlControl SendHomeworkBtn
        {
            get
            {
                this.Browser.WaitForElement(3000, "id=SendButton");
                return this.Browser.Find.ById<HtmlControl>("SendButton");
            }
        }
    }
}