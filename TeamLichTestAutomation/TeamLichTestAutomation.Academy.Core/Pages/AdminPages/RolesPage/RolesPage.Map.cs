namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.RolesPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using Telerik.TestingFramework.Controls.KendoUI;

    public partial class RolesPage
    {
        private HtmlButton DeleteButton
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlButton>("class=~k-grid-delete");
            }
        }

        private HtmlAnchor AddButton
        {
            get
            {
                string expressionString = "href=?/Read?DataGrid-mode=insert";
                this.Browser.WaitForElement(5000, expressionString);
                return this.Browser.Find.ByExpression<HtmlAnchor>(expressionString);
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
                this.Browser.RefreshDomTree();
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

        private HtmlTableCell IdHeader
        {
            get
            {
                this.Browser.RefreshDomTree();
                this.Browser.WaitForElement(5000, "data-field=UniversityId", "data-role=columnsorter");
                return this.Browser.Find.ByAttributes<HtmlTableCell>("data-field=UniversityId");
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