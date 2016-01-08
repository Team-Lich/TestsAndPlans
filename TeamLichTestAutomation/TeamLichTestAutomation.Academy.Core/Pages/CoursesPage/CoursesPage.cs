namespace TeamLichTestAutomation.Academy.Core.Pages.CoursesPage
{
    using ArtOfTest.WebAii.Core;
    using System.Threading;
    using ArtOfTest.WebAii.Win32.Dialogs;

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
            var dialog = new ConfirmDialog(this.Browser, DialogButton.OK);
            Manager.Current.DialogMonitor.AddDialog(dialog);
            Manager.Current.DialogMonitor.Start();

            this.Browser.WaitForElement(3000, "id=SignUpLiveButton");
            this.CourseLiveApply.MouseClick(MouseClickType.LeftClick);

            dialog.WaitUntilHandled();

            //this.Browser.Desktop.KeyBoard.KeyPress(System.Windows.Forms.Keys.Enter);
        }

        public void OnlineSignUp()
        {
            var dialog = new ConfirmDialog(this.Browser, DialogButton.OK);
            Manager.Current.DialogMonitor.AddDialog(dialog);
            Manager.Current.DialogMonitor.Start();

            this.Browser.WaitForElement(3000, "id=SignUpOnlineButton");
            this.CourseOnlineApply.MouseClick();
            //Thread.Sleep(3000);
            //this.Browser.Desktop.KeyBoard.KeyPress(System.Windows.Forms.Keys.Enter);

            dialog.WaitUntilHandled();
        }

        public void SendHomework()
        {
            this.SendHomeworkLink.Click();
            this.ChooseFileToSend.Upload("../../../homeworkfile.zip", 10000);
            this.SendHomeworkBtn.Click();
        }
    }
}