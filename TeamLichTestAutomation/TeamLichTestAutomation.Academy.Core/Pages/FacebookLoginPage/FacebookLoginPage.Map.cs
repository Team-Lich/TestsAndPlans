namespace TeamLichTestAutomation.Academy.Core.Pages.FacebookLoginPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public partial class FacebookLoginPage
    {
        private HtmlInputText EmailTextbox
        {
            get
            {
                return this.Browser.Find.ById<HtmlInputText>("email");
            }
        }

        private HtmlInputPassword PasswordTextbox
        {
            get
            {
                return this.Browser.Find.ById<HtmlInputPassword>("pass");
            }
        }

        private HtmlInputSubmit LoginButton
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlInputSubmit>("name=login");
            }
        }
    }
}