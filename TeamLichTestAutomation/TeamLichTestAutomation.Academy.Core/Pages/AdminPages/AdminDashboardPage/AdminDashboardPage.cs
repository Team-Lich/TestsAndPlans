namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.AdminDashboardPage
{
    using ArtOfTest.WebAii.Core;

    public partial class AdminDashboardPage : BasePage
    {
        public AdminDashboardPage(Browser browser) : base(browser)
        {
        }

        public void ClickUniversitiesButton()
        {
            this.UniversitiesButton.Click();
        }

        public void ClickFriendshipButton()
        {
            this.FriendshipButton.Click();
        }

        public void ClickRolesButton()
        {
            this.RolesButton.Click();
        }

        public void ClickUsersButton()
        {
            this.UsersButton.Click();
        }

        public void ClickProvincesButton()
        {
            this.ProvincesButton.Click();
        }

        public void ClickWorkEducationStatusesButton()
        {
            this.WorkEducationStatusesButton.Click();
        }

        public void ClickAttendanceLogsButton()
        {
            this.AttendanceLogsButton.Click();
        }

        public void ClickCommentsButton()
        {
            this.CommentsButton.Click();
        }

        public void ClickAvatarsButton()
        {
            this.AvatarsButton.Click();
        }

        public void ClickLabelsButton()
        {
            this.LabelsButton.Click();
        }

        public void ClickComplexSearchButton()
        {
            this.ComplexSearchButton.Click();
        }

        public void ClickFilteredExportToExcel()
        {
            this.FilteredExportToExcelButton.Click();
        }
    }
}