namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.UniversitiesPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using Telerik.TestingFramework.Controls.KendoUI;

    public partial class CommentsPage
    {
        internal KendoGrid KendoTable
        {
            get
            {
                return this.Browser.Find.ById<KendoGrid>("DataGrid");
            }
        }

        private HtmlButton DeleteButton
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlButton>("class=~k-grid-delete");
            }
        }

        private HtmlButton ExportAsExcelButton
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlButton>("class=~k-grid-excel");
            }
        }

        private HtmlInputText NameTextbox
        {
            get
            {
                this.Browser.RefreshDomTree();
                this.Browser.WaitForElement(5000, "id=Name");
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

        private HtmlTableCell NameHeader
        {
            get
            {
                this.Browser.RefreshDomTree();
                this.Browser.WaitForElement(5000, "data-field=Name", "data-role=columnsorter");
                return this.Browser.Find.ByAttributes<HtmlTableCell>("data-field=Name");
            }
        }
    }
}