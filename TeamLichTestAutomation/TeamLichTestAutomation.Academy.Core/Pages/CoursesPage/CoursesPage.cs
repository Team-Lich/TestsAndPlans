﻿namespace TeamLichTestAutomation.Academy.Core.Pages.CoursesPage
{
    using ArtOfTest.WebAii.Core;

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
            this.CourseLiveApply.Click();
        }

        public void OnlineSignUp()
        {
            this.Browser.WaitForElement(3000, "id=SearchButton");
            this.CourseOnlineApply.Click();
        }

        public void SendHomework()
        {
            this.SendHomeworkLink.Click();
            this.ChooseFileToSend.Upload("../../../homeworkfile.zip", 10000);
            this.SendHomeworkBtn.Click();
        }
    }
}