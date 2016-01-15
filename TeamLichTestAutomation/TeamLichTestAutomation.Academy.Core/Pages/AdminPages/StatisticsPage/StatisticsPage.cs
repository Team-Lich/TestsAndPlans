namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.StatisticsPage
{
    using System.Threading;
    using System.Windows.Forms;

    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.Win32.Dialogs;

    using Telerik.TestingFramework.Controls.KendoUI;

    public partial class StatisticsPage : BasePage
    {
        private readonly string url = "http://stage.telerikacademy.com/Administration_Users/Statistics";

        public StatisticsPage(Browser browser)
           : base(browser)
        {
        }

        public string Url
        {
            get
            {
                return this.url;
            }
        }

        public HtmlDiv GetGenderChart
        {
            get
            {
                return this.GenderChart;
            }
        }

        public HtmlDiv GetCitiesChart
        {
            get
            {
                return this.CitiesChart;
            }
        }

        public HtmlDiv GetMonthlyRegistrationsChart
        {
            get
            {
                return this.MonthlyRegistrationsChart;
            }
        }

        public HtmlDiv GetLastSixtyDaysRegistrationsChart
        {
            get
            {
                return this.LastSixtyDaysRegistrationsChart;
            }
        }
    }
}