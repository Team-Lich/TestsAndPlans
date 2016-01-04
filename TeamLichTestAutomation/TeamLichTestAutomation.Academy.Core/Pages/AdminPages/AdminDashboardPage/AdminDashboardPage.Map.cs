namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.AdminDashboardPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public partial class AdminDashboardPage
    {
        private HtmlAnchor AttendanceLogsButton
        {
        get
            {
            return this.Browser.Find.ByExpression<HtmlAnchor>("href=/Administration_Users/AttendanceLogs");
            }
        }

        private HtmlAnchor AvatarsButton
        {
        get
            {
            return this.Browser.Find.ByExpression<HtmlAnchor>("href=/Administration_Users/UsersAvatars");
            }
        }

        private HtmlAnchor ComplexSearchButton
        {
        get
            {
            return this.Browser.Find.ByExpression<HtmlAnchor>("href=/Administration_Users/ComplexSearch");
            }
        }

        private HtmlAnchor CommentsButton
        {
        get
            {
            return this.Browser.Find.ByExpression<HtmlAnchor>("href=/Administration_Users/Comments");
            }
        }

        private HtmlAnchor FilteredExportToExcelButton
        {
        get
            {
            return this.Browser.Find.ByExpression<HtmlAnchor>("href=/Administration_Users/FilteredExportToExcel");
            }
        }

        private HtmlAnchor FriendshipButton
        {
        get
            {
            return this.Browser.Find.ByExpression<HtmlAnchor>("href=/Administration_Users/Friendship");
            }
        }

        private HtmlAnchor LabelsButton
        {
        get
            {
            return this.Browser.Find.ByExpression<HtmlAnchor>("href=/Administration_Users/Labels");
            }
        }

        private HtmlAnchor ProvincesButton
        {
        get
            {
            return this.Browser.Find.ByExpression<HtmlAnchor>("href=/Administration_Users/Provinces");
            }
        }

        private HtmlAnchor RolesButton
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlAnchor>("href=/Administration_Users/Roles");
            }
        }

        private HtmlAnchor UniversitiesButton
            {
            get
                {
                return this.Browser.Find.ByExpression<HtmlAnchor>("href=/Administration_Users/Universities");
                }
            }

        private HtmlAnchor UsersButton
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlAnchor>("href=/Administration_Users/Users");
            }
        }

        private HtmlAnchor WorkEducationStatusesButton
            {
            get
                {
                return this.Browser.Find.ByExpression<HtmlAnchor>("href=/Administration_Users/WorkEducationStatuses");
                }
            }
    }
}