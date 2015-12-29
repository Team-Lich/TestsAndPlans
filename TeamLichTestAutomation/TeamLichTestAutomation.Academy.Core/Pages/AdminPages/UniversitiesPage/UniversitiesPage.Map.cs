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
                this.Browser.RefreshDomTree();
                var box = this.Browser.Find.ById<HtmlInputText>("Name");
                return box;
            }
        }

        private HtmlAnchor UpdateButton
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlAnchor>("class=~k-grid-update");
            }
        }

        private HtmlAnchor BackToAdminButton
        {
            get 
            {
                return this.Browser.Find.ByExpression<HtmlAnchor>("href=/Administration/Navigation");
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