namespace TeamLichTestAutomation.Academy.Core.Pages.MainPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public partial class MainPage : BasePage
    {
        internal HtmlAnchor LoginButton
        {
            get
            {
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
                return this.Browser.Find.ByContent<HtmlAnchor>("Регистрация");
            }
        }

        internal string[] NavigationBarItems
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=SearchButton");
                var anchors = this.Browser.Find.AllByTagName<HtmlAnchor>("a");
                string[] anchorTexts = new string[anchors.Count];

                for (int i = 0; i < anchors.Count; i++)
                {
                    anchorTexts[i] = anchors[i].InnerText;
                }

                return anchorTexts;
            }
        }

        internal HtmlAnchor AdminNavigationDropdown
        {
            get
            {
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