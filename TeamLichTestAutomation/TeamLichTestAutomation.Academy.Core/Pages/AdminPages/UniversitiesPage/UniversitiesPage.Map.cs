using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.ObjectModel;
using Telerik.TestingFramework.Controls.KendoUI;

namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.UniversitiesPage
{
    public partial class UniversitiesPage
    {
        private HtmlAnchor AddButton
        {
            get 
            {
                string expressionString = @"href=/Administration_Users/Universities/Read?DataGrid-mode=insert";
                return this.Browser.Find.ByExpression<HtmlAnchor>(expressionString);
            }
        }

        private HtmlInputText NameTextbox
        {
            get
            {
                return this.Browser.Find.ById<HtmlInputText>("Name");
            }
        }

        private HtmlAnchor UpdateButton
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlAnchor>("class=~k-grid-update");
            }
        }

        internal KendoGrid KendoTable
        {
            get
            {
                return this.Browser.Find.ById<KendoGrid>("DataGrid");
            }
        }
    }
}