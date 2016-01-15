namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.StatisticsPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using Telerik.TestingFramework.Controls.KendoUI;

    public partial class StatisticsPage
    {
        private HtmlDiv GenderChart
        {
            get
            {
                return this.Browser.Find.ById<HtmlDiv>("genderChart");
            }
        }

        private HtmlDiv CitiesChart
        {
            get
            {
                return this.Browser.Find.ById<HtmlDiv>("citiesChart");
            }
        }

        private HtmlDiv MonthlyRegistrationsChart
        {
            get
            {
                return this.Browser.Find.ById<HtmlDiv>("chart");
            }
        }

        private HtmlDiv LastSixtyDaysRegistrationsChart
        {
            get
            {
                return this.Browser.Find.ById<HtmlDiv>("lastSixtyDaysChart");
            }
        }
    }
}