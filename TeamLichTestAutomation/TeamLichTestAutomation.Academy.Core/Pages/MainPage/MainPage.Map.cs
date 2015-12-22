namespace TeamLichTestAutomation.Academy.Core.Pages.MainPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public partial class MainPage : BasePage
    {
        internal HtmlAnchor LoginButton
        {
            get
            {
                this.Browser.WaitUntilReady();
                this.Browser.RefreshDomTree();
                this.Browser.WaitForElement(5000, "id=EntranceButton");
                return this.Browser.Find.ById<HtmlAnchor>("EntranceButton");
            }
        }

        internal HtmlAnchor FacebookLoginButton
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=FbLogin");
                return this.Browser.Find.ById<HtmlAnchor>("FbLogin");
            }
        }

        public HtmlAnchor LogoutButton
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=ExitMI");
                return this.Browser.Find.ById<HtmlAnchor>("ExitMI");
            }
        }

        internal HtmlAnchor RegistrationButton
        {
            get
            {
                this.Browser.WaitUntilReady();
                return this.Browser.Find.ByContent<HtmlAnchor>("Регистрация");
            }
        }

        internal bool AdminDropdownEnabled
        {
            get
            {    
                try
                {
                    this.Browser.WaitForElement(5000, "title=~Админ");
                    this.Browser.RefreshDomTree();
                    var adminDropdown = this.Browser.Find.ByExpression<HtmlSpan>("title=~Админ");
                    return adminDropdown.IsEnabled;
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
        }

        internal HtmlAnchor AdminNavigationDropdown
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=SearchButton");
                return this.Browser.Find.ByExpression<HtmlAnchor>("href=/Administration/Navigation");
            }
        }

        internal HtmlAnchor CoursesNavigationDropdown
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=SearchButton");
                return this.Browser.Find.ByExpression<HtmlAnchor>("href=/Courses/Courses/List");
            }
        }
    }
}