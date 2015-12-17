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

        internal HtmlAnchor LogoutButton
        {
            get
            {
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
                return this.Browser.Find.ByExpression<HtmlAnchor>("href=/Courses/Courses/List");
            }
        }
    }
}