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
                    ById<HtmlSpan>("CourseLiveApplyForm");
            }
        }

        private HtmlSpan CourseOnlineApply
        {
            get
            {
                return this.Browser.Find.ById<HtmlSpan>("SignUpOnlineButton");
            }
        }

        public HtmlButton SignOff
        {
            get
            {
                return this.Browser.Find.ByXPath<HtmlButton>("//*[@id='MainContent']/div/div[5]/div[2]/div[6]/div/div[2]/span");
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
