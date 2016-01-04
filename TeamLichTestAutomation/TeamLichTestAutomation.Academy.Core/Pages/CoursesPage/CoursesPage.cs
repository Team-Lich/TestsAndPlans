namespace TeamLichTestAutomation.Academy.Core.Pages.CoursesPage
{
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.Win32.Dialogs;
    using System.Threading;

    public partial class CoursesPage : BasePage
    {
        private string url = "http://stage.telerikacademy.com/Courses/Courses/Details/265";

        public CoursesPage(Browser browser)
            : base(browser)
        {
        }

        public CoursesPage Navigate()
        {
            this.Browser.NavigateTo(this.url);
            return this;
        }

        public void LiveSignUp()
        {
            this.Browser.WaitForElement(3000, "id=SearchButton");
            this.CourseLiveApply.MouseClick();
            Thread.Sleep(3000);
            this.Browser.Desktop.KeyBoard.KeyPress(System.Windows.Forms.Keys.Enter);
        }

        public void OnlineSignUp()
        {
            this.Browser.WaitForElement(3000, "id=SearchButton");
            this.CourseOnlineApply.MouseClick();
            Thread.Sleep(3000);
            this.Browser.Desktop.KeyBoard.KeyPress(System.Windows.Forms.Keys.Enter);
        }

        public void SendHomework()
        {
            this.SendHomeworkLink.Click();
            this.ChooseFileToSend.Upload("../../../homeworkfile.zip", 10000);
            this.SendHomeworkBtn.Click();
        }
    }
}